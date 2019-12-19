using FFmpeg.NET;
using SimpleVideoCutter.FFmpegNET;
using SimpleVideoCutter.Settings;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleVideoCutter
{
    public class TaskProcessor : INotifyPropertyChanged
    {
        private IList<FFmpegTask> tasks = new List<FFmpegTask>();
        private FFmpegTask currentTask = null;
        private Thread workerThread = null;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<TaskProgressEventArgs> TaskProgress;

        public bool StopRequest { get; set; } = false;


        public void Start()
        {
            workerThread = new Thread(WorkerThread);
            workerThread.Start();
        }

        public void EnqueueTask(FFmpegTask task)
        {
            lock (tasks)
            {
                tasks.Add(task);
            }
            OnPropertyChanged("Tasks");
        }

        public IList<FFmpegTask> GetTasks()
        {
            lock (tasks)
            {
                var result = tasks.ToList();
                return result;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnTaskProgress(string progressText)
        {
            TaskProgress?.Invoke(this, new TaskProgressEventArgs() { ProgressText = progressText });
        }

        private void WorkerThread()
        {
            while (!StopRequest)
            {
                if (currentTask == null)
                {
                    FFmpegTask taskToSchedule = null;
                    lock (tasks)
                    {
                        taskToSchedule = tasks.FirstOrDefault(t => t.State == FFmpegTaskState.Scheduled);
                        if (taskToSchedule == null)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                    }

                    currentTask = taskToSchedule;

                    var ffmpeg = new Engine(VideoCutterSettings.Instance.FFmpegPath);
                    ffmpeg.Complete += (object sender, FFmpeg.NET.Events.ConversionCompleteEventArgs e) =>
                    {
                        currentTask.State = FFmpegTaskState.FinishedOK;
                        currentTask = null;
                        OnPropertyChanged("Tasks");
                        OnTaskProgress("Done");
                    };
                    ffmpeg.Error += (object sender, FFmpeg.NET.Events.ConversionErrorEventArgs e) =>
                    {
                        currentTask.State = FFmpegTaskState.FinishedError;
                        currentTask.ErrorMessage = e.Exception.Message;
                        currentTask = null;
                        OnPropertyChanged("Tasks");
                        OnTaskProgress("Failure: "+e.Exception.Message);
                    };

                    ffmpeg.Progress += (object sender, FFmpeg.NET.Events.ConversionProgressEventArgs e) =>
                    {
                        var msg = string.Format("Processed {0} seconds", e.ProcessedDuration.TotalSeconds);
                        OnTaskProgress(msg);
                    };

                    try
                    {
                        var ffmpegCutArguments = FFmpegArgumentBuilder.BuildArgumentsCutOperation(
                            currentTask.InputFilePath, 
                            currentTask.OutputFilePath, 
                            TimeSpan.FromMilliseconds(currentTask.SelectionStart), 
                            TimeSpan.FromMilliseconds(currentTask.Duration),
                            currentTask.Profile.Arguments);

                        currentTask.State = FFmpegTaskState.InProgress;
                        OnPropertyChanged("Tasks");

                        Task taskConversion = ffmpeg.ExecuteAsync(ffmpegCutArguments);
                        taskConversion.Wait();
                    }
                    catch (Exception e)
                    {
                        currentTask.State = FFmpegTaskState.FinishedError;
                        currentTask.ErrorMessage = e.Message;
                        currentTask = null;
                        OnPropertyChanged("Tasks");
                        OnTaskProgress("Failure: " + e.Message);
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
    }

    public class FFmpegTask
    {
        public string TaskId { get; set; }
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string InputFileName { get; set; }
        public long SelectionStart { get; set; }
        public long Duration { get; set; }
        public FFmpegCutProfile Profile { get; set; }
        public FFmpegTaskState State { get; set; }
        public string ErrorMessage { get; set; }


        public string StateLabel
        {
            get
            {
                switch (State)
                {
                    case FFmpegTaskState.Scheduled: return "Scheduled";
                    case FFmpegTaskState.InProgress: return "In progress";
                    case FFmpegTaskState.FinishedOK: return "Done";
                    case FFmpegTaskState.FinishedError: return "Error";
                    default: return "Unrecognized";
                }
            }
        }
    }
    public enum FFmpegTaskState
    {
        Scheduled,
        InProgress,
        FinishedOK,
        FinishedError,
    }

    public class TaskProgressEventArgs : EventArgs
    {
        public string ProgressText { get; set; }
    }
}
