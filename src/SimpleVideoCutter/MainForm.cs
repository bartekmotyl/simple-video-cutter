using FFmpeg.NET;
using LibVLCSharp.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    public partial class MainForm : Form
    {
        private LibVLC libVLC;
        private string lastDirectory = null;
        private string fileBeingPlayed = null;
        private TaskProcessor taskProcessor = new TaskProcessor();
        private int volume = 100;
        private FormSettings formSettings = new FormSettings();


        private bool EnsureFFmpegConfigured()
        {
            if (VideoCutterSettings.Instance.FFmpegPath == null || !File.Exists(VideoCutterSettings.Instance.FFmpegPath))
            {
                using (var dialog = new FormFFmpegMissingDialog())
                {
                    dialog.Owner = this;
                    dialog.ShowDialog();
                    formSettings.ShowSettingsDialog();
                }

                return false; 
            }
            return true; 
        }
           

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Core.Initialize();
            libVLC = new LibVLC(new string[] { "--play-and-pause" });
            vlcControl1.MediaPlayer = new MediaPlayer(libVLC);
            videoViewHover.MediaPlayer = new MediaPlayer(libVLC);

            vlcControl1.MediaPlayer.MediaChanged += VlcControl1_MediaChanged;
            vlcControl1.MediaPlayer.LengthChanged += VlcControl1_LengthChanged;
            vlcControl1.MediaPlayer.Playing += VlcControl1_Playing;
            vlcControl1.MediaPlayer.Paused += VlcControl1_Paused;
            vlcControl1.MediaPlayer.Stopped += VlcControl1_Stopped;
            vlcControl1.MediaPlayer.PositionChanged += VlcControl1_PositionChanged;
            vlcControl1.MediaPlayer.EndReached += VlcControl1_EndReached;
            vlcControl1.MouseWheel += VlcControl1_MouseWheel;

            vlcControl1.MediaPlayer.EnableMouseInput = false;
            vlcControl1.MediaPlayer.EnableKeyInput = false;

            videoViewHover.MediaPlayer.Volume = 0;
            videoViewHover.MediaPlayer.EnableKeyInput = false; 
            videoViewHover.MediaPlayer.TimeChanged += VideoViewerHover_MediaPlayer_TimeChanged;
            videoViewHover.Visible = false;

            videoCutterTimeline1.SelectionChanged += VideoCutterTimeline1_SelectionChanged; ;
            videoCutterTimeline1.TimelineHover += VideoCutterTimeline1_TimelineHover;
            videoCutterTimeline1.PositionChangeRequest += VideoCutterTimeline1_PositionChangeRequest; ;


            taskProcessor.PropertyChanged += TaskProcessor_PropertyChanged;
            taskProcessor.TaskProgress += TaskProcessor_TaskProgress;
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            VideoCutterSettings.Instance.LoadSettings();
            EnsureFFmpegConfigured();

            taskProcessor.Start();
            EnableButtons();
        }


        private void VlcControl1_EndReached(object sender, EventArgs e)
        {
            var length = (int)vlcControl1.MediaPlayer.Length;
            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = length;
            });
            EnableButtons();
        }

        private void VlcControl1_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            var length = (long)vlcControl1.MediaPlayer.Length;
            var position = (int)(e.Position * length);

            if (videoCutterTimeline1.SelectionEnd != null && position >= videoCutterTimeline1.SelectionEnd)
            {
                if (vlcControl1.MediaPlayer.State == VLCState.Playing)
                {
                    if (vlcControl1.MediaPlayer.IsPlaying)
                    {
                        ThreadPool.QueueUserWorkItem(_ => vlcControl1.MediaPlayer.SetPause(true));
                    }
                }
            }

            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = position;
            });
            EnableButtons();
        }

        private void VlcControl1_LengthChanged(object sender, MediaPlayerLengthChangedEventArgs e)
        {
            var length = vlcControl1.MediaPlayer.Length;
            var time = vlcControl1.MediaPlayer.Time;
            
            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Length = length;
                videoCutterTimeline1.Time = length;
            });
            EnableButtons();
        }

        private void VlcControl1_Stopped(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void VlcControl1_Paused(object sender, EventArgs e)
        {
            var length = vlcControl1.MediaPlayer.Length;
            var position = vlcControl1.MediaPlayer.Position;
            this.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = (int)(position * length);
            });
            EnableButtons();
        }

        private void VlcControl1_MediaChanged(object sender, MediaPlayerMediaChangedEventArgs e)
        {
            var fi = new FileInfo(fileBeingPlayed);
            string fileInfo = string.Format("{0:yyyy/MM/dd HH:mm:ss}", fi.LastWriteTime);
            toolStripStatusLabelFileDate.Text = fileInfo;
            EnableButtons();
        }

        private void VlcControl1_Playing(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void toolStripButtonFileOpen_Click(object sender, EventArgs e)
        {
            if (lastDirectory == null)
            {
                lastDirectory = ReplaceStandardDirectoryPatterns(VideoCutterSettings.Instance.DefaultInitialDirectory);
            }
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.InitialDirectory = lastDirectory;
                fd.RestoreDirectory = true;

                var filter = "All video files|" + string.Join(";", VideoCutterSettings.Instance.VideoFilesExtensions.Select(ex => "*" + ex).ToArray());
                fd.Filter = filter;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    lastDirectory = Path.GetDirectoryName(fd.FileName);
                    OpenFile(fd.FileName);
                }
            }
        }

        private string ReplaceStandardDirectoryPatterns(string str)
        {
            return str
                .Replace("{UserVideos}", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
                .Replace("{UserDocuments}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                .Replace("{MyComputer}", Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
        }
        private string ReplaceFilePatterns(string str, string path)
        {
            var fileInfo = new FileInfo(path);

            return str
                .Replace("{FileName}", Path.GetFileName(path))
                .Replace("{FileNameWithoutExtension}", Path.GetFileNameWithoutExtension(path))
                .Replace("{FileExtension}", Path.GetExtension(path))
                .Replace("{FileDate}", string.Format("{0:yyyyMMdd-HHmmss}", fileInfo.LastWriteTime))
                .Replace("{Timestamp}", string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now));
        }

        private void OpenFile(string path)
        {
            fileBeingPlayed = path;
            toolStripStatusLabelFilePath.Text = path;

            if (vlcControl1.MediaPlayer.IsPlaying)
            {
                ThreadPool.QueueUserWorkItem(_ => vlcControl1.MediaPlayer.Stop());
            }

            ClearSelection();
            UpdateIndexLabel();
            EnableButtons();

            ThreadPool.QueueUserWorkItem(_ => vlcControl1.MediaPlayer.Play(new Media(libVLC, path, FromType.FromPath)));
            ThreadPool.QueueUserWorkItem(_ => videoViewHover.MediaPlayer.Play(new Media(libVLC, path, FromType.FromPath)));
            
        }

        private void vlcControl1_MouseClick(object sender, MouseEventArgs e)
        {
            PlayPause();
        }

        private void PlayPause()
        {
            if (vlcControl1.MediaPlayer.State == VLCState.Ended || vlcControl1.MediaPlayer.State == VLCState.Stopped)
            {
                vlcControl1.MediaPlayer.Play(new Media(libVLC, fileBeingPlayed, FromType.FromPath));
                EnableButtons();
            }
            else
            {
                vlcControl1.MediaPlayer.Pause();
                EnableButtons();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                PlayPause();
            }


            if (e.KeyCode == Keys.S)
                SetStartAtCurrentPosition();

            if (e.KeyCode == Keys.E)
                SetEndAtCurrentPosition();

            if (e.KeyCode == Keys.OemPeriod)
            {
                vlcControl1.MediaPlayer.NextFrame();
                videoCutterTimeline1.InvokeIfRequired(() =>
                {
                    videoCutterTimeline1.Position = (int)(vlcControl1.MediaPlayer.Position * vlcControl1.MediaPlayer.Length);
                });
            }

            if (e.KeyCode == Keys.R && videoCutterTimeline1.SelectionStart != null)
            {
                ThreadPool.QueueUserWorkItem(_ => {
                    vlcControl1.MediaPlayer.Position = (float)videoCutterTimeline1.SelectionStart.Value / vlcControl1.MediaPlayer.Length;
                    vlcControl1.MediaPlayer.SetPause(false);
                });
            }
            
        }

        private void SetStartAtCurrentPosition()
        {
            // SetSelection raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            videoCutterTimeline1.SetSelection(videoCutterTimeline1.Position, videoCutterTimeline1.SelectionEnd);
        }
        private void SetEndAtCurrentPosition()
        {
            if (videoCutterTimeline1.SelectionStart != null)
            {
                // SetSelection raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
                videoCutterTimeline1.SetSelection(videoCutterTimeline1.SelectionStart, videoCutterTimeline1.Position);
            }
        }

        private void VideoCutterTimeline1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionLabel();
            EnableButtons();
        }


        private void toolStripButtonSetStart_Click(object sender, EventArgs e)
        {
            SetStartAtCurrentPosition();
        }

        private void toolStripButtonSetEnd_Click(object sender, EventArgs e)
        {
            SetEndAtCurrentPosition();
        }

        private void TaskProcessor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Tasks")
            {
                listViewTasks.InvokeIfRequired(() =>
                {
                    var tasks = taskProcessor.GetTasks();
                    listViewTasks.Items.Clear();
                    listViewTasks.Items.AddRange(tasks.Select(
                        task =>
                        {
                            var item = new ListViewItem(task.InputFileName);
                            item.SubItems.Add(string.Format("{0} sec", Math.Round(task.Duration / 1000.0f, 1)));
                            return item;
                        }).ToArray());
                });
            }
        }

        private void TaskProcessor_TaskProgress(object sender, TaskProgressEventArgs e)
        {
            labelProgress.InvokeIfRequired(() =>
            {
                labelProgress.Text = e.ProgressText;
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            taskProcessor.StopRequest = true;
        }

        private void toolStripButtonAddTask_Click(object sender, EventArgs e)
        {
            if (videoCutterTimeline1.SelectionStart == null || videoCutterTimeline1.SelectionEnd == null)
            {
                MessageBox.Show("No selection");
                return;
            }

            if (!EnsureFFmpegConfigured())
                return; 

            FileInfo fileInfo = new FileInfo(fileBeingPlayed);
            var outputDir = ReplaceStandardDirectoryPatterns(VideoCutterSettings.Instance.OutputDirectory);
            var outputFileName = ReplaceFilePatterns(VideoCutterSettings.Instance.OutputFilePattern, fileBeingPlayed);
            var outputFilePath = Path.Combine(outputDir, outputFileName);

            var inputFile = new MediaFile(fileInfo.FullName);
            var outputFile = new MediaFile(outputFilePath);


            long selectionStart = videoCutterTimeline1.SelectionStart.Value;
            long selectionEnd = videoCutterTimeline1.SelectionEnd.Value;

            taskProcessor.EnqueueTask(new FFmpegTask()
            {
                InputFilePath = fileInfo.FullName,
                OutputFilePath = outputFilePath,
                InputFileName = fileInfo.Name,
                SelectionStart = selectionStart,
                Duration = selectionEnd - selectionStart,
                TaskId = Guid.NewGuid().ToString(),
            });
            ClearSelection();
        }

        private void ClearSelection()
        {
            // SetSelection raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            videoCutterTimeline1.SetSelection(null, null);
        }
        private void toolStripButtonClearSelection_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private IList<string> GetVideoFilesInDirectory(string currentFilePath)
        {
            var currentDir = Path.GetDirectoryName(currentFilePath);

            var extensions = VideoCutterSettings.Instance.VideoFilesExtensions;
            var allFiles = Directory.EnumerateFiles(currentDir, "*", SearchOption.TopDirectoryOnly);

            var videoFilesArr = allFiles
                .Where(f => extensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                .Select(s => new FileInfo(Path.Combine(currentDir, s)))
                .OrderBy(fi => fi.LastWriteTime)
                .Select(fi => fi.Name.ToLowerInvariant())
                .ToList();

            return videoFilesArr;
        }
        
        private string GetNextPrevFileInDirectory(string currentFilePath, int direction)
        {
            var currentDir = Path.GetDirectoryName(currentFilePath);

            var videoFilesArr = GetVideoFilesInDirectory(currentFilePath);

            int index = videoFilesArr.IndexOf(Path.GetFileName(currentFilePath).ToLowerInvariant());
            if (index < 0)
                return null; // wtf?

            var newIndex = (index + direction + videoFilesArr.Count) % videoFilesArr.Count;

            return Path.Combine(currentDir, videoFilesArr[newIndex]);
        }

        private void toolStripButtonNextFile_Click(object sender, EventArgs e)
        {
            var newFile = GetNextPrevFileInDirectory(fileBeingPlayed, +1);
            if (newFile != null && String.Compare(newFile, fileBeingPlayed, true) != 0)
            {
                OpenFile(newFile);
            }
        }

        private void toolStripButtonPreviousFile_Click(object sender, EventArgs e)
        {
            var newFile = GetNextPrevFileInDirectory(fileBeingPlayed, -1);
            if (newFile != null && String.Compare(newFile, fileBeingPlayed, true) != 0)
            {
                OpenFile(newFile);
            }
        }


        private void VlcControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            volume = volume + (e.Delta/120 * 10);
            if (volume < 0)
                volume = 0;
            else if (volume > 200)
                volume = 200;

            toolStripStatusLabelVolume.Text = string.Format("Volume: {0} %", volume);
            vlcControl1.MediaPlayer.Volume = volume;
        }

        private void UpdateIndexLabel()
        {
            if (fileBeingPlayed == null)
            {
                toolStripStatusLabelIndex.Text = "0/0";
            }
            else
            {
                var videoFilesArr = GetVideoFilesInDirectory(fileBeingPlayed);
                int index = videoFilesArr.IndexOf(Path.GetFileName(fileBeingPlayed).ToLowerInvariant());
                toolStripStatusLabelIndex.Text = string.Format("{0}/{1}", index + 1, videoFilesArr.Count);
            }

        }
        private void UpdateSelectionLabel()
        {
            if (fileBeingPlayed == null)
            {
                toolStripStatusLabelSelection.Text = "No selection";
            }
            else
            {
                if (videoCutterTimeline1.SelectionStart == null || videoCutterTimeline1.SelectionEnd == null)
                {
                    toolStripStatusLabelSelection.Text = "No selection";
                }
                else
                {
                    long timeMs = videoCutterTimeline1.SelectionEnd.Value - videoCutterTimeline1.SelectionStart.Value;
                    toolStripStatusLabelSelection.Text = string.Format("Selection: {0:####.##} s", (float)timeMs/1000.0);
                }
            }

        }

        private void EnableButtons()
        {
            var isFileLoaded = fileBeingPlayed != null;
            var isSelection = !(videoCutterTimeline1.SelectionStart == null || videoCutterTimeline1.SelectionEnd == null);

            toolStrip1.InvokeIfRequired(() =>
           {
               toolStripButtonSetStart.Enabled = isFileLoaded;
               toolStripButtonSetEnd.Enabled = isFileLoaded && videoCutterTimeline1.SelectionStart != null;
               toolStripButtonClearSelection.Enabled = isFileLoaded && isSelection;
               toolStripButtonAddTask.Enabled = isFileLoaded && isSelection;
               toolStripButtonNextFile.Enabled = isFileLoaded;
               toolStripButtonPreviousFile.Enabled = isFileLoaded;
           });
        }

        private void toolStripButtonShowTasks_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !toolStripButtonShowTasks.Checked;
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            formSettings.ShowSettingsDialog();
        }



        private void VideoCutterTimeline1_TimelineHover(object sender, TimelineHoverEventArgs e)
        {
            timerHoverPositionChanged.Start();
        }

        private void timerHoverPositionChanged_Tick(object sender, EventArgs e)
        {
            timerHoverPositionChanged.Stop();
            var pos = videoCutterTimeline1.HoverPosition;
            if (pos != null)
            {
                float posFloat = (float)pos.Value / videoViewHover.MediaPlayer.Length;
                
                videoViewHover.Visible = true;

                int posX = (int)(posFloat * videoCutterTimeline1.Width) - videoViewHover.Width/2;
                posX = Math.Max(posX, 0);
                posX = Math.Min(posX, videoCutterTimeline1.Width - videoViewHover.Width);

                videoViewHover.Location = new Point(
                    posX,
                    videoCutterTimeline1.Location.Y - videoViewHover.Height - 5);

                ThreadPool.QueueUserWorkItem(_ => {
                    videoViewHover.MediaPlayer.Position = posFloat;
                });

            }
            else
            {
                videoViewHover.Visible = false;
            }
        }

        private void VideoViewerHover_MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ => {
                videoViewHover.MediaPlayer.Pause();
            });
        }

        private void VideoCutterTimeline1_PositionChangeRequest(object sender, PositionChangeRequestEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ => {
                vlcControl1.MediaPlayer.Position = (float)e.Position / vlcControl1.MediaPlayer.Length;
            });
            videoCutterTimeline1.Position = e.Position;
        }

    }
}
