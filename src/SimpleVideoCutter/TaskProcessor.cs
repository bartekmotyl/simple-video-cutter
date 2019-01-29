using FFmpeg.NET;
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
        private ConcurrentQueue<FFmpegTask> tasks = new ConcurrentQueue<FFmpegTask>();
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
            tasks.Enqueue(task);
            OnPropertyChanged("Tasks");
        }

        public IList<FFmpegTask> GetTasks()
        {
            var result = tasks.ToList();

            if (currentTask != null)
                result.Insert(0, currentTask);

            return result; 
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
                if (currentTask == null && tasks.TryDequeue(out currentTask))
                {
                    var ffmpeg = new Engine(MainForm.VideoCutterSettings.FFmpegPath);
                    ffmpeg.Complete += (object sender, FFmpeg.NET.Events.ConversionCompleteEventArgs e) =>
                    {
                        currentTask = null;
                        OnPropertyChanged("Tasks");
                        OnTaskProgress("Done");
                    };
                    ffmpeg.Error += (object sender, FFmpeg.NET.Events.ConversionErrorEventArgs e) =>
                    {
                        currentTask = null;
                        OnPropertyChanged("Tasks");
                        OnTaskProgress("Failure: "+e.Exception.Message);
                    };

                    ffmpeg.Progress += (object sender, FFmpeg.NET.Events.ConversionProgressEventArgs e) =>
                    {
                        var msg = string.Format("Processed {0} seconds", e.ProcessedDuration.TotalSeconds);
                        OnTaskProgress(msg);
                    };

                    var options = new ConversionOptions();
                    options.CutMedia(TimeSpan.FromMilliseconds(currentTask.SelectionStart), TimeSpan.FromMilliseconds(currentTask.Duration));

                    Task<MediaFile> taskConversion = ffmpeg.ConvertAsync(new MediaFile(currentTask.InputFilePath), new MediaFile(currentTask.OutputFilePath), options);
                    taskConversion.Wait();
                }
                else
                {
                    Thread.Sleep(1000);
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
    }

    public class TaskProgressEventArgs : EventArgs
    {
        public string ProgressText { get; set; }
    }
}
