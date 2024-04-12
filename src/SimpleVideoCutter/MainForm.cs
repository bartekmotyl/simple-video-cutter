using FFmpeg.NET;
using LibVLCSharp.Shared;
using Newtonsoft.Json;
using SimpleVideoCutter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    [SupportedOSPlatform("windows")]
    public partial class MainForm : Form
    {
        private LibVLC? libVLC;
        private string? lastDirectory = null;
        private string? fileBeingPlayed = null;
        private TaskProcessor taskProcessor = new TaskProcessor();
        private KeyFramesExtractor keyFramesExtractor = new KeyFramesExtractor();
        private int volume = 100;
        private FormSettings formSettings;
        private string? fileToLoadOnStartup = null;
        private Debouncer debouncerHover = new Debouncer();
        private bool playingSelection = false;

        private bool EnsureFFmpegConfigured()
        {
            if (VideoCutterSettings.Instance.FFmpegPath == null || !File.Exists(VideoCutterSettings.Instance.FFmpegPath))
            {
                using (var dialog = new FormFFmpegMissingDialog())
                {
                    dialog.Owner = this;
                    dialog.ShowDialog();
                    if (VideoCutterSettings.Instance.FFmpegPath == null || !File.Exists(VideoCutterSettings.Instance.FFmpegPath))
                    {
                        formSettings.ShowSettingsDialog();
                    }
                }

                return false;
            }
            return true;
        }


        public MainForm(string? fileToLoadOnStartup, string configFolder)
        {
            this.fileToLoadOnStartup = fileToLoadOnStartup;
            VideoCutterSettings.Instance.ConfigFolder = configFolder;
            VideoCutterSettings.Instance.LoadSettings();

            if (VideoCutterSettings.Instance.Language == null)
            {
                VideoCutterSettings.Instance.Language = Thread.CurrentThread.CurrentUICulture.Name;
            }
            else
            {
                var culture = CultureInfo.GetCultureInfo(VideoCutterSettings.Instance.Language);
                if (culture != null)
                {
                    Thread.CurrentThread.CurrentUICulture = culture;
                    CultureInfo.DefaultThreadCurrentUICulture = culture;
                }
            }

            formSettings = new FormSettings();

            InitializeComponent();

            toolStripButtonSelectionEnqueue.Text = GlobalStrings.MainForm_ButtonCut;

            this.toolStripContainerMain.TopToolStripPanel.Controls.Clear();
            this.toolStripContainerMain.TopToolStripPanel.Join(toolStripInternet, 0);
            this.toolStripContainerMain.TopToolStripPanel.Join(toolStripTasks, 0);
            this.toolStripContainerMain.TopToolStripPanel.Join(toolStripPlayback, 0);
            this.toolStripContainerMain.TopToolStripPanel.Join(toolStripFile, 0);
            this.toolStripContainerMain.LeftToolStripPanel.Controls.Clear();
            this.toolStripContainerMain.LeftToolStripPanel.Join(toolStripTimeline);
            this.toolStripContainerMain.LeftToolStripPanel.Join(toolStripSelection);



            if (VideoCutterSettings.Instance.MainWindowLocation != Rectangle.Empty)
            {
                var location = VideoCutterSettings.Instance.MainWindowLocation.Location;
                var size = VideoCutterSettings.Instance.MainWindowLocation.Size;
                if (Utils.IsOnScreen(location, size))
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = VideoCutterSettings.Instance.MainWindowLocation.Location;
                    this.Size = VideoCutterSettings.Instance.MainWindowLocation.Size;
                }
            }
            if (VideoCutterSettings.Instance.MainWindowMaximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.videoViewHover.Visible = VideoCutterSettings.Instance.ShowPreview;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            Core.Initialize();

            // Full list of command line arguments: https://wiki.videolan.org/VLC_command-line_help

            var args = new List<string>(new string[] {
                "--play-and-pause",
                "--no-sub-autodetect-file",
            });

            if (!VideoCutterSettings.Instance.Autostart)
            {
                args.Add("--no-playlist-autostart");
                args.Add("--start-paused");
            }

            libVLC = new LibVLC(args.ToArray());

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
            vlcControl1.MediaPlayer.TimeChanged += VlcControl1_TimeChanged;
            vlcControl1.MediaPlayer.EnableMouseInput = false;
            vlcControl1.MediaPlayer.EnableKeyInput = false;

            videoViewHover.MediaPlayer.Volume = 0;
            videoViewHover.MediaPlayer.EnableKeyInput = false;
            videoViewHover.MediaPlayer.TimeChanged += VideoViewerHover_MediaPlayer_TimeChanged;
            videoViewHover.Visible = false;

            videoCutterTimeline1.SelectionChanged += VideoCutterTimeline1_SelectionChanged;
            videoCutterTimeline1.TimelineHover += VideoCutterTimeline1_TimelineHover;
            videoCutterTimeline1.PositionChangeRequest += VideoCutterTimeline1_PositionChangeRequest;
            videoCutterTimeline1.KeyframesRequest += VideoCutterTimeline1_KeyframesRequest;

            taskProcessor.PropertyChanged += TaskProcessor_PropertyChanged;
            taskProcessor.TaskProgress += TaskProcessor_TaskProgress;
            keyFramesExtractor.KeyFramesExtractorProgress += KeyFramesExtractor_KeyFramesExtractorProgress;

            if (VideoCutterSettings.Instance.RestoreToolbarsLayout)
                ToolStripManager.LoadSettings(this, "SimpleVideoCutterMainForm");

            VideoCutterSettings.Instance.RestoreToolbarsLayout = true;

            Updater.Instance.PropertyChanged += (object? sender, PropertyChangedEventArgs e) =>
            {
                if (Updater.Instance.NewVersionAvailable || Updater.Instance.NewVersionDownloaded)
                {
                    toolStripInternet.InvokeIfRequired(() =>
                    {
                        toolStripButtonInternetVersionCheck.ForeColor = Color.Red;
                    });
                }
            };

            Updater.Instance.StartCheckingVersion();
            ResizePreview();
        }



        private void MainForm_Shown(object? sender, EventArgs e)
        {
            if (VideoCutterSettings.Instance.LastVersion != Utils.GetCurrentRelease())
            {
                var welcomeDialog = new WelcomeDialog();
                welcomeDialog.ShowDialog();
            }

            EnsureFFmpegConfigured();

            taskProcessor.Start();
            EnableButtons();

            if (fileToLoadOnStartup != null)
            {
                OpenFile(fileToLoadOnStartup);
            }
        }


        private void VlcControl1_EndReached(object? sender, EventArgs e)
        {
            var length = (int)vlcControl1.MediaPlayer!.Length;
            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = length;
            });
            EnableButtons();
        }

        private void VlcControl1_PositionChanged(object? sender, MediaPlayerPositionChangedEventArgs e)
        {
            AckPositionChange((long)(e.Position * vlcControl1.MediaPlayer!.Length));
        }

        private void AckPositionChange(long position)
        {
            var length = (long)vlcControl1.MediaPlayer!.Length;

            if (!videoCutterTimeline1.Selections.Empty && playingSelection)
            {
                long? adjustedPosition = videoCutterTimeline1.Selections.FindNextValidPosition(position);
                if (adjustedPosition == null)
                {
                    if (vlcControl1.MediaPlayer.IsPlaying)
                    {
                        vlcControl1.MediaPlayer.SetPause(true);
                        vlcControl1.MediaPlayer.Position = (float)videoCutterTimeline1.Selections.OverallEnd!.Value / vlcControl1.MediaPlayer.Length;
                    }
                }
                else if (adjustedPosition.Value != position)
                {
                    position = adjustedPosition.Value;
                    var mediaPlayerPosition = (float)position / vlcControl1.MediaPlayer.Length;
                    if (mediaPlayerPosition != vlcControl1.MediaPlayer.Position)
                    {
                        vlcControl1.MediaPlayer.Position = mediaPlayerPosition;
                    }
                }
            }

            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = position;
            });
            EnableButtons();
        }

        private void VlcControl1_LengthChanged(object? sender, MediaPlayerLengthChangedEventArgs e)
        {
            var length = vlcControl1.MediaPlayer!.Length;
            var time = vlcControl1.MediaPlayer.Time;

            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Length = length;
            });
            EnableButtons();
        }

        private void VlcControl1_Stopped(object? sender, EventArgs e)
        {
            playingSelection = false;
            EnableButtons();
        }

        private void VlcControl1_Paused(object? sender, EventArgs e)
        {
            playingSelection = false;
            var length = vlcControl1.MediaPlayer!.Length;
            var position = vlcControl1.MediaPlayer.Position;
            this.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = (int)(position * length);
            });
            EnableButtons();
        }

        private void VlcControl1_MediaChanged(object? sender, MediaPlayerMediaChangedEventArgs e)
        {
            string fileInfo = fileBeingPlayed != null ?
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", new FileInfo(fileBeingPlayed).LastWriteTime)
                : "N/A"; 
            statusStrip.InvokeIfRequired(() =>
            {
                toolStripStatusLabelFileDate.Text = fileInfo;
            });
            EnableButtons();

        }

        private void VlcControl1_Playing(object? sender, EventArgs e)
        {
            EnableButtons();
        }

        private void OpenFile()
        {
            if (lastDirectory == null)
            {
                lastDirectory = ReplaceStandardDirectoryPatterns(VideoCutterSettings.Instance.DefaultInitialDirectory);
            }
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.InitialDirectory = lastDirectory;
                fd.RestoreDirectory = true;

                var filter = $"{GlobalStrings.MainForm_AllVideoFiles}|" + string.Join(";", VideoCutterSettings.Instance.VideoFilesExtensions.Select(ex => "*" + ex).ToArray());
                fd.Filter = filter;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    lastDirectory = Path.GetDirectoryName(fd.FileName)!;
                    OpenFile(fd.FileName);
                }
            }
        }

        private string ReplaceStandardDirectoryPatterns(string str)
        {
            return str
                .Replace("{SameFolder}", Path.GetDirectoryName(fileBeingPlayed))
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
                .Replace("{Timestamp}", string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now))
                .Replace("{SelectionStart}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(this.videoCutterTimeline1.Selections.OverallStart!.Value)))
                .Replace("{SelectionEnd}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(this.videoCutterTimeline1.Selections.OverallEnd!.Value)))
                .Replace("{SelectionStartMs}", string.Format("{0}", this.videoCutterTimeline1.Selections.OverallStart.Value))
                .Replace("{SelectionEndMs}", string.Format("{0}", this.videoCutterTimeline1.Selections.OverallEnd.Value))
                .Replace("{Duration}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(this.videoCutterTimeline1.Selections.OverallDuration)));
        }

        private void OpenFile(string path)
        {
            if (!File.Exists(path))
                return;
            fileBeingPlayed = path;
            statusStrip.InvokeIfRequired(() =>
            {
                toolStripStatusLabelFilePath.Text = path;
            });

            if (vlcControl1.MediaPlayer!.IsPlaying)
            {
                vlcControl1.MediaPlayer.Stop();
            }

            ClearAllSelections();
            UpdateIndexLabel();
            EnableButtons();

            vlcControl1.MediaPlayer.Mute = VideoCutterSettings.Instance.Mute;
            vlcControl1.MediaPlayer.Play(new Media(libVLC!, path, FromType.FromPath));
            videoViewHover.MediaPlayer!.Play(new Media(libVLC!, path, FromType.FromPath));

            keyFramesExtractor.Start(path);
        }

        private void vlcControl1_MouseClick(object? sender, MouseEventArgs e)
        {
            PlayPause();
        }

        private void PlayPause()
        {
            if (vlcControl1.MediaPlayer!.State == VLCState.Ended || vlcControl1.MediaPlayer.State == VLCState.Stopped)
            {
                if (fileBeingPlayed != null)
                    vlcControl1.MediaPlayer.Play(new Media(libVLC!, fileBeingPlayed, FromType.FromPath));
                EnableButtons();
            }
            else
            {
                vlcControl1.MediaPlayer.Pause();
                EnableButtons();
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.L || e.KeyCode == Keys.K)
            {
                PlayPause();
            }


            if (e.KeyCode == Keys.OemOpenBrackets && e.Modifiers == Keys.None)
                SetStartAtCurrentPosition();

            if (e.KeyCode == Keys.OemOpenBrackets && e.Modifiers == Keys.Shift)
                SetSelectionAtCurrentPositionTillTheEnd();

            if (e.KeyCode == Keys.OemCloseBrackets && e.Modifiers == Keys.None)
                SetEndAtCurrentPosition();

            if (e.KeyCode == Keys.OemCloseBrackets && e.Modifiers == Keys.Shift)
                SetSelectionFromTheBeginningTillCurrentPosition();

            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.None)
                ClearCurrentSelection();

            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
                ClearAllSelections();

            if (e.KeyCode == Keys.E && (e.Modifiers == Keys.None || e.Modifiers == Keys.Shift))
                this.EnqeueNewTask();

            if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
                this.OpenFile();

            if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt)
                this.OpenNextFileInDirectory();

            if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt)
                this.OpenPrevFileInDirectory();

            if (e.KeyCode == Keys.T && e.Modifiers == Keys.None)
                toolStripButtonTasksShow.Checked = !toolStripButtonTasksShow.Checked;

            if (e.KeyCode == Keys.D0 && e.Modifiers == Keys.None)
                this.videoCutterTimeline1.ZoomOut();

            if (e.KeyCode == Keys.D9 && e.Modifiers == Keys.None)
                this.videoCutterTimeline1.ZoomAuto();

            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
                this.videoCutterTimeline1.GoToCurrentPosition();

            if (e.KeyCode == Keys.OemOpenBrackets && e.Modifiers == Keys.Control)
                GoToSelectionStart();

            if (e.KeyCode == Keys.OemCloseBrackets && e.Modifiers == Keys.None)
                GoToSelectionEnd();

            if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
                Mute();

            if (e.KeyCode == Keys.OemPeriod && e.Modifiers == Keys.None)
                NextFrame();
            if (e.KeyCode == Keys.Oemcomma && e.Modifiers == Keys.None)
                PrevFrame();

            if (e.Modifiers == Keys.None && e.KeyCode == Keys.R)
                PlaySelection();

            if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
                System.Diagnostics.Process.Start("notepad.exe", VideoCutterSettings.Instance.ConfigPath);

            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
                AdjustSelectionsToKeyframes();
        }
        private void NextFrame()
        {
            if (fileBeingPlayed != null && vlcControl1.MediaPlayer != null)
            {
                vlcControl1.MediaPlayer.NextFrame();
                videoCutterTimeline1.InvokeIfRequired(() =>
                {
                    videoCutterTimeline1.Position = (int)(vlcControl1.MediaPlayer.Position * vlcControl1.MediaPlayer.Length);
                });
            }
        }

        private void PrevFrame()
        {
            if (fileBeingPlayed != null && vlcControl1.MediaPlayer != null)
            {
                float fps = vlcControl1.MediaPlayer.Fps;
                if (fps == 0)
                {
                    fps = 25;
                }
                float currentTimeMs = vlcControl1.MediaPlayer.Position * vlcControl1.MediaPlayer.Length;
                // It doesn;t work weel if we jump by 1 frame thus we jump by free frames
                // Better than nothing.. See more in issue #15
                float newTimeMs = currentTimeMs - 1000 * 3 / fps;
                vlcControl1.MediaPlayer.SeekTo(TimeSpan.FromMilliseconds(newTimeMs));
                videoCutterTimeline1.InvokeIfRequired(() =>
                {
                    videoCutterTimeline1.Position = (long)newTimeMs;
                });
            }
        }

        private void SetStartAtCurrentPosition()
        {
            // RegisterNewSelectionStart raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            videoCutterTimeline1.RegisterNewSelectionStart(videoCutterTimeline1.Position);
        }
        private void SetEndAtCurrentPosition()
        {
            // RegisterNewSelectionEnd raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            videoCutterTimeline1.RegisterNewSelectionEnd(videoCutterTimeline1.Position);
        }

        private void SetSelectionAtCurrentPositionTillTheEnd()
        {
            MessageBox.Show("TODO");
            // SetSelection raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            //videoCutterTimeline1.SetSelection(videoCutterTimeline1.Position, videoCutterTimeline1.Length);
        }

        private void SetSelectionFromTheBeginningTillCurrentPosition()
        {
            MessageBox.Show("TODO");
            // SetSelection raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            //videoCutterTimeline1.SetSelection(0, videoCutterTimeline1.Position);
        }

        private void GoToSelectionStart()
        {
            if (videoCutterTimeline1.Selections.OverallStart != null)
            {
                var position = videoCutterTimeline1.Selections.OverallStart.Value;
                vlcControl1.MediaPlayer!.Position = (float)position / vlcControl1.MediaPlayer.Length;
                videoCutterTimeline1.GoToPosition(position);
                AckPositionChange(position);
            }
        }

        private void GoToSelectionEnd()
        {
            if (videoCutterTimeline1.Selections.OverallEnd != null)
            {
                var position = videoCutterTimeline1.Selections.OverallEnd.Value;
                vlcControl1.MediaPlayer!.Position = (float)position / vlcControl1.MediaPlayer.Length;
                videoCutterTimeline1.GoToPosition(position);
                AckPositionChange(position);
            }
        }

        private void VideoCutterTimeline1_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionLabel();
            EnableButtons();
        }


        private void RefreshTasks()
        {
            listViewTasks.InvokeIfRequired(() =>
            {
                var tasks = taskProcessor.GetTasks().Reverse();

                listViewTasks.Items.Clear();
                listViewTasks.Items.AddRange(tasks.Select(
                    task =>
                    {
                        var item = new ListViewItem(task.StateLabel);
                        item.SubItems.Add(string.Format("{0}", task.Lossless ?
                            GlobalStrings.MainForm_Lossless : GlobalStrings.MainForm_ReEncoding));
                        item.SubItems.Add(string.Format("{0}", task.InputFileName));
                        item.SubItems.Add(string.Format("{0} sec", Math.Round(task.OverallDuration / 1000.0f, 1)));
                        item.SubItems.Add(string.Format("{0}", task.OutputFilePath));
                        item.SubItems.Add(string.Format("{0}", task.ErrorMessage));
                        if (task.State == FFmpegTaskState.FinishedError)
                            item.BackColor = Color.Tomato;
                        return item;
                    }).ToArray());

                listViewTasks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                columnStatus.Width = 80;
            });
        }
        private void TaskProcessor_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Tasks")
            {
                RefreshTasks();
            }
        }

        private void TaskProcessor_TaskProgress(object? sender, TaskProgressEventArgs e)
        {
            labelProgress.InvokeIfRequired(() =>
            {
                labelProgress.Text = e.ProgressText;
            });
        }


        private void KeyFramesExtractor_KeyFramesExtractorProgress(object? sender, KeyFramesExtractorProgressEventArgs e)
        {
            Action safeRefresh = delegate { videoCutterTimeline1.Refresh(); };
            videoCutterTimeline1.Invoke(safeRefresh);
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            taskProcessor.StopRequest = true;
            StoreSettings();
        }

        private void StoreSettings()
        {
            VideoCutterSettings.Instance.MainWindowLocation = new Rectangle(Location, Size);
            VideoCutterSettings.Instance.MainWindowMaximized = WindowState == FormWindowState.Maximized;
            ToolStripManager.SaveSettings(this, "SimpleVideoCutterMainForm");
            VideoCutterSettings.Instance.StoreSettings();
        }

        private void EnqeueNewTask()
        {
            if (videoCutterTimeline1.Selections.Count == 0)
            {
                return;
            }

            if (!EnsureFFmpegConfigured())
                return;
            if (fileBeingPlayed == null)
                return;

            FileInfo fileInfo = new FileInfo(fileBeingPlayed);
            var outputDir = ReplaceStandardDirectoryPatterns(VideoCutterSettings.Instance.OutputDirectory);
            var outputFileName = ReplaceFilePatterns(VideoCutterSettings.Instance.OutputFilePattern, fileBeingPlayed);
            var outputFilePath = Path.Combine(outputDir, outputFileName);
            var fileExtension = Path.GetExtension(outputFilePath);

            var knownExtension = VideoCutterSettings.Instance.VideoFilesExtensions.Any(ext => ext.ToLower() == fileExtension.ToLower());
            if (!knownExtension || string.IsNullOrEmpty(Path.GetExtension(outputFilePath)))
            {
                outputFilePath += Path.GetExtension(fileBeingPlayed);
            }

            var selections = videoCutterTimeline1.Selections.AllSelections.Select(s => new FFmpegTaskSelection()
            {
                Start = TimeSpan.FromMilliseconds(s.Start),
                End = TimeSpan.FromMilliseconds(s.End - 100),
            }).ToArray();

            var selectionsOnKeyFrames = videoCutterTimeline1.AreSelectionsOnKeyFrames;
            FFmpegTask task = new FFmpegTask()
            {
                InputFilePath = fileInfo.FullName,
                OutputFilePath = outputFilePath,
                InputFileName = fileInfo.Name,
                Selections = selections,
                OverallDuration = videoCutterTimeline1.Selections.OverallDuration,
                TaskId = Guid.NewGuid().ToString(),
                Lossless = selectionsOnKeyFrames,
                State = FFmpegTaskState.Scheduled,
            };

            bool shiftPressed = ModifierKeys == Keys.Shift;
            if (VideoCutterSettings.Instance.ShowTaskWindow || shiftPressed || !selectionsOnKeyFrames)
            {

                using (var addTaskDialog = new FormAddTask(task, selectionsOnKeyFrames))
                {
                    var result = addTaskDialog.ShowDialog(this);
                    if (result == DialogResult.Retry)
                    {
                        videoCutterTimeline1.AdjustSelectionsToKeyFrames();
                        return;
                    }
                    else if (result != DialogResult.OK)
                    {
                        return;
                    }

                    task = addTaskDialog.Task;
                }
            }

            VideoCutterSettings.Instance.ShowTaskWindow = false;

            taskProcessor.EnqueueTask(task);
            if (!VideoCutterSettings.Instance.KeepSelectionAfterCut)
            {
                ClearAllSelections();
            }
            toolStripButtonTasksShow.Checked = true;
        }

        private void ClearAllSelections()
        {
            // Selections.Clear raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            videoCutterTimeline1.Selections.Clear();
        }
        private void ClearCurrentSelection()
        {
            var pos = videoCutterTimeline1.Position;
            var currSelectionIndex = videoCutterTimeline1.Selections.IsInSelection(pos);
            if (currSelectionIndex != null)
            {
                videoCutterTimeline1.Selections.DeleteSelection(currSelectionIndex.Value);
            }

        }

        private IList<string> GetVideoFilesInDirectory(string currentFilePath)
        {
            var currentDir = Path.GetDirectoryName(currentFilePath);
            if (currentDir == null)
                return new List<string>();

            var extensions = VideoCutterSettings.Instance.VideoFilesExtensions;
            var allFiles = Directory.EnumerateFiles(currentDir, "*", SearchOption.TopDirectoryOnly);

            var videoFilesArr = allFiles
                .Where(f => extensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                .Select(s => new FileInfo(Path.Combine(currentDir, s)))
                .OrderBy(fi => fi.LastWriteTime)
                .Select(fi => fi.Name)
                .ToList();

            return videoFilesArr;
        }

        private string? GetNextPrevFileInDirectory(string currentFilePath, int direction)
        {
            var currentDir = Path.GetDirectoryName(currentFilePath);
            if (currentDir == null)
                return null; // wtf?

            var videoFilesArr = GetVideoFilesInDirectory(currentFilePath);

            int index = videoFilesArr
                .TakeWhile(f => f.ToLowerInvariant() != Path.GetFileName(currentFilePath).ToLowerInvariant())
                .Count();
            if (index == videoFilesArr.Count)
                return null; // wtf?

            var newIndex = (index + direction + videoFilesArr.Count) % videoFilesArr.Count;

            return Path.Combine(currentDir, videoFilesArr[newIndex]);
        }


        private void VlcControl1_MouseWheel(object? sender, MouseEventArgs e)
        {
            volume = volume + (e.Delta / 120 * 10);
            if (volume < 0)
                volume = 0;
            else if (volume > 200)
                volume = 200;

            statusStrip.InvokeIfRequired(() =>
            {
                toolStripStatusLabelVolume.Text = $"{GlobalStrings.MainForm_Volume}: {volume} %";
            });
            
            vlcControl1.MediaPlayer!.Volume = volume;
        }

        private void UpdateIndexLabel()
        {
            if (fileBeingPlayed == null)
            {
                statusStrip.InvokeIfRequired(() =>
                {
                    toolStripStatusLabelIndex.Text = "0/0";
                });
            }
            else
            {
                var videoFilesArr = GetVideoFilesInDirectory(fileBeingPlayed);
                int index = videoFilesArr.IndexOf(Path.GetFileName(fileBeingPlayed).ToLowerInvariant());
                statusStrip.InvokeIfRequired(() =>
                {
                    toolStripStatusLabelIndex.Text = string.Format("{0}/{1}", index + 1, videoFilesArr.Count);
                });
            }

        }
        private void UpdateSelectionLabel()
        {
            if (fileBeingPlayed == null)
            {
                statusStrip.InvokeIfRequired(() =>
                {
                    toolStripStatusLabelSelection.Text = GlobalStrings.MainForm_NoSelection;
                });
            }
            else
            {
                if (videoCutterTimeline1.Selections.Count == 0)
                {
                    statusStrip.InvokeIfRequired(() =>
                    {
                        toolStripStatusLabelSelection.Text = GlobalStrings.MainForm_NoSelection;
                    });
                }
                else
                {
                    long timeMs = videoCutterTimeline1.Selections.OverallDuration;
                    statusStrip.InvokeIfRequired(() =>
                    {
                        toolStripStatusLabelSelection.Text = string.Format("{0}: {1:####.##} s", GlobalStrings.MainForm_Selection, (float)timeMs / 1000.0);
                    });
                }
            }

        }

        private void EnableButtons()
        {
            var isFileLoaded = fileBeingPlayed != null;
            var isSelection = videoCutterTimeline1.Selections.Count > 0;
            var isPlaying = isFileLoaded && vlcControl1.MediaPlayer!.IsPlaying;

            toolStripPlayback.InvokeIfRequired(() =>
            {
                toolStripButtonPlabackPlayPause.Enabled = isFileLoaded;
                toolStripButtonPlabackPrevFrame.Enabled = isFileLoaded;
                toolStripButtonPlabackNextFrame.Enabled = isFileLoaded;
                toolStripButtonPlabackPlayPause.Image = isPlaying ? Resources.streamline_icon_controls_pause_32x32 : Resources.streamline_icon_controls_play_32x32;
                toolStripButtonPlabackMute.Checked = VideoCutterSettings.Instance.Mute;
            });

            toolStripFile.InvokeIfRequired(() =>
            {
                toolStripButtonFileNext.Enabled = isFileLoaded;
                toolStripButtonFilePrev.Enabled = isFileLoaded;
            });

            toolStripSelection.InvokeIfRequired(() =>
            {
                toolStripButtonSelectionSetStart.Enabled = isFileLoaded;
                toolStripButtonSelectionSetEnd.Enabled = isFileLoaded && videoCutterTimeline1.NewSelectionStartRegistered;
                toolStripButtonSelectionGoToStart.Enabled = isSelection;
                toolStripButtonSelectionGoToEnd.Enabled = isSelection;
                toolStripButtonSelectionPlay.Enabled = isSelection;

                toolStripButtonSelectionClear.Enabled = isFileLoaded && isSelection;
                toolStripButtonSelectionEnqueue.Enabled = isFileLoaded && isSelection;
            });

            toolStripTasks.InvokeIfRequired(() =>
            {
            });

            toolStripTimeline.InvokeIfRequired(() =>
            {
                toolStripButtonTimelineZoomOut.Enabled = isFileLoaded;
                toolStripButtonTimelineZoomAuto.Enabled = isFileLoaded;
                toolStripButtonTimelineGoToCurrentPosition.Enabled = isFileLoaded;
            });

        }

        private void toolStripButtonShowTasks_CheckedChanged(object? sender, EventArgs e)
        {
            ShowHideTasks();
        }

        private void ShowHideTasks()
        {
            RefreshTasks();
            splitContainer1.Panel2Collapsed = !toolStripButtonTasksShow.Checked;
        }

        private void VideoCutterTimeline1_TimelineHover(object? sender, TimelineHoverEventArgs e)
        {
            timerHoverPositionChanged.Start();
        }

        private void ResizePreview()
        {
            int width = 800;
            switch (VideoCutterSettings.Instance.PreviewSize)
            {
                case PreviewSize.XS: width = 200; break;
                case PreviewSize.S: width = 400; break;
                case PreviewSize.L: width = 800; break;
                case PreviewSize.XL: width = 1200; break;
            }
            float scale = 1920.0f / 1080.0f;
            videoViewHover.Width = width;
            videoViewHover.Height = (int)(width / scale);
        }

        private void timerHoverPositionChanged_Tick(object? sender, EventArgs e)
        {
            timerHoverPositionChanged.Stop();
            var pos = videoCutterTimeline1.HoverPosition;
            if (pos != null)
            {
                float posFloat = (float)pos.Value / videoViewHover.MediaPlayer!.Length;

                videoViewHover.Visible = VideoCutterSettings.Instance.PreviewSize != PreviewSize.None && true;

                int posX = videoCutterTimeline1.PositionToPixel(pos) - videoViewHover.Width / 2;
                posX = Math.Max(posX, 0);
                posX = Math.Min(posX, videoCutterTimeline1.Width - videoViewHover.Width);

                videoViewHover.Location = new Point(
                    posX,
                    videoCutterTimeline1.Location.Y - videoViewHover.Height - 5);

                debouncerHover.Debounce(() =>
                {
                    // see  popup preview area is freeze unexpectedly #47 
                    ThreadPool.QueueUserWorkItem((state) => videoViewHover.MediaPlayer!.Position = posFloat);
                }, 100);
            }
            else
            {
                videoViewHover.Visible = false;
            }
        }

        private void VideoViewerHover_MediaPlayer_TimeChanged(object? sender, MediaPlayerTimeChangedEventArgs e)
        {
            if (videoViewHover.MediaPlayer!.IsPlaying)
                videoViewHover.MediaPlayer.Pause();
        }

        private void VlcControl1_TimeChanged(object? sender, MediaPlayerTimeChangedEventArgs e)
        {
        }

        private void VideoCutterTimeline1_PositionChangeRequest(object? sender, PositionChangeRequestEventArgs e)
        {
            vlcControl1.MediaPlayer!.Position = (float)e.Position / vlcControl1.MediaPlayer.Length;
            videoCutterTimeline1.Position = e.Position;
        }

        private void VideoCutterTimeline1_KeyframesRequest(object? sender, KeyframesRequestEventArgs e)
        {
            e.Keyframes = keyFramesExtractor.Keyframes;
            e.InProgress = keyFramesExtractor.InProgress;
        }


        private void Mute()
        {
            VideoCutterSettings.Instance.Mute = !VideoCutterSettings.Instance.Mute;
            vlcControl1.MediaPlayer!.Mute = VideoCutterSettings.Instance.Mute;
            EnableButtons();
        }

        private void PlaySelection()
        {
            if (videoCutterTimeline1.Selections.OverallStart == null)
                return;
            playingSelection = true;
            vlcControl1.MediaPlayer!.Position = (float)videoCutterTimeline1.Selections.OverallStart.Value / vlcControl1.MediaPlayer!.Length;
            vlcControl1.MediaPlayer!.SetPause(false);
        }

        private void AdjustSelectionsToKeyframes()
        {
            if (keyFramesExtractor.InProgress)
            {
                MessageBox.Show(GlobalStrings.MainForm_KeyFramesNotLoaded, GlobalStrings.GlobalInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void toolStripPlayback_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripButtonPlabackPlayPause)
            {
                PlayPause();
            }
            else if (e.ClickedItem == toolStripButtonPlabackMute)
            {
                Mute();
            }
            else if (e.ClickedItem == toolStripButtonPlabackNextFrame)
            {
                NextFrame();
            }
            else if (e.ClickedItem == toolStripButtonPlabackPrevFrame)
            {
                PrevFrame();
            }
        }

        private void toolStripSelection_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripButtonSelectionSetStart)
            {
                if (ModifierKeys == Keys.Shift)
                    SetSelectionAtCurrentPositionTillTheEnd();
                else
                    SetStartAtCurrentPosition();
            }
            else if (e.ClickedItem == toolStripButtonSelectionSetEnd)
            {
                if (ModifierKeys == Keys.Shift)
                    SetSelectionFromTheBeginningTillCurrentPosition();
                else
                    SetEndAtCurrentPosition();
            }
            else if (e.ClickedItem == toolStripButtonSelectionPlay)
            {
                PlaySelection();
            }
            else if (e.ClickedItem == toolStripButtonSelectionClear)
            {
                ClearAllSelections();
            }
            else if (e.ClickedItem == toolStripButtonSelectionGoToStart)
            {
                GoToSelectionStart();
            }
            else if (e.ClickedItem == toolStripButtonSelectionGoToEnd)
            {
                GoToSelectionEnd();
            }
            else if (e.ClickedItem == toolStripButtonSelectionEnqueue)
            {
                EnqeueNewTask();
            }
        }

        private void toolStripInternet_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripButtonInternetVersionCheck)
            {
                using (var about = new AboutBox())
                {
                    about.ShowDialog();
                }
            }
        }

        private void OpenNextFileInDirectory()
        {
            if (fileBeingPlayed != null)
            {
                var newFile = GetNextPrevFileInDirectory(fileBeingPlayed, +1);
                if (newFile != null && String.Compare(newFile, fileBeingPlayed, true) != 0)
                {
                    OpenFile(newFile);
                }
            }
        }
        private void OpenPrevFileInDirectory()
        {
            if (fileBeingPlayed != null)
            {
                var newFile = GetNextPrevFileInDirectory(fileBeingPlayed, -1);
                if (newFile != null && String.Compare(newFile, fileBeingPlayed, true) != 0)
                {
                    OpenFile(newFile);
                }
            }
        }

        private void toolStripFile_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripButtonFileOpen)
            {
                OpenFile();
            }
            else if (e.ClickedItem == toolStripButtonFileNext)
            {
                OpenNextFileInDirectory();
            }
            else if (e.ClickedItem == toolStripButtonFilePrev)
            {
                OpenPrevFileInDirectory();
            }
            else if (e.ClickedItem == toolStripButtonFileSettings)
            {
                formSettings.ShowSettingsDialog();
                ResizePreview();
            }
            else if (e.ClickedItem == toolStripButtonFileAbout)
            {
                using (var about = new AboutBox())
                {
                    about.ShowDialog();
                }
            }
        }

        private void toolStripDropDownButtonFileLanguage_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            var culture = "en-US";

            if (e.ClickedItem == toolStripMenuItemLangEnglish)
                culture = "en-US";
            else if (e.ClickedItem == toolStripMenuItemLangGerman)
                culture = "de-DE";
            else if (e.ClickedItem == toolStripMenuItemLangPolish)
                culture = "pl-PL";
            else if (e.ClickedItem == toolStripMenuItemLangFrench)
                culture = "fr-FR";
            else if (e.ClickedItem == toolStripMenuItemLangItalian)
                culture = "it-IT";
            else if (e.ClickedItem == toolStripMenuItemLangSpanish)
                culture = "es-ES";
            else if (e.ClickedItem == toolStripMenuItemLangChinese)
                culture = "zh-CN";
            else if (e.ClickedItem == toolStripMenuItemLangJapanese)
                culture = "ja-JP";

            if (Thread.CurrentThread.CurrentUICulture.Name != culture)
            {
                VideoCutterSettings.Instance.Language = culture;
                var answer = MessageBox.Show(this, GlobalStrings.MainForm_QuestionRestartNewLanguage,
                    GlobalStrings.GlobalQuestion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button3);

                if (answer == DialogResult.Yes)
                {
                    VideoCutterSettings.Instance.RestoreToolbarsLayout = false;
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }

        private void toolStripTimeline_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripButtonTimelineZoomOut)
            {
                videoCutterTimeline1.ZoomOut();
            }
            else if (e.ClickedItem == toolStripButtonTimelineZoomAuto)
            {
                videoCutterTimeline1.ZoomAuto();
            }
            else if (e.ClickedItem == toolStripButtonTimelineGoToCurrentPosition)
            {
                videoCutterTimeline1.GoToCurrentPosition();
            }
        }

        private string? GetPathOfSingleDraggedFile(IDataObject data)
        {
            if (!data.GetDataPresent(DataFormats.FileDrop))
                return null;

            string[]? files = data.GetData(DataFormats.FileDrop) as string[];

            if (files?.Length != 1)
                return null;

            var file = files[0];
            var ext = System.IO.Path.GetExtension(file);
            if (VideoCutterSettings.Instance.VideoFilesExtensions.Contains(ext.ToLower()))
                return file;

            return null;
        }

        private void MainForm_DragOver(object? sender, DragEventArgs e)
        {
            if (e.Data != null && GetPathOfSingleDraggedFile(e.Data) != null)
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                var file = GetPathOfSingleDraggedFile(e.Data);
                if (file != null)
                {
                    OpenFile(file);
                    Activate();
                }
            }
        }

        private void resetToolbarsLayoutToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            VideoCutterSettings.Instance.RestoreToolbarsLayout = false;
            MessageBox.Show(GlobalStrings.MainForm_DeaultLayoutrestoredAfterRestart, GlobalStrings.GlobalInformation,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
