using FFmpeg.NET.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleVideoCutter
{
    public class KeyFramesExtractorProgressEventArgs : EventArgs
    {
        public bool Completed { get; set; }
    }

    public class KeyFramesExtractor
    {
        public event EventHandler<KeyFramesExtractorProgressEventArgs>? KeyFramesExtractorProgress;

        public List<long> Keyframes { get; private set; } = new List<long>();
        public bool InProgress { get; set; } = false;

        private CancellationTokenSource? tokenSource;
        private Task? task;


        public void Start(string videoFilePath)
        {
           
            if (task != null)
            {
                tokenSource?.Cancel();
            }
            Keyframes.Clear();
            tokenSource = new CancellationTokenSource();
            task = Task.Run(() => Execute(videoFilePath, tokenSource.Token));
        }

        private string GetFFprobePath()
        {
            return Path.GetDirectoryName(VideoCutterSettings.Instance.FFmpegPath) + Path.DirectorySeparatorChar + "ffprobe.exe";
        }

        private void Execute(string videoFilePath, CancellationToken token)
        {
            var arguments = $"-select_streams v -skip_frame nokey -show_frames -show_entries frame=pkt_pts_time,pict_type,pts_time {videoFilePath}";

            var queue = new ConcurrentQueue<string>();

            DataReceivedEventHandler outputDataReceivedHandler = (object sender, DataReceivedEventArgs ea) =>
            {
                if (ea.Data?.StartsWith("pkt_pts_time") ?? false)
                    queue.Enqueue(ea.Data);
                if (ea.Data?.StartsWith("pts_time") ?? false)
                    queue.Enqueue(ea.Data);
            };
            DataReceivedEventHandler errorDataReceivedHandler = (object sender, DataReceivedEventArgs ea) =>
            {
                Console.WriteLine("ERR: " + ea.Data);
            };
            var startInfo = new ProcessStartInfo(GetFFprobePath(), arguments);
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            using (var ffprobeProcess = new Process() { StartInfo = startInfo, EnableRaisingEvents = true,   })
            {
                
                try
                {
                    ffprobeProcess.OutputDataReceived += outputDataReceivedHandler;
                    ffprobeProcess.ErrorDataReceived += errorDataReceivedHandler;

                    bool started = ffprobeProcess.Start();
                    InProgress = true;
                    if (!started)
                    {
                        //you may allow for the process to be re-used (started = false) 
                        //but I'm not sure about the guarantees of the Exited event in such a case
                        throw new InvalidOperationException("Could not start process: " + ffprobeProcess);
                    }

                    ffprobeProcess.BeginOutputReadLine();
                    ffprobeProcess.BeginErrorReadLine();

                    while (!ffprobeProcess.HasExited || queue.Count > 0)
                    {
                        if (token.IsCancellationRequested && !ffprobeProcess.HasExited)
                        {
                            ffprobeProcess.Kill();
                            token.ThrowIfCancellationRequested();
                        }

                        if (queue.TryDequeue(out var line))
                        {
                            var timestampStr = line.Replace("pkt_pts_time=", "");
                            timestampStr = timestampStr.Replace("pts_time=", "");
                            var timestampFloat = float.Parse(timestampStr, CultureInfo.InvariantCulture);
                            Keyframes.Add((long)(timestampFloat * 1000));
                            if (Keyframes.Count % 10 == 0)
                                OnKeyFramesExtractorProgress(false);
                        } 
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
                finally
                {
                    ffprobeProcess.OutputDataReceived -= outputDataReceivedHandler;
                    ffprobeProcess.ErrorDataReceived -= errorDataReceivedHandler;
                }
                OnKeyFramesExtractorProgress(true);
                InProgress = false;
            }
        }
        private void OnKeyFramesExtractorProgress(bool completed)
        {
            KeyFramesExtractorProgress?.Invoke(this, new KeyFramesExtractorProgressEventArgs()
            {
                Completed = completed,
            });

        }


    }
}
