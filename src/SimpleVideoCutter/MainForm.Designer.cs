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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainerMain = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelVolume = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFileDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.videoViewHover = new LibVLCSharp.WinForms.VideoView();
            this.vlcControl1 = new LibVLCSharp.WinForms.VideoView();
            this.videoCutterTimeline1 = new SimpleVideoCutter.VideoCutterTimeline();
            this.panelTasks = new System.Windows.Forms.Panel();
            this.listViewTasks = new System.Windows.Forms.ListView();
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProfile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOutputFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTasks = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.contextMenuStripToolstripContainer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetToolbarsLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSelection = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSelectionSetStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionSetEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionGoToStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionGoToEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionEnqueue = new System.Windows.Forms.ToolStripButton();
            this.toolStripTimeline = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTimelineZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTimelineZoomAuto = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTimelineGoToCurrentPosition = new System.Windows.Forms.ToolStripButton();
            this.toolStripInternet = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonInternetVersionCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripTasks = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTasksShow = new System.Windows.Forms.ToolStripButton();
            this.toolStripPlayback = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPlabackPlayPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPlabackMute = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPlabackNextFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripFile = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonFileOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFilePrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFileNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFileSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFileAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonFileLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemLangEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLangGerman = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLangFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLangSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLangItalian = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLangChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLangJapanese = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLangPolish = new System.Windows.Forms.ToolStripMenuItem();
            this.timerHoverPositionChanged = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainerMain.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.ContentPanel.SuspendLayout();
            this.toolStripContainerMain.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewHover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.panelTasks.SuspendLayout();
            this.contextMenuStripToolstripContainer.SuspendLayout();
            this.toolStripSelection.SuspendLayout();
            this.toolStripTimeline.SuspendLayout();
            this.toolStripInternet.SuspendLayout();
            this.toolStripTasks.SuspendLayout();
            this.toolStripPlayback.SuspendLayout();
            this.toolStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainerMain
            // 
            // 
            // toolStripContainerMain.BottomToolStripPanel
            // 
            this.toolStripContainerMain.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainerMain.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainerMain.ContentPanel, "toolStripContainerMain.ContentPanel");
            this.toolStripContainerMain.ContentPanel.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.toolStripContainerMain, "toolStripContainerMain");
            // 
            // toolStripContainerMain.LeftToolStripPanel
            // 
            this.toolStripContainerMain.LeftToolStripPanel.ContextMenuStrip = this.contextMenuStripToolstripContainer;
            this.toolStripContainerMain.LeftToolStripPanel.Controls.Add(this.toolStripSelection);
            this.toolStripContainerMain.LeftToolStripPanel.Controls.Add(this.toolStripTimeline);
            this.toolStripContainerMain.Name = "toolStripContainerMain";
            this.toolStripContainerMain.RightToolStripPanelVisible = false;
            // 
            // toolStripContainerMain.TopToolStripPanel
            // 
            this.toolStripContainerMain.TopToolStripPanel.ContextMenuStrip = this.contextMenuStripToolstripContainer;
            this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.toolStripFile);
            this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.toolStripTasks);
            this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.toolStripPlayback);
            this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.toolStripInternet);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelVolume,
            this.toolStripStatusLabelFilePath,
            this.toolStripStatusLabelFileDate,
            this.toolStripStatusLabelIndex,
            this.toolStripStatusLabelSelection});
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabelVolume
            // 
            this.toolStripStatusLabelVolume.Name = "toolStripStatusLabelVolume";
            resources.ApplyResources(this.toolStripStatusLabelVolume, "toolStripStatusLabelVolume");
            // 
            // toolStripStatusLabelFilePath
            // 
            this.toolStripStatusLabelFilePath.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabelFilePath.Name = "toolStripStatusLabelFilePath";
            resources.ApplyResources(this.toolStripStatusLabelFilePath, "toolStripStatusLabelFilePath");
            // 
            // toolStripStatusLabelFileDate
            // 
            this.toolStripStatusLabelFileDate.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabelFileDate.Name = "toolStripStatusLabelFileDate";
            resources.ApplyResources(this.toolStripStatusLabelFileDate, "toolStripStatusLabelFileDate");
            // 
            // toolStripStatusLabelIndex
            // 
            this.toolStripStatusLabelIndex.Name = "toolStripStatusLabelIndex";
            resources.ApplyResources(this.toolStripStatusLabelIndex, "toolStripStatusLabelIndex");
            // 
            // toolStripStatusLabelSelection
            // 
            this.toolStripStatusLabelSelection.Name = "toolStripStatusLabelSelection";
            resources.ApplyResources(this.toolStripStatusLabelSelection, "toolStripStatusLabelSelection");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.videoViewHover);
            this.splitContainer1.Panel1.Controls.Add(this.vlcControl1);
            this.splitContainer1.Panel1.Controls.Add(this.videoCutterTimeline1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelTasks);
            this.splitContainer1.Panel2Collapsed = true;
            // 
            // videoViewHover
            // 
            this.videoViewHover.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.videoViewHover, "videoViewHover");
            this.videoViewHover.MediaPlayer = null;
            this.videoViewHover.Name = "videoViewHover";
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.vlcControl1, "vlcControl1");
            this.vlcControl1.MediaPlayer = null;
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.vlcControl1_MouseClick);
            // 
            // videoCutterTimeline1
            // 
            resources.ApplyResources(this.videoCutterTimeline1, "videoCutterTimeline1");
            this.videoCutterTimeline1.HoverPosition = null;
            this.videoCutterTimeline1.Length = ((long)(0));
            this.videoCutterTimeline1.Name = "videoCutterTimeline1";
            this.videoCutterTimeline1.Position = ((long)(0));
            // 
            // panelTasks
            // 
            this.panelTasks.Controls.Add(this.listViewTasks);
            this.panelTasks.Controls.Add(this.labelTasks);
            this.panelTasks.Controls.Add(this.labelProgress);
            resources.ApplyResources(this.panelTasks, "panelTasks");
            this.panelTasks.Name = "panelTasks";
            // 
            // listViewTasks
            // 
            this.listViewTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnStatus,
            this.columnProfile,
            this.columnFilename,
            this.columnDuration,
            this.columnOutputFile,
            this.columnError});
            resources.ApplyResources(this.listViewTasks, "listViewTasks");
            this.listViewTasks.FullRowSelect = true;
            this.listViewTasks.GridLines = true;
            this.listViewTasks.HideSelection = false;
            this.listViewTasks.Name = "listViewTasks";
            this.listViewTasks.UseCompatibleStateImageBehavior = false;
            this.listViewTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnStatus
            // 
            resources.ApplyResources(this.columnStatus, "columnStatus");
            // 
            // columnProfile
            // 
            resources.ApplyResources(this.columnProfile, "columnProfile");
            // 
            // columnFilename
            // 
            resources.ApplyResources(this.columnFilename, "columnFilename");
            // 
            // columnDuration
            // 
            resources.ApplyResources(this.columnDuration, "columnDuration");
            // 
            // columnOutputFile
            // 
            resources.ApplyResources(this.columnOutputFile, "columnOutputFile");
            // 
            // columnError
            // 
            resources.ApplyResources(this.columnError, "columnError");
            // 
            // labelTasks
            // 
            resources.ApplyResources(this.labelTasks, "labelTasks");
            this.labelTasks.Name = "labelTasks";
            // 
            // labelProgress
            // 
            resources.ApplyResources(this.labelProgress, "labelProgress");
            this.labelProgress.Name = "labelProgress";
            // 
            // contextMenuStripToolstripContainer
            // 
            this.contextMenuStripToolstripContainer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolbarsLayoutToolStripMenuItem});
            this.contextMenuStripToolstripContainer.Name = "contextMenuStripToolstripContainer";
            resources.ApplyResources(this.contextMenuStripToolstripContainer, "contextMenuStripToolstripContainer");
            // 
            // resetToolbarsLayoutToolStripMenuItem
            // 
            this.resetToolbarsLayoutToolStripMenuItem.Name = "resetToolbarsLayoutToolStripMenuItem";
            resources.ApplyResources(this.resetToolbarsLayoutToolStripMenuItem, "resetToolbarsLayoutToolStripMenuItem");
            this.resetToolbarsLayoutToolStripMenuItem.Click += new System.EventHandler(this.resetToolbarsLayoutToolStripMenuItem_Click);
            // 
            // toolStripSelection
            // 
            resources.ApplyResources(this.toolStripSelection, "toolStripSelection");
            this.toolStripSelection.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSelectionSetStart,
            this.toolStripButtonSelectionSetEnd,
            this.toolStripButtonSelectionPlay,
            this.toolStripButtonSelectionClear,
            this.toolStripButtonSelectionGoToStart,
            this.toolStripButtonSelectionGoToEnd,
            this.toolStripButtonSelectionEnqueue});
            this.toolStripSelection.Name = "toolStripSelection";
            this.toolStripSelection.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripSelection.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripSelection_ItemClicked);
            // 
            // toolStripButtonSelectionSetStart
            // 
            this.toolStripButtonSelectionSetStart.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_set_start_32x32;
            resources.ApplyResources(this.toolStripButtonSelectionSetStart, "toolStripButtonSelectionSetStart");
            this.toolStripButtonSelectionSetStart.Name = "toolStripButtonSelectionSetStart";
            // 
            // toolStripButtonSelectionSetEnd
            // 
            this.toolStripButtonSelectionSetEnd.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_set_end_32x32;
            resources.ApplyResources(this.toolStripButtonSelectionSetEnd, "toolStripButtonSelectionSetEnd");
            this.toolStripButtonSelectionSetEnd.Name = "toolStripButtonSelectionSetEnd";
            // 
            // toolStripButtonSelectionPlay
            // 
            this.toolStripButtonSelectionPlay.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_video_player_slider_32x32;
            resources.ApplyResources(this.toolStripButtonSelectionPlay, "toolStripButtonSelectionPlay");
            this.toolStripButtonSelectionPlay.Name = "toolStripButtonSelectionPlay";
            // 
            // toolStripButtonSelectionClear
            // 
            this.toolStripButtonSelectionClear.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_eraser_32x32;
            resources.ApplyResources(this.toolStripButtonSelectionClear, "toolStripButtonSelectionClear");
            this.toolStripButtonSelectionClear.Name = "toolStripButtonSelectionClear";
            // 
            // toolStripButtonSelectionGoToStart
            // 
            this.toolStripButtonSelectionGoToStart.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_go_to_start_32x321;
            resources.ApplyResources(this.toolStripButtonSelectionGoToStart, "toolStripButtonSelectionGoToStart");
            this.toolStripButtonSelectionGoToStart.Name = "toolStripButtonSelectionGoToStart";
            // 
            // toolStripButtonSelectionGoToEnd
            // 
            this.toolStripButtonSelectionGoToEnd.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_go_to_end_32x32;
            resources.ApplyResources(this.toolStripButtonSelectionGoToEnd, "toolStripButtonSelectionGoToEnd");
            this.toolStripButtonSelectionGoToEnd.Name = "toolStripButtonSelectionGoToEnd";
            // 
            // toolStripButtonSelectionEnqueue
            // 
            this.toolStripButtonSelectionEnqueue.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_task_list_add_32x32;
            resources.ApplyResources(this.toolStripButtonSelectionEnqueue, "toolStripButtonSelectionEnqueue");
            this.toolStripButtonSelectionEnqueue.Name = "toolStripButtonSelectionEnqueue";
            // 
            // toolStripTimeline
            // 
            resources.ApplyResources(this.toolStripTimeline, "toolStripTimeline");
            this.toolStripTimeline.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTimeline.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTimelineZoomOut,
            this.toolStripButtonTimelineZoomAuto,
            this.toolStripButtonTimelineGoToCurrentPosition});
            this.toolStripTimeline.Name = "toolStripTimeline";
            this.toolStripTimeline.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripTimeline_ItemClicked);
            // 
            // toolStripButtonTimelineZoomOut
            // 
            this.toolStripButtonTimelineZoomOut.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_expand_5_32x32;
            resources.ApplyResources(this.toolStripButtonTimelineZoomOut, "toolStripButtonTimelineZoomOut");
            this.toolStripButtonTimelineZoomOut.Name = "toolStripButtonTimelineZoomOut";
            // 
            // toolStripButtonTimelineZoomAuto
            // 
            this.toolStripButtonTimelineZoomAuto.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_direction_button_3_32x32;
            resources.ApplyResources(this.toolStripButtonTimelineZoomAuto, "toolStripButtonTimelineZoomAuto");
            this.toolStripButtonTimelineZoomAuto.Name = "toolStripButtonTimelineZoomAuto";
            // 
            // toolStripButtonTimelineGoToCurrentPosition
            // 
            this.toolStripButtonTimelineGoToCurrentPosition.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_cursor_move_target_right_32x32;
            resources.ApplyResources(this.toolStripButtonTimelineGoToCurrentPosition, "toolStripButtonTimelineGoToCurrentPosition");
            this.toolStripButtonTimelineGoToCurrentPosition.Name = "toolStripButtonTimelineGoToCurrentPosition";
            // 
            // toolStripInternet
            // 
            resources.ApplyResources(this.toolStripInternet, "toolStripInternet");
            this.toolStripInternet.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripInternet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonInternetVersionCheck});
            this.toolStripInternet.Name = "toolStripInternet";
            this.toolStripInternet.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripInternet_ItemClicked);
            // 
            // toolStripButtonInternetVersionCheck
            // 
            this.toolStripButtonInternetVersionCheck.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.toolStripButtonInternetVersionCheck, "toolStripButtonInternetVersionCheck");
            this.toolStripButtonInternetVersionCheck.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_laptop_download_32x32;
            this.toolStripButtonInternetVersionCheck.Name = "toolStripButtonInternetVersionCheck";
            // 
            // toolStripTasks
            // 
            resources.ApplyResources(this.toolStripTasks, "toolStripTasks");
            this.toolStripTasks.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTasksShow});
            this.toolStripTasks.Name = "toolStripTasks";
            // 
            // toolStripButtonTasksShow
            // 
            this.toolStripButtonTasksShow.CheckOnClick = true;
            this.toolStripButtonTasksShow.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_task_list_clock_32x32;
            resources.ApplyResources(this.toolStripButtonTasksShow, "toolStripButtonTasksShow");
            this.toolStripButtonTasksShow.Name = "toolStripButtonTasksShow";
            this.toolStripButtonTasksShow.CheckedChanged += new System.EventHandler(this.toolStripButtonShowTasks_CheckedChanged);
            // 
            // toolStripPlayback
            // 
            resources.ApplyResources(this.toolStripPlayback, "toolStripPlayback");
            this.toolStripPlayback.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripPlayback.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPlabackPlayPause,
            this.toolStripButtonPlabackMute,
            this.toolStripButtonPlabackNextFrame});
            this.toolStripPlayback.Name = "toolStripPlayback";
            this.toolStripPlayback.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripPlayback_ItemClicked);
            // 
            // toolStripButtonPlabackPlayPause
            // 
            this.toolStripButtonPlabackPlayPause.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_controls_play_32x32;
            resources.ApplyResources(this.toolStripButtonPlabackPlayPause, "toolStripButtonPlabackPlayPause");
            this.toolStripButtonPlabackPlayPause.Name = "toolStripButtonPlabackPlayPause";
            // 
            // toolStripButtonPlabackMute
            // 
            this.toolStripButtonPlabackMute.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_volume_control_mute_32x32;
            resources.ApplyResources(this.toolStripButtonPlabackMute, "toolStripButtonPlabackMute");
            this.toolStripButtonPlabackMute.Name = "toolStripButtonPlabackMute";
            // 
            // toolStripButtonPlabackNextFrame
            // 
            this.toolStripButtonPlabackNextFrame.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_arrow_button_circle_right_32x32;
            resources.ApplyResources(this.toolStripButtonPlabackNextFrame, "toolStripButtonPlabackNextFrame");
            this.toolStripButtonPlabackNextFrame.Name = "toolStripButtonPlabackNextFrame";
            // 
            // toolStripFile
            // 
            resources.ApplyResources(this.toolStripFile, "toolStripFile");
            this.toolStripFile.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFileOpen,
            this.toolStripButtonFilePrev,
            this.toolStripButtonFileNext,
            this.toolStripButtonFileSettings,
            this.toolStripButtonFileAbout,
            this.toolStripDropDownButtonFileLanguage});
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripFile_ItemClicked);
            // 
            // toolStripButtonFileOpen
            // 
            resources.ApplyResources(this.toolStripButtonFileOpen, "toolStripButtonFileOpen");
            this.toolStripButtonFileOpen.Name = "toolStripButtonFileOpen";
            // 
            // toolStripButtonFilePrev
            // 
            this.toolStripButtonFilePrev.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_arrow_rectangle_left_2_32x32;
            resources.ApplyResources(this.toolStripButtonFilePrev, "toolStripButtonFilePrev");
            this.toolStripButtonFilePrev.Name = "toolStripButtonFilePrev";
            // 
            // toolStripButtonFileNext
            // 
            this.toolStripButtonFileNext.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_arrow_rectangle_right_32x32;
            resources.ApplyResources(this.toolStripButtonFileNext, "toolStripButtonFileNext");
            this.toolStripButtonFileNext.Name = "toolStripButtonFileNext";
            // 
            // toolStripButtonFileSettings
            // 
            resources.ApplyResources(this.toolStripButtonFileSettings, "toolStripButtonFileSettings");
            this.toolStripButtonFileSettings.Name = "toolStripButtonFileSettings";
            // 
            // toolStripButtonFileAbout
            // 
            this.toolStripButtonFileAbout.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_information_circle_32x32;
            resources.ApplyResources(this.toolStripButtonFileAbout, "toolStripButtonFileAbout");
            this.toolStripButtonFileAbout.Name = "toolStripButtonFileAbout";
            // 
            // toolStripDropDownButtonFileLanguage
            // 
            this.toolStripDropDownButtonFileLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLangEnglish,
            this.toolStripMenuItemLangGerman,
            this.toolStripMenuItemLangFrench,
            this.toolStripMenuItemLangSpanish,
            this.toolStripMenuItemLangItalian,
            this.toolStripMenuItemLangChinese,
            this.toolStripMenuItemLangJapanese,
            this.toolStripMenuItemLangPolish});
            this.toolStripDropDownButtonFileLanguage.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_translate_32x32;
            resources.ApplyResources(this.toolStripDropDownButtonFileLanguage, "toolStripDropDownButtonFileLanguage");
            this.toolStripDropDownButtonFileLanguage.Name = "toolStripDropDownButtonFileLanguage";
            this.toolStripDropDownButtonFileLanguage.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButtonFileLanguage_DropDownItemClicked);
            // 
            // toolStripMenuItemLangEnglish
            // 
            this.toolStripMenuItemLangEnglish.Name = "toolStripMenuItemLangEnglish";
            resources.ApplyResources(this.toolStripMenuItemLangEnglish, "toolStripMenuItemLangEnglish");
            // 
            // toolStripMenuItemLangGerman
            // 
            this.toolStripMenuItemLangGerman.Name = "toolStripMenuItemLangGerman";
            resources.ApplyResources(this.toolStripMenuItemLangGerman, "toolStripMenuItemLangGerman");
            // 
            // toolStripMenuItemLangFrench
            // 
            this.toolStripMenuItemLangFrench.Name = "toolStripMenuItemLangFrench";
            resources.ApplyResources(this.toolStripMenuItemLangFrench, "toolStripMenuItemLangFrench");
            // 
            // toolStripMenuItemLangSpanish
            // 
            this.toolStripMenuItemLangSpanish.Name = "toolStripMenuItemLangSpanish";
            resources.ApplyResources(this.toolStripMenuItemLangSpanish, "toolStripMenuItemLangSpanish");
            // 
            // toolStripMenuItemLangItalian
            // 
            this.toolStripMenuItemLangItalian.Name = "toolStripMenuItemLangItalian";
            resources.ApplyResources(this.toolStripMenuItemLangItalian, "toolStripMenuItemLangItalian");
            // 
            // toolStripMenuItemLangChinese
            // 
            this.toolStripMenuItemLangChinese.Name = "toolStripMenuItemLangChinese";
            resources.ApplyResources(this.toolStripMenuItemLangChinese, "toolStripMenuItemLangChinese");
            // 
            // toolStripMenuItemLangJapanese
            // 
            this.toolStripMenuItemLangJapanese.Name = "toolStripMenuItemLangJapanese";
            resources.ApplyResources(this.toolStripMenuItemLangJapanese, "toolStripMenuItemLangJapanese");
            // 
            // toolStripMenuItemLangPolish
            // 
            this.toolStripMenuItemLangPolish.Name = "toolStripMenuItemLangPolish";
            resources.ApplyResources(this.toolStripMenuItemLangPolish, "toolStripMenuItemLangPolish");
            // 
            // timerHoverPositionChanged
            // 
            this.timerHoverPositionChanged.Interval = 50;
            this.timerHoverPositionChanged.Tick += new System.EventHandler(this.timerHoverPositionChanged_Tick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainerMain);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStripContainerMain.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.BottomToolStripPanel.PerformLayout();
            this.toolStripContainerMain.ContentPanel.ResumeLayout(false);
            this.toolStripContainerMain.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.LeftToolStripPanel.PerformLayout();
            this.toolStripContainerMain.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.TopToolStripPanel.PerformLayout();
            this.toolStripContainerMain.ResumeLayout(false);
            this.toolStripContainerMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoViewHover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.panelTasks.ResumeLayout(false);
            this.panelTasks.PerformLayout();
            this.contextMenuStripToolstripContainer.ResumeLayout(false);
            this.toolStripSelection.ResumeLayout(false);
            this.toolStripSelection.PerformLayout();
            this.toolStripTimeline.ResumeLayout(false);
            this.toolStripTimeline.PerformLayout();
            this.toolStripInternet.ResumeLayout(false);
            this.toolStripInternet.PerformLayout();
            this.toolStripTasks.ResumeLayout(false);
            this.toolStripTasks.PerformLayout();
            this.toolStripPlayback.ResumeLayout(false);
            this.toolStripPlayback.PerformLayout();
            this.toolStripFile.ResumeLayout(false);
            this.toolStripFile.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

