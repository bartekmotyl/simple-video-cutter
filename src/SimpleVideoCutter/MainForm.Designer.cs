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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.videoViewHover = new LibVLCSharp.WinForms.VideoView();
            this.vlcControl1 = new LibVLCSharp.WinForms.VideoView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelVolume = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFileDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerHoverPositionChanged = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripSelection = new System.Windows.Forms.ToolStrip();
            this.toolStripFile = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelTasks = new System.Windows.Forms.Panel();
            this.listViewTasks = new System.Windows.Forms.ListView();
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTasks = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.videoCutterTimeline1 = new SimpleVideoCutter.VideoCutterTimeline();
            this.toolStripButtonSelectionSetStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionSetEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionGoToStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionGoToEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionEnqueue = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFileOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFilePrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFileNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFileSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowTasks = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewHover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripSelection.SuspendLayout();
            this.toolStripFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonShowTasks});
            this.toolStrip1.Location = new System.Drawing.Point(257, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(112, 54);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // videoViewHover
            // 
            this.videoViewHover.BackColor = System.Drawing.Color.Black;
            this.videoViewHover.Location = new System.Drawing.Point(0, 0);
            this.videoViewHover.MediaPlayer = null;
            this.videoViewHover.Name = "videoViewHover";
            this.videoViewHover.Size = new System.Drawing.Size(164, 108);
            this.videoViewHover.TabIndex = 6;
            this.videoViewHover.Text = "videoViewHover";
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.MediaPlayer = null;
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(895, 621);
            this.vlcControl1.TabIndex = 5;
            this.vlcControl1.Text = "videoView1";
            this.vlcControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.vlcControl1_MouseClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelVolume,
            this.toolStripStatusLabelFilePath,
            this.toolStripStatusLabelFileDate,
            this.toolStripStatusLabelIndex,
            this.toolStripStatusLabelSelection});
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(984, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelVolume
            // 
            this.toolStripStatusLabelVolume.Name = "toolStripStatusLabelVolume";
            this.toolStripStatusLabelVolume.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabelVolume.Text = "Volume: 100%";
            // 
            // toolStripStatusLabelFilePath
            // 
            this.toolStripStatusLabelFilePath.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabelFilePath.Name = "toolStripStatusLabelFilePath";
            this.toolStripStatusLabelFilePath.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabelFilePath.Text = "No file loaded";
            // 
            // toolStripStatusLabelFileDate
            // 
            this.toolStripStatusLabelFileDate.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabelFileDate.Name = "toolStripStatusLabelFileDate";
            this.toolStripStatusLabelFileDate.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelIndex
            // 
            this.toolStripStatusLabelIndex.Name = "toolStripStatusLabelIndex";
            this.toolStripStatusLabelIndex.Size = new System.Drawing.Size(24, 17);
            this.toolStripStatusLabelIndex.Text = "0/0";
            // 
            // toolStripStatusLabelSelection
            // 
            this.toolStripStatusLabelSelection.Name = "toolStripStatusLabelSelection";
            this.toolStripStatusLabelSelection.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLabelSelection.Text = "No selection";
            // 
            // timerHoverPositionChanged
            // 
            this.timerHoverPositionChanged.Interval = 50;
            this.timerHoverPositionChanged.Tick += new System.EventHandler(this.timerHoverPositionChanged_Tick);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(895, 685);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStripSelection);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(984, 739);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripFile);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripSelection
            // 
            this.toolStripSelection.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSelection.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSelectionSetStart,
            this.toolStripButtonSelectionSetEnd,
            this.toolStripButtonSelectionPlay,
            this.toolStripButtonSelectionClear,
            this.toolStripButtonSelectionGoToStart,
            this.toolStripButtonSelectionGoToEnd,
            this.toolStripButtonSelectionEnqueue});
            this.toolStripSelection.Location = new System.Drawing.Point(0, 3);
            this.toolStripSelection.Name = "toolStripSelection";
            this.toolStripSelection.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripSelection.Size = new System.Drawing.Size(89, 389);
            this.toolStripSelection.TabIndex = 0;
            this.toolStripSelection.Text = "Selection";
            // 
            // toolStripFile
            // 
            this.toolStripFile.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFile.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFileOpen,
            this.toolStripButtonFilePrev,
            this.toolStripButtonFileNext,
            this.toolStripButtonFileSettings});
            this.toolStripFile.Location = new System.Drawing.Point(3, 0);
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(254, 54);
            this.toolStripFile.TabIndex = 7;
            this.toolStripFile.Text = "File";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(895, 685);
            this.splitContainer1.SplitterDistance = 741;
            this.splitContainer1.TabIndex = 7;
            // 
            // panelTasks
            // 
            this.panelTasks.Controls.Add(this.listViewTasks);
            this.panelTasks.Controls.Add(this.labelTasks);
            this.panelTasks.Controls.Add(this.labelProgress);
            this.panelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTasks.Location = new System.Drawing.Point(0, 0);
            this.panelTasks.Name = "panelTasks";
            this.panelTasks.Size = new System.Drawing.Size(96, 100);
            this.panelTasks.TabIndex = 6;
            // 
            // listViewTasks
            // 
            this.listViewTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFilename,
            this.columnDuration});
            this.listViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTasks.HideSelection = false;
            this.listViewTasks.Location = new System.Drawing.Point(0, 13);
            this.listViewTasks.Name = "listViewTasks";
            this.listViewTasks.Size = new System.Drawing.Size(96, 74);
            this.listViewTasks.TabIndex = 1;
            this.listViewTasks.UseCompatibleStateImageBehavior = false;
            this.listViewTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnFilename
            // 
            this.columnFilename.Text = "Filename";
            this.columnFilename.Width = 101;
            // 
            // columnDuration
            // 
            this.columnDuration.Text = "Duration";
            this.columnDuration.Width = 69;
            // 
            // labelTasks
            // 
            this.labelTasks.AutoSize = true;
            this.labelTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTasks.Location = new System.Drawing.Point(0, 0);
            this.labelTasks.Name = "labelTasks";
            this.labelTasks.Size = new System.Drawing.Size(36, 13);
            this.labelTasks.TabIndex = 0;
            this.labelTasks.Text = "Tasks";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelProgress.Location = new System.Drawing.Point(0, 87);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 13);
            this.labelProgress.TabIndex = 2;
            // 
            // videoCutterTimeline1
            // 
            this.videoCutterTimeline1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.videoCutterTimeline1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.videoCutterTimeline1.HoverPosition = null;
            this.videoCutterTimeline1.Length = ((long)(0));
            this.videoCutterTimeline1.Location = new System.Drawing.Point(0, 621);
            this.videoCutterTimeline1.Name = "videoCutterTimeline1";
            this.videoCutterTimeline1.Position = ((long)(0));
            this.videoCutterTimeline1.Size = new System.Drawing.Size(895, 64);
            this.videoCutterTimeline1.TabIndex = 4;
            this.videoCutterTimeline1.Time = ((long)(0));
            // 
            // toolStripButtonSelectionSetStart
            // 
            this.toolStripButtonSelectionSetStart.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_diagram_arrow_dash_right_32x32;
            this.toolStripButtonSelectionSetStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionSetStart.Name = "toolStripButtonSelectionSetStart";
            this.toolStripButtonSelectionSetStart.Size = new System.Drawing.Size(87, 51);
            this.toolStripButtonSelectionSetStart.Text = "Set start";
            this.toolStripButtonSelectionSetStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSelectionSetStart.ToolTipText = "Test tooltip";
            // 
            // toolStripButtonSelectionSetEnd
            // 
            this.toolStripButtonSelectionSetEnd.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_diagram_arrow_dash_left_32x32;
            this.toolStripButtonSelectionSetEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionSetEnd.Name = "toolStripButtonSelectionSetEnd";
            this.toolStripButtonSelectionSetEnd.Size = new System.Drawing.Size(87, 51);
            this.toolStripButtonSelectionSetEnd.Text = "Set end";
            this.toolStripButtonSelectionSetEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSelectionSetEnd.ToolTipText = "Test tooltip";
            // 
            // toolStripButtonSelectionPlay
            // 
            this.toolStripButtonSelectionPlay.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_video_player_slider_32x32;
            this.toolStripButtonSelectionPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionPlay.Name = "toolStripButtonSelectionPlay";
            this.toolStripButtonSelectionPlay.Size = new System.Drawing.Size(87, 51);
            this.toolStripButtonSelectionPlay.Text = "Play range";
            this.toolStripButtonSelectionPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSelectionPlay.ToolTipText = "Test tooltip";
            // 
            // toolStripButtonSelectionClear
            // 
            this.toolStripButtonSelectionClear.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_eraser_32x32;
            this.toolStripButtonSelectionClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionClear.Name = "toolStripButtonSelectionClear";
            this.toolStripButtonSelectionClear.Size = new System.Drawing.Size(87, 51);
            this.toolStripButtonSelectionClear.Text = "Clear selection";
            this.toolStripButtonSelectionClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSelectionClear.ToolTipText = "Test tooltip";
            // 
            // toolStripButtonSelectionGoToStart
            // 
            this.toolStripButtonSelectionGoToStart.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_arrow_button_right_3_32x32;
            this.toolStripButtonSelectionGoToStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionGoToStart.Name = "toolStripButtonSelectionGoToStart";
            this.toolStripButtonSelectionGoToStart.Size = new System.Drawing.Size(87, 51);
            this.toolStripButtonSelectionGoToStart.Text = "Go to start";
            this.toolStripButtonSelectionGoToStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSelectionGoToStart.ToolTipText = "Test tooltip";
            // 
            // toolStripButtonSelectionGoToEnd
            // 
            this.toolStripButtonSelectionGoToEnd.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_arrow_button_left_3_32x32;
            this.toolStripButtonSelectionGoToEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionGoToEnd.Name = "toolStripButtonSelectionGoToEnd";
            this.toolStripButtonSelectionGoToEnd.Size = new System.Drawing.Size(87, 51);
            this.toolStripButtonSelectionGoToEnd.Text = "Go to end";
            this.toolStripButtonSelectionGoToEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSelectionGoToEnd.ToolTipText = "Test tooltip";
            // 
            // toolStripButtonSelectionEnqueue
            // 
            this.toolStripButtonSelectionEnqueue.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_task_list_add_32x32;
            this.toolStripButtonSelectionEnqueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionEnqueue.Name = "toolStripButtonSelectionEnqueue";
            this.toolStripButtonSelectionEnqueue.Size = new System.Drawing.Size(87, 51);
            this.toolStripButtonSelectionEnqueue.Text = "Enqueue";
            this.toolStripButtonSelectionEnqueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSelectionEnqueue.Click += new System.EventHandler(this.toolStripButtonAddTask_Click);
            // 
            // toolStripButtonFileOpen
            // 
            this.toolStripButtonFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFileOpen.Image")));
            this.toolStripButtonFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFileOpen.Name = "toolStripButtonFileOpen";
            this.toolStripButtonFileOpen.Size = new System.Drawing.Size(59, 51);
            this.toolStripButtonFileOpen.Text = "Open file";
            this.toolStripButtonFileOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFileOpen.Click += new System.EventHandler(this.toolStripButtonFileOpen_Click);
            // 
            // toolStripButtonFilePrev
            // 
            this.toolStripButtonFilePrev.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFilePrev.Image")));
            this.toolStripButtonFilePrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFilePrev.Name = "toolStripButtonFilePrev";
            this.toolStripButtonFilePrev.Size = new System.Drawing.Size(75, 51);
            this.toolStripButtonFilePrev.Text = "Previous file";
            this.toolStripButtonFilePrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFilePrev.Click += new System.EventHandler(this.toolStripButtonPreviousFile_Click);
            // 
            // toolStripButtonFileNext
            // 
            this.toolStripButtonFileNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFileNext.Image")));
            this.toolStripButtonFileNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFileNext.Name = "toolStripButtonFileNext";
            this.toolStripButtonFileNext.Size = new System.Drawing.Size(55, 51);
            this.toolStripButtonFileNext.Text = "Next file";
            this.toolStripButtonFileNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFileNext.Click += new System.EventHandler(this.toolStripButtonNextFile_Click);
            // 
            // toolStripButtonFileSettings
            // 
            this.toolStripButtonFileSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFileSettings.Image")));
            this.toolStripButtonFileSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFileSettings.Name = "toolStripButtonFileSettings";
            this.toolStripButtonFileSettings.Size = new System.Drawing.Size(53, 51);
            this.toolStripButtonFileSettings.Text = "Settings";
            this.toolStripButtonFileSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFileSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
            // 
            // toolStripButtonShowTasks
            // 
            this.toolStripButtonShowTasks.CheckOnClick = true;
            this.toolStripButtonShowTasks.Image = global::SimpleVideoCutter.Properties.Resources.streamline_icon_task_list_clock_32x32;
            this.toolStripButtonShowTasks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowTasks.Name = "toolStripButtonShowTasks";
            this.toolStripButtonShowTasks.Size = new System.Drawing.Size(69, 51);
            this.toolStripButtonShowTasks.Text = "Show tasks";
            this.toolStripButtonShowTasks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonShowTasks.CheckedChanged += new System.EventHandler(this.toolStripButtonShowTasks_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.Text = "Simple video cutter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewHover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripSelection.ResumeLayout(false);
            this.toolStripSelection.PerformLayout();
            this.toolStripFile.ResumeLayout(false);
            this.toolStripFile.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelTasks.ResumeLayout(false);
            this.panelTasks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VideoCutterTimeline videoCutterTimeline1;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.ToolStripButton toolStripButtonShowTasks;
        private LibVLCSharp.WinForms.VideoView vlcControl1;
        private LibVLCSharp.WinForms.VideoView videoViewHover;
        private System.Windows.Forms.Timer timerHoverPositionChanged;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
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
    }
}

