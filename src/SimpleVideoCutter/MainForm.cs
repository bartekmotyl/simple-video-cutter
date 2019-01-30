using FFmpeg.NET;
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
        private string lastDirectory = null;
        private string fileBeingPlayed = null;
        private TaskProcessor taskProcessor = new TaskProcessor();
        private static VideoCutterSettings videoCutterSettings;
        private int volume = 100;

        public static VideoCutterSettings VideoCutterSettings
        {
            get
            {
                return videoCutterSettings;
            }
        }


        static MainForm()
        {
            var configFile = "config.json";
            videoCutterSettings = null;
            if (File.Exists(configFile))
            {
                var json = File.ReadAllText(configFile);
                try
                {
                    videoCutterSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoCutterSettings>(json);
                }
                catch (Exception)
                {
                }
            }

            if (videoCutterSettings == null)
            {
                videoCutterSettings = new VideoCutterSettings();
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(videoCutterSettings, Formatting.Indented);
                File.WriteAllText(configFile, json);
            }

        }

        public MainForm()
        {
            InitializeComponent();
            vlcControl1.MediaChanged += VlcControl1_MediaChanged;
            vlcControl1.LengthChanged += VlcControl1_LengthChanged;
            vlcControl1.Playing += VlcControl1_Playing;
            vlcControl1.Paused += VlcControl1_Paused;
            vlcControl1.Stopped += VlcControl1_Stopped;
            vlcControl1.PositionChanged += VlcControl1_PositionChanged;
            vlcControl1.EndReached += VlcControl1_EndReached;
            vlcControl1.MouseWheel += VlcControl1_MouseWheel;

            vlcControl1.Video.IsMouseInputEnabled = false;
            vlcControl1.Video.IsKeyInputEnabled = false;

            videoCutterTimeline1.TimelineClicked += VideoCutterTimeline1_TimelineClicked;
            videoCutterTimeline1.MouseWheel += VlcControl1_MouseWheel;

            taskProcessor.PropertyChanged += TaskProcessor_PropertyChanged;
            taskProcessor.TaskProgress += TaskProcessor_TaskProgress;

            taskProcessor.Start();

            EnableButtons();
        }


        private void VideoCutterTimeline1_TimelineClicked(object sender, TimelineClickedEventArgs e)
        {
            if (vlcControl1.VlcMediaPlayer.IsSeekable)
            {
                vlcControl1.VlcMediaPlayer.Time = e.ClickedPosition;
                videoCutterTimeline1.InvokeIfRequired(() =>
                {
                    videoCutterTimeline1.Position = (int)(e.ClickedPosition);
                });
            }
        }

        private void VlcControl1_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = (int)(1.0f * vlcControl1.VlcMediaPlayer.Length);
            });
            EnableButtons();
        }

        private void VlcControl1_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = (int)(e.NewPosition * vlcControl1.VlcMediaPlayer.Length);
            });
            EnableButtons();
        }

        private void VlcControl1_LengthChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs e)
        {
            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Length = (int)vlcControl1.VlcMediaPlayer.Length;
            });
            EnableButtons();
        }

        private void VlcControl1_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            this.InvokeIfRequired(() =>
            {
            });
            EnableButtons();
        }

        private void VlcControl1_Paused(object sender, Vlc.DotNet.Core.VlcMediaPlayerPausedEventArgs e)
        {
            this.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = (int)(vlcControl1.VlcMediaPlayer.Position * vlcControl1.VlcMediaPlayer.Length);
            });
            EnableButtons();
        }

        private void VlcControl1_MediaChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerMediaChangedEventArgs e)
        {
            var fi = new FileInfo(fileBeingPlayed);
            string fileInfo = string.Format("{0:yyyy/MM/dd HH:mm:ss}", fi.LastWriteTime);
            toolStripStatusLabelFileDate.Text = fileInfo;
            EnableButtons();
        }

        private void VlcControl1_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            this.InvokeIfRequired(() =>
            {
            });
            EnableButtons();
        }

        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void toolStripButtonFileOpen_Click(object sender, EventArgs e)
        {
            if (lastDirectory == null)
            {
                lastDirectory = ReplaceStandardDirectoryPatterns(videoCutterSettings.DefaultInitialDirectory);
            }
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.InitialDirectory = lastDirectory;
                fd.RestoreDirectory = true;

                var filter = "All video files|" + string.Join(";", VideoCutterSettings.VideoFilesExtensions.Select(ex => "*" + ex).ToArray());
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
                .Replace("{FileDate}", string.Format("{0:yyyy-MM-dd-HHmmss}", fileInfo.LastWriteTime))
                .Replace("{Timestamp}", string.Format("{0:yyyyMMddHHmmss}", DateTime.Now));
        }

        private void OpenFile(string path)
        {
            fileBeingPlayed = path;
            toolStripStatusLabelFilePath.Text = path;

            if (vlcControl1.VlcMediaPlayer.IsPlaying())
                vlcControl1.VlcMediaPlayer.Stop();

            ClearSelection();
            UpdateIndexLabel();
            EnableButtons();
            vlcControl1.Play(new FileInfo(path));
        }

        private void vlcControl1_MouseClick(object sender, MouseEventArgs e)
        {
            PlayPause();
        }

        private void PlayPause()
        {
            if (vlcControl1.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended || vlcControl1.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Stopped)
            {
                vlcControl1.Play(new FileInfo(fileBeingPlayed));
                EnableButtons();
            }
            else
            {
                vlcControl1.Pause();
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
                vlcControl1.VlcMediaPlayer.NextFrame();
        }

        private void SetStartAtCurrentPosition()
        {
            videoCutterTimeline1.SelectionStart = videoCutterTimeline1.Position;
            UpdateSelectionLabel();
            EnableButtons();
        }
        private void SetEndAtCurrentPosition()
        {
            if (videoCutterTimeline1.SelectionStart != null)
            {
                videoCutterTimeline1.SelectionEnd = videoCutterTimeline1.Position;
                UpdateSelectionLabel();
                EnableButtons();
            }
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

            if (VideoCutterSettings.FFmpegPath == null || !File.Exists(MainForm.VideoCutterSettings.FFmpegPath))
            {
                MessageBox.Show("FFmpeg path not configured. Please edit config.json and restart the program.");
                return;
            }

            FileInfo fileInfo = new FileInfo(fileBeingPlayed);
            var outputDir = ReplaceStandardDirectoryPatterns(VideoCutterSettings.OutputDirectory);
            var outputFileName = ReplaceFilePatterns(VideoCutterSettings.OutputFilePattern, fileBeingPlayed);
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
            videoCutterTimeline1.SelectionEnd = null;
            videoCutterTimeline1.SelectionStart = null;
            UpdateSelectionLabel();
            EnableButtons();
        }
        private void toolStripButtonClearSelection_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private IList<string> GetVideoFilesInDirectory(string currentFilePath)
        {
            var currentDir = Path.GetDirectoryName(currentFilePath);

            var extensions = MainForm.VideoCutterSettings.VideoFilesExtensions;
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
            vlcControl1.VlcMediaPlayer.Audio.Volume = volume;
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
    }
}
