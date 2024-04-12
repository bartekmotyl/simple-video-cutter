using FFmpeg.NET;
using SimpleVideoCutter.FFmpegNET;
using SimpleVideoCutter.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleVideoCutter
{
    public class TaskProcessor : INotifyPropertyChanged
    {
        private IList<FFmpegTask> tasks = new List<FFmpegTask>();
        private Thread? workerThread = null;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<TaskProgressEventArgs>? TaskProgress;

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

        private string GetPartialOutputPath(FFmpegTask task, int index)
        {
            return string.Format($"{Path.GetDirectoryName(task.OutputFilePath)}{Path.DirectorySeparatorChar}"
                + $"{Path.GetFileNameWithoutExtension(task.OutputFilePath)}"
                + $".svcpart{index:00}{Path.GetExtension(task.OutputFilePath)}");
        }
        private async Task ProcessSingleCutTask(FFmpegTask task, Engine ffmpeg)
        {
            if (task.Selections == null || task.Selections.Length == 0)
                return;

            var selection = task.Selections.First();
            var ffmpegCutArguments = FFmpegArgumentBuilder.BuildArgumentsSingleCutOperation(
                task.InputFilePath!,
                task.OutputFilePath!,
                selection.Start, selection.End,
                task.Lossless);

            task.State = FFmpegTaskState.InProgress;
            OnPropertyChanged("Tasks");
            CancellationTokenSource taskCts = new CancellationTokenSource();
            await ffmpeg.ExecuteAsync(ffmpegCutArguments, taskCts.Token);
        }
        private async Task ProcessMultipleCutTask(FFmpegTask task, Engine ffmpeg)
        {
            if (task.Selections == null || task.Selections.Length == 0)
                return;

            task.State = FFmpegTaskState.InProgress;
            OnPropertyChanged("Tasks");

            for (int index=0; index < task.Selections.Length; index++)
            {
                var selection = task.Selections[index];
                var ffmpegCutArguments = FFmpegArgumentBuilder.BuildArgumentsSingleCutOperation(
                    task.InputFilePath!,
                    GetPartialOutputPath(task, index+1),
                    selection.Start, selection.End,
                    task.Lossless);
                CancellationTokenSource taskCts = new CancellationTokenSource();
                await ffmpeg.ExecuteAsync(ffmpegCutArguments, taskCts.Token);
            };
        }

        private async void WorkerThread()
        {
            while (!StopRequest)
            {
                FFmpegTask? task = null;
                lock (tasks)
                {
                    task = tasks.FirstOrDefault(t => t.State == FFmpegTaskState.Scheduled);
                    if (task == null)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                }
                bool taskInProgress = false;

                var ffmpeg = new Engine(VideoCutterSettings.Instance.FFmpegPath);

                ffmpeg.Complete += (object? sender, FFmpeg.NET.Events.ConversionCompleteEventArgs e) =>
                {
                    task.State = FFmpegTaskState.FinishedOK;
                    taskInProgress = false;
                    OnPropertyChanged("Tasks");
                    OnTaskProgress(GlobalStrings.TaskProcessor_Done);
                };
                ffmpeg.Error += (object? sender, FFmpeg.NET.Events.ConversionErrorEventArgs e) =>
                {
                    task.State = FFmpegTaskState.FinishedError;
                    task.ErrorMessage = e.Exception.Message;
                    taskInProgress = false;
                    OnPropertyChanged("Tasks");
                    OnTaskProgress($"{GlobalStrings.TaskProcessor_Failure}: " + e.Exception.Message);
                };

                ffmpeg.Progress += (object? sender, FFmpeg.NET.Events.ConversionProgressEventArgs e) =>
                {
                    var msg = string.Format(GlobalStrings.TaskProcessor_Processed, e.ProcessedDuration.TotalSeconds);
                    OnTaskProgress(msg);
                };

                CancellationTokenSource taskCts = new CancellationTokenSource();
                
                var inputFile = new InputFile(task.InputFilePath);
                var metadata = await ffmpeg.GetMetaDataAsync(inputFile, taskCts.Token);

                try
                {
                    if (task.Selections?.Length == 1)
                    {
                        await ProcessSingleCutTask(task, ffmpeg);
                    }
                    else
                    {
                        await ProcessMultipleCutTask(task, ffmpeg);
                    }

                    while (taskInProgress)
                        Task.Delay(100).Wait();

                }
                catch (Exception e)
                {
                    task.State = FFmpegTaskState.FinishedError;
                    task.ErrorMessage = e.Message;
                    OnPropertyChanged("Tasks");
                    OnTaskProgress($"{GlobalStrings.TaskProcessor_Failure}: " + e.Message);
                }
            }
        }
    }

    [Serializable]
    public class FFmpegTaskSelection
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }

    [Serializable]
    public class FFmpegTask
    {
        public string? TaskId { get; set; }
        public string? InputFilePath { get; set; }
        public string? OutputFilePath { get; set; }
        public string? InputFileName { get; set; }
        public FFmpegTaskSelection[]? Selections { get; set; }   
        public long OverallDuration { get; set; }
        public bool Lossless { get; set; }
        public FFmpegTaskState? State { get; set; }
        public string? ErrorMessage { get; set; }


        public string StateLabel
        {
            get
            {
                switch (State)
                {
                    case FFmpegTaskState.Scheduled: return GlobalStrings.TaskProcessor_State_Scheduled;
                    case FFmpegTaskState.InProgress: return GlobalStrings.TaskProcessor_State_InProgress;
                    case FFmpegTaskState.FinishedOK: return GlobalStrings.TaskProcessor_State_FinishedOK;
                    case FFmpegTaskState.FinishedError: return GlobalStrings.TaskProcessor_State_FinishedError;
                    default: return "Unrecognized";
                }
            }
        }
    }

    [Serializable]
    public enum FFmpegTaskState
    {
        Scheduled,
        InProgress,
        FinishedOK,
        FinishedError,
    }

    public class TaskProgressEventArgs : EventArgs
    {
        public string? ProgressText { get; set; }
    }
}
