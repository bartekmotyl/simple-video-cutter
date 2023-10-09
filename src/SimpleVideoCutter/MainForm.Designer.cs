namespace SimpleVideoCutter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStripContainerMain = new System.Windows.Forms.ToolStripContainer();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabelVolume = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelFileDate = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelIndex = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelSelection = new System.Windows.Forms.ToolStripStatusLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            videoViewHover = new LibVLCSharp.WinForms.VideoView();
            vlcControl1 = new LibVLCSharp.WinForms.VideoView();
            videoCutterTimeline1 = new VideoCutterTimeline();
            panelTasks = new System.Windows.Forms.Panel();
            listViewTasks = new System.Windows.Forms.ListView();
            columnStatus = new System.Windows.Forms.ColumnHeader();
            columnProfile = new System.Windows.Forms.ColumnHeader();
            columnFilename = new System.Windows.Forms.ColumnHeader();
            columnDuration = new System.Windows.Forms.ColumnHeader();
            columnOutputFile = new System.Windows.Forms.ColumnHeader();
            columnError = new System.Windows.Forms.ColumnHeader();
            labelTasks = new System.Windows.Forms.Label();
            labelProgress = new System.Windows.Forms.Label();
            contextMenuStripToolstripContainer = new System.Windows.Forms.ContextMenuStrip(components);
            resetToolbarsLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSelection = new System.Windows.Forms.ToolStrip();
            toolStripButtonSelectionSetStart = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSelectionSetEnd = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSelectionPlay = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSelectionClear = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSelectionGoToStart = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSelectionGoToEnd = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSelectionEnqueue = new System.Windows.Forms.ToolStripButton();
            toolStripTimeline = new System.Windows.Forms.ToolStrip();
            toolStripButtonTimelineZoomOut = new System.Windows.Forms.ToolStripButton();
            toolStripButtonTimelineZoomAuto = new System.Windows.Forms.ToolStripButton();
            toolStripButtonTimelineGoToCurrentPosition = new System.Windows.Forms.ToolStripButton();
            toolStripFile = new System.Windows.Forms.ToolStrip();
            toolStripButtonFileOpen = new System.Windows.Forms.ToolStripButton();
            toolStripButtonFilePrev = new System.Windows.Forms.ToolStripButton();
            toolStripButtonFileNext = new System.Windows.Forms.ToolStripButton();
            toolStripButtonFileSettings = new System.Windows.Forms.ToolStripButton();
            toolStripButtonFileAbout = new System.Windows.Forms.ToolStripButton();
            toolStripDropDownButtonFileLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            toolStripMenuItemLangEnglish = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLangGerman = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLangFrench = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLangSpanish = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLangItalian = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLangChinese = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLangJapanese = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLangPolish = new System.Windows.Forms.ToolStripMenuItem();
            toolStripInternet = new System.Windows.Forms.ToolStrip();
            toolStripButtonInternetVersionCheck = new System.Windows.Forms.ToolStripButton();
            toolStripTasks = new System.Windows.Forms.ToolStrip();
            toolStripButtonTasksShow = new System.Windows.Forms.ToolStripButton();
            toolStripPlayback = new System.Windows.Forms.ToolStrip();
            toolStripButtonPlabackPlayPause = new System.Windows.Forms.ToolStripButton();
            toolStripButtonPlabackMute = new System.Windows.Forms.ToolStripButton();
            toolStripButtonPlabackNextFrame = new System.Windows.Forms.ToolStripButton();
            timerHoverPositionChanged = new System.Windows.Forms.Timer(components);
            toolStripButtonPlabackPrevFrame = new System.Windows.Forms.ToolStripButton();
            toolStripContainerMain.BottomToolStripPanel.SuspendLayout();
            toolStripContainerMain.ContentPanel.SuspendLayout();
            toolStripContainerMain.LeftToolStripPanel.SuspendLayout();
            toolStripContainerMain.TopToolStripPanel.SuspendLayout();
            toolStripContainerMain.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)videoViewHover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vlcControl1).BeginInit();
            panelTasks.SuspendLayout();
            contextMenuStripToolstripContainer.SuspendLayout();
            toolStripSelection.SuspendLayout();
            toolStripTimeline.SuspendLayout();
            toolStripFile.SuspendLayout();
            toolStripInternet.SuspendLayout();
            toolStripTasks.SuspendLayout();
            toolStripPlayback.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainerMain
            // 
            // 
            // toolStripContainerMain.BottomToolStripPanel
            // 
            toolStripContainerMain.BottomToolStripPanel.Controls.Add(statusStrip);
            // 
            // toolStripContainerMain.ContentPanel
            // 
            resources.ApplyResources(toolStripContainerMain.ContentPanel, "toolStripContainerMain.ContentPanel");
            toolStripContainerMain.ContentPanel.Controls.Add(splitContainer1);
            resources.ApplyResources(toolStripContainerMain, "toolStripContainerMain");
            // 
            // toolStripContainerMain.LeftToolStripPanel
            // 
            toolStripContainerMain.LeftToolStripPanel.ContextMenuStrip = contextMenuStripToolstripContainer;
            toolStripContainerMain.LeftToolStripPanel.Controls.Add(toolStripTimeline);
            toolStripContainerMain.LeftToolStripPanel.Controls.Add(toolStripSelection);
            toolStripContainerMain.Name = "toolStripContainerMain";
            toolStripContainerMain.RightToolStripPanelVisible = false;
            // 
            // toolStripContainerMain.TopToolStripPanel
            // 
            toolStripContainerMain.TopToolStripPanel.ContextMenuStrip = contextMenuStripToolstripContainer;
            toolStripContainerMain.TopToolStripPanel.Controls.Add(toolStripFile);
            toolStripContainerMain.TopToolStripPanel.Controls.Add(toolStripPlayback);
            toolStripContainerMain.TopToolStripPanel.Controls.Add(toolStripInternet);
            toolStripContainerMain.TopToolStripPanel.Controls.Add(toolStripTasks);
            // 
            // statusStrip
            // 
            resources.ApplyResources(statusStrip, "statusStrip");
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabelVolume, toolStripStatusLabelFilePath, toolStripStatusLabelFileDate, toolStripStatusLabelIndex, toolStripStatusLabelSelection });
            statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabelVolume
            // 
            toolStripStatusLabelVolume.Name = "toolStripStatusLabelVolume";
            resources.ApplyResources(toolStripStatusLabelVolume, "toolStripStatusLabelVolume");
            // 
            // toolStripStatusLabelFilePath
            // 
            toolStripStatusLabelFilePath.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            toolStripStatusLabelFilePath.Name = "toolStripStatusLabelFilePath";
            resources.ApplyResources(toolStripStatusLabelFilePath, "toolStripStatusLabelFilePath");
            // 
            // toolStripStatusLabelFileDate
            // 
            toolStripStatusLabelFileDate.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            toolStripStatusLabelFileDate.Name = "toolStripStatusLabelFileDate";
            resources.ApplyResources(toolStripStatusLabelFileDate, "toolStripStatusLabelFileDate");
            // 
            // toolStripStatusLabelIndex
            // 
            toolStripStatusLabelIndex.Name = "toolStripStatusLabelIndex";
            resources.ApplyResources(toolStripStatusLabelIndex, "toolStripStatusLabelIndex");
            // 
            // toolStripStatusLabelSelection
            // 
            toolStripStatusLabelSelection.Name = "toolStripStatusLabelSelection";
            resources.ApplyResources(toolStripStatusLabelSelection, "toolStripStatusLabelSelection");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(videoViewHover);
            splitContainer1.Panel1.Controls.Add(vlcControl1);
            splitContainer1.Panel1.Controls.Add(videoCutterTimeline1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelTasks);
            splitContainer1.Panel2Collapsed = true;
            // 
            // videoViewHover
            // 
            videoViewHover.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(videoViewHover, "videoViewHover");
            videoViewHover.MediaPlayer = null;
            videoViewHover.Name = "videoViewHover";
            // 
            // vlcControl1
            // 
            vlcControl1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(vlcControl1, "vlcControl1");
            vlcControl1.MediaPlayer = null;
            vlcControl1.Name = "vlcControl1";
            vlcControl1.MouseClick += vlcControl1_MouseClick;
            // 
            // videoCutterTimeline1
            // 
            resources.ApplyResources(videoCutterTimeline1, "videoCutterTimeline1");
            videoCutterTimeline1.HoverPosition = null;
            videoCutterTimeline1.Length = 0L;
            videoCutterTimeline1.Name = "videoCutterTimeline1";
            videoCutterTimeline1.Position = 0L;
            // 
            // panelTasks
            // 
            panelTasks.Controls.Add(listViewTasks);
            panelTasks.Controls.Add(labelTasks);
            panelTasks.Controls.Add(labelProgress);
            resources.ApplyResources(panelTasks, "panelTasks");
            panelTasks.Name = "panelTasks";
            // 
            // listViewTasks
            // 
            listViewTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnStatus, columnProfile, columnFilename, columnDuration, columnOutputFile, columnError });
            resources.ApplyResources(listViewTasks, "listViewTasks");
            listViewTasks.FullRowSelect = true;
            listViewTasks.GridLines = true;
            listViewTasks.Name = "listViewTasks";
            listViewTasks.UseCompatibleStateImageBehavior = false;
            listViewTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnStatus
            // 
            resources.ApplyResources(columnStatus, "columnStatus");
            // 
            // columnProfile
            // 
            resources.ApplyResources(columnProfile, "columnProfile");
            // 
            // columnFilename
            // 
            resources.ApplyResources(columnFilename, "columnFilename");
            // 
            // columnDuration
            // 
            resources.ApplyResources(columnDuration, "columnDuration");
            // 
            // columnOutputFile
            // 
            resources.ApplyResources(columnOutputFile, "columnOutputFile");
            // 
            // columnError
            // 
            resources.ApplyResources(columnError, "columnError");
            // 
            // labelTasks
            // 
            resources.ApplyResources(labelTasks, "labelTasks");
            labelTasks.Name = "labelTasks";
            // 
            // labelProgress
            // 
            resources.ApplyResources(labelProgress, "labelProgress");
            labelProgress.Name = "labelProgress";
            // 
            // contextMenuStripToolstripContainer
            // 
            contextMenuStripToolstripContainer.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripToolstripContainer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { resetToolbarsLayoutToolStripMenuItem });
            contextMenuStripToolstripContainer.Name = "contextMenuStripToolstripContainer";
            resources.ApplyResources(contextMenuStripToolstripContainer, "contextMenuStripToolstripContainer");
            // 
            // resetToolbarsLayoutToolStripMenuItem
            // 
            resetToolbarsLayoutToolStripMenuItem.Name = "resetToolbarsLayoutToolStripMenuItem";
            resources.ApplyResources(resetToolbarsLayoutToolStripMenuItem, "resetToolbarsLayoutToolStripMenuItem");
            resetToolbarsLayoutToolStripMenuItem.Click += resetToolbarsLayoutToolStripMenuItem_Click;
            // 
            // toolStripSelection
            // 
            resources.ApplyResources(toolStripSelection, "toolStripSelection");
            toolStripSelection.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStripSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonSelectionSetStart, toolStripButtonSelectionSetEnd, toolStripButtonSelectionPlay, toolStripButtonSelectionClear, toolStripButtonSelectionGoToStart, toolStripButtonSelectionGoToEnd, toolStripButtonSelectionEnqueue });
            toolStripSelection.Name = "toolStripSelection";
            toolStripSelection.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            toolStripSelection.ItemClicked += toolStripSelection_ItemClicked;
            // 
            // toolStripButtonSelectionSetStart
            // 
            toolStripButtonSelectionSetStart.Image = Properties.Resources.streamline_icon_set_start_32x32;
            resources.ApplyResources(toolStripButtonSelectionSetStart, "toolStripButtonSelectionSetStart");
            toolStripButtonSelectionSetStart.Name = "toolStripButtonSelectionSetStart";
            // 
            // toolStripButtonSelectionSetEnd
            // 
            toolStripButtonSelectionSetEnd.Image = Properties.Resources.streamline_icon_set_end_32x32;
            resources.ApplyResources(toolStripButtonSelectionSetEnd, "toolStripButtonSelectionSetEnd");
            toolStripButtonSelectionSetEnd.Name = "toolStripButtonSelectionSetEnd";
            // 
            // toolStripButtonSelectionPlay
            // 
            toolStripButtonSelectionPlay.Image = Properties.Resources.streamline_icon_video_player_slider_32x32;
            resources.ApplyResources(toolStripButtonSelectionPlay, "toolStripButtonSelectionPlay");
            toolStripButtonSelectionPlay.Name = "toolStripButtonSelectionPlay";
            // 
            // toolStripButtonSelectionClear
            // 
            toolStripButtonSelectionClear.Image = Properties.Resources.streamline_icon_eraser_32x32;
            resources.ApplyResources(toolStripButtonSelectionClear, "toolStripButtonSelectionClear");
            toolStripButtonSelectionClear.Name = "toolStripButtonSelectionClear";
            // 
            // toolStripButtonSelectionGoToStart
            // 
            toolStripButtonSelectionGoToStart.Image = Properties.Resources.streamline_icon_go_to_start_32x321;
            resources.ApplyResources(toolStripButtonSelectionGoToStart, "toolStripButtonSelectionGoToStart");
            toolStripButtonSelectionGoToStart.Name = "toolStripButtonSelectionGoToStart";
            // 
            // toolStripButtonSelectionGoToEnd
            // 
            toolStripButtonSelectionGoToEnd.Image = Properties.Resources.streamline_icon_go_to_end_32x32;
            resources.ApplyResources(toolStripButtonSelectionGoToEnd, "toolStripButtonSelectionGoToEnd");
            toolStripButtonSelectionGoToEnd.Name = "toolStripButtonSelectionGoToEnd";
            // 
            // toolStripButtonSelectionEnqueue
            // 
            toolStripButtonSelectionEnqueue.Image = Properties.Resources.streamline_icon_task_list_add_32x32;
            resources.ApplyResources(toolStripButtonSelectionEnqueue, "toolStripButtonSelectionEnqueue");
            toolStripButtonSelectionEnqueue.Name = "toolStripButtonSelectionEnqueue";
            // 
            // toolStripTimeline
            // 
            resources.ApplyResources(toolStripTimeline, "toolStripTimeline");
            toolStripTimeline.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStripTimeline.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonTimelineZoomOut, toolStripButtonTimelineZoomAuto, toolStripButtonTimelineGoToCurrentPosition });
            toolStripTimeline.Name = "toolStripTimeline";
            toolStripTimeline.ItemClicked += toolStripTimeline_ItemClicked;
            // 
            // toolStripButtonTimelineZoomOut
            // 
            toolStripButtonTimelineZoomOut.Image = Properties.Resources.streamline_icon_expand_5_32x32;
            resources.ApplyResources(toolStripButtonTimelineZoomOut, "toolStripButtonTimelineZoomOut");
            toolStripButtonTimelineZoomOut.Name = "toolStripButtonTimelineZoomOut";
            // 
            // toolStripButtonTimelineZoomAuto
            // 
            toolStripButtonTimelineZoomAuto.Image = Properties.Resources.streamline_icon_direction_button_3_32x32;
            resources.ApplyResources(toolStripButtonTimelineZoomAuto, "toolStripButtonTimelineZoomAuto");
            toolStripButtonTimelineZoomAuto.Name = "toolStripButtonTimelineZoomAuto";
            // 
            // toolStripButtonTimelineGoToCurrentPosition
            // 
            toolStripButtonTimelineGoToCurrentPosition.Image = Properties.Resources.streamline_icon_cursor_move_target_right_32x32;
            resources.ApplyResources(toolStripButtonTimelineGoToCurrentPosition, "toolStripButtonTimelineGoToCurrentPosition");
            toolStripButtonTimelineGoToCurrentPosition.Name = "toolStripButtonTimelineGoToCurrentPosition";
            // 
            // toolStripFile
            // 
            resources.ApplyResources(toolStripFile, "toolStripFile");
            toolStripFile.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonFileOpen, toolStripButtonFilePrev, toolStripButtonFileNext, toolStripButtonFileSettings, toolStripButtonFileAbout, toolStripDropDownButtonFileLanguage });
            toolStripFile.Name = "toolStripFile";
            toolStripFile.ItemClicked += toolStripFile_ItemClicked;
            // 
            // toolStripButtonFileOpen
            // 
            resources.ApplyResources(toolStripButtonFileOpen, "toolStripButtonFileOpen");
            toolStripButtonFileOpen.Name = "toolStripButtonFileOpen";
            // 
            // toolStripButtonFilePrev
            // 
            toolStripButtonFilePrev.Image = Properties.Resources.streamline_icon_arrow_rectangle_left_2_32x32;
            resources.ApplyResources(toolStripButtonFilePrev, "toolStripButtonFilePrev");
            toolStripButtonFilePrev.Name = "toolStripButtonFilePrev";
            // 
            // toolStripButtonFileNext
            // 
            toolStripButtonFileNext.Image = Properties.Resources.streamline_icon_arrow_rectangle_right_32x32;
            resources.ApplyResources(toolStripButtonFileNext, "toolStripButtonFileNext");
            toolStripButtonFileNext.Name = "toolStripButtonFileNext";
            // 
            // toolStripButtonFileSettings
            // 
            resources.ApplyResources(toolStripButtonFileSettings, "toolStripButtonFileSettings");
            toolStripButtonFileSettings.Name = "toolStripButtonFileSettings";
            // 
            // toolStripButtonFileAbout
            // 
            toolStripButtonFileAbout.Image = Properties.Resources.streamline_icon_information_circle_32x32;
            resources.ApplyResources(toolStripButtonFileAbout, "toolStripButtonFileAbout");
            toolStripButtonFileAbout.Name = "toolStripButtonFileAbout";
            // 
            // toolStripDropDownButtonFileLanguage
            // 
            toolStripDropDownButtonFileLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemLangEnglish, toolStripMenuItemLangGerman, toolStripMenuItemLangFrench, toolStripMenuItemLangSpanish, toolStripMenuItemLangItalian, toolStripMenuItemLangChinese, toolStripMenuItemLangJapanese, toolStripMenuItemLangPolish });
            toolStripDropDownButtonFileLanguage.Image = Properties.Resources.streamline_icon_translate_32x32;
            resources.ApplyResources(toolStripDropDownButtonFileLanguage, "toolStripDropDownButtonFileLanguage");
            toolStripDropDownButtonFileLanguage.Name = "toolStripDropDownButtonFileLanguage";
            toolStripDropDownButtonFileLanguage.DropDownItemClicked += toolStripDropDownButtonFileLanguage_DropDownItemClicked;
            // 
            // toolStripMenuItemLangEnglish
            // 
            toolStripMenuItemLangEnglish.Name = "toolStripMenuItemLangEnglish";
            resources.ApplyResources(toolStripMenuItemLangEnglish, "toolStripMenuItemLangEnglish");
            // 
            // toolStripMenuItemLangGerman
            // 
            toolStripMenuItemLangGerman.Name = "toolStripMenuItemLangGerman";
            resources.ApplyResources(toolStripMenuItemLangGerman, "toolStripMenuItemLangGerman");
            // 
            // toolStripMenuItemLangFrench
            // 
            toolStripMenuItemLangFrench.Name = "toolStripMenuItemLangFrench";
            resources.ApplyResources(toolStripMenuItemLangFrench, "toolStripMenuItemLangFrench");
            // 
            // toolStripMenuItemLangSpanish
            // 
            toolStripMenuItemLangSpanish.Name = "toolStripMenuItemLangSpanish";
            resources.ApplyResources(toolStripMenuItemLangSpanish, "toolStripMenuItemLangSpanish");
            // 
            // toolStripMenuItemLangItalian
            // 
            toolStripMenuItemLangItalian.Name = "toolStripMenuItemLangItalian";
            resources.ApplyResources(toolStripMenuItemLangItalian, "toolStripMenuItemLangItalian");
            // 
            // toolStripMenuItemLangChinese
            // 
            toolStripMenuItemLangChinese.Name = "toolStripMenuItemLangChinese";
            resources.ApplyResources(toolStripMenuItemLangChinese, "toolStripMenuItemLangChinese");
            // 
            // toolStripMenuItemLangJapanese
            // 
            toolStripMenuItemLangJapanese.Name = "toolStripMenuItemLangJapanese";
            resources.ApplyResources(toolStripMenuItemLangJapanese, "toolStripMenuItemLangJapanese");
            // 
            // toolStripMenuItemLangPolish
            // 
            toolStripMenuItemLangPolish.Name = "toolStripMenuItemLangPolish";
            resources.ApplyResources(toolStripMenuItemLangPolish, "toolStripMenuItemLangPolish");
            // 
            // toolStripInternet
            // 
            resources.ApplyResources(toolStripInternet, "toolStripInternet");
            toolStripInternet.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStripInternet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonInternetVersionCheck });
            toolStripInternet.Name = "toolStripInternet";
            toolStripInternet.ItemClicked += toolStripInternet_ItemClicked;
            // 
            // toolStripButtonInternetVersionCheck
            // 
            toolStripButtonInternetVersionCheck.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(toolStripButtonInternetVersionCheck, "toolStripButtonInternetVersionCheck");
            toolStripButtonInternetVersionCheck.Image = Properties.Resources.streamline_icon_laptop_download_32x32;
            toolStripButtonInternetVersionCheck.Name = "toolStripButtonInternetVersionCheck";
            // 
            // toolStripTasks
            // 
            resources.ApplyResources(toolStripTasks, "toolStripTasks");
            toolStripTasks.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStripTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonTasksShow });
            toolStripTasks.Name = "toolStripTasks";
            // 
            // toolStripButtonTasksShow
            // 
            toolStripButtonTasksShow.CheckOnClick = true;
            toolStripButtonTasksShow.Image = Properties.Resources.streamline_icon_task_list_clock_32x32;
            resources.ApplyResources(toolStripButtonTasksShow, "toolStripButtonTasksShow");
            toolStripButtonTasksShow.Name = "toolStripButtonTasksShow";
            toolStripButtonTasksShow.CheckedChanged += toolStripButtonShowTasks_CheckedChanged;
            // 
            // toolStripPlayback
            // 
            resources.ApplyResources(toolStripPlayback, "toolStripPlayback");
            toolStripPlayback.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStripPlayback.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonPlabackPlayPause, toolStripButtonPlabackMute, toolStripButtonPlabackPrevFrame, toolStripButtonPlabackNextFrame });
            toolStripPlayback.Name = "toolStripPlayback";
            toolStripPlayback.ItemClicked += toolStripPlayback_ItemClicked;
            // 
            // toolStripButtonPlabackPlayPause
            // 
            toolStripButtonPlabackPlayPause.Image = Properties.Resources.streamline_icon_controls_play_32x32;
            resources.ApplyResources(toolStripButtonPlabackPlayPause, "toolStripButtonPlabackPlayPause");
            toolStripButtonPlabackPlayPause.Name = "toolStripButtonPlabackPlayPause";
            // 
            // toolStripButtonPlabackMute
            // 
            toolStripButtonPlabackMute.Image = Properties.Resources.streamline_icon_volume_control_mute_32x32;
            resources.ApplyResources(toolStripButtonPlabackMute, "toolStripButtonPlabackMute");
            toolStripButtonPlabackMute.Name = "toolStripButtonPlabackMute";
            // 
            // toolStripButtonPlabackNextFrame
            // 
            toolStripButtonPlabackNextFrame.Image = Properties.Resources.streamline_icon_arrow_button_circle_right_32x32;
            resources.ApplyResources(toolStripButtonPlabackNextFrame, "toolStripButtonPlabackNextFrame");
            toolStripButtonPlabackNextFrame.Name = "toolStripButtonPlabackNextFrame";
            // 
            // timerHoverPositionChanged
            // 
            timerHoverPositionChanged.Interval = 50;
            timerHoverPositionChanged.Tick += timerHoverPositionChanged_Tick;
            // 
            // toolStripButtonPlabackPrevFrame
            // 
            toolStripButtonPlabackPrevFrame.Image = Properties.Resources.streamline_icon_arrow_button_circle_left_32x32;
            resources.ApplyResources(toolStripButtonPlabackPrevFrame, "toolStripButtonPlabackPrevFrame");
            toolStripButtonPlabackPrevFrame.Name = "toolStripButtonPlabackPrevFrame";
            // 
            // MainForm
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(toolStripContainerMain);
            KeyPreview = true;
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            DragDrop += MainForm_DragDrop;
            DragOver += MainForm_DragOver;
            KeyDown += Form1_KeyDown;
            toolStripContainerMain.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainerMain.BottomToolStripPanel.PerformLayout();
            toolStripContainerMain.ContentPanel.ResumeLayout(false);
            toolStripContainerMain.LeftToolStripPanel.ResumeLayout(false);
            toolStripContainerMain.LeftToolStripPanel.PerformLayout();
            toolStripContainerMain.TopToolStripPanel.ResumeLayout(false);
            toolStripContainerMain.TopToolStripPanel.PerformLayout();
            toolStripContainerMain.ResumeLayout(false);
            toolStripContainerMain.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)videoViewHover).EndInit();
            ((System.ComponentModel.ISupportInitialize)vlcControl1).EndInit();
            panelTasks.ResumeLayout(false);
            panelTasks.PerformLayout();
            contextMenuStripToolstripContainer.ResumeLayout(false);
            toolStripSelection.ResumeLayout(false);
            toolStripSelection.PerformLayout();
            toolStripTimeline.ResumeLayout(false);
            toolStripTimeline.PerformLayout();
            toolStripFile.ResumeLayout(false);
            toolStripFile.PerformLayout();
            toolStripInternet.ResumeLayout(false);
            toolStripInternet.PerformLayout();
            toolStripTasks.ResumeLayout(false);
            toolStripTasks.PerformLayout();
            toolStripPlayback.ResumeLayout(false);
            toolStripPlayback.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private VideoCutterTimeline videoCutterTimeline1;
        private System.Windows.Forms.ToolStrip toolStripTasks;
        private System.Windows.Forms.Panel panelTasks;
        private System.Windows.Forms.ListView listViewTasks;
        private System.Windows.Forms.Label labelTasks;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ColumnHeader columnDuration;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVolume;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFilePath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFileDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelIndex;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelection;
        private System.Windows.Forms.ToolStripButton toolStripButtonTasksShow;
        private LibVLCSharp.WinForms.VideoView vlcControl1;
        private LibVLCSharp.WinForms.VideoView videoViewHover;
        private System.Windows.Forms.Timer timerHoverPositionChanged;
        private System.Windows.Forms.ToolStripContainer toolStripContainerMain;
        private System.Windows.Forms.ToolStrip toolStripSelection;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionSetStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionSetEnd;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionPlay;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionClear;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionGoToStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionGoToEnd;
        private System.Windows.Forms.ToolStrip toolStripFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonFileOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonFileNext;
        private System.Windows.Forms.ToolStripButton toolStripButtonFilePrev;
        private System.Windows.Forms.ToolStripButton toolStripButtonFileSettings;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionEnqueue;
        private System.Windows.Forms.ToolStrip toolStripPlayback;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlabackPlayPause;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlabackMute;
        private System.Windows.Forms.ToolStripButton toolStripButtonFileAbout;
        private System.Windows.Forms.ToolStrip toolStripTimeline;
        private System.Windows.Forms.ToolStripButton toolStripButtonTimelineZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButtonTimelineZoomAuto;
        private System.Windows.Forms.ToolStripButton toolStripButtonTimelineGoToCurrentPosition;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnError;
        private System.Windows.Forms.ColumnHeader columnOutputFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlabackNextFrame;
        private System.Windows.Forms.ColumnHeader columnProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripToolstripContainer;
        private System.Windows.Forms.ToolStripMenuItem resetToolbarsLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripInternet;
        private System.Windows.Forms.ToolStripButton toolStripButtonInternetVersionCheck;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFileLanguage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangEnglish;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangGerman;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangFrench;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangSpanish;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangItalian;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangChinese;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangJapanese;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLangPolish;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlabackPrevFrame;
    }
}

