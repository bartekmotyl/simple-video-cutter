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
            this.toolStripButtonFileOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPreviousFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNextFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSetStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSetEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddTask = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowTasks = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.panelTasks = new System.Windows.Forms.Panel();
            this.listViewTasks = new System.Windows.Forms.ListView();
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTasks = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelVolume = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFileDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.vlcControl1 = new LibVLCSharp.WinForms.VideoView();
            this.videoViewHover = new LibVLCSharp.WinForms.VideoView();
            this.timerHoverPositionChanged = new System.Windows.Forms.Timer(this.components);
            this.videoCutterTimeline1 = new SimpleVideoCutter.VideoCutterTimeline();
            this.toolStrip1.SuspendLayout();
            this.panelTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewHover)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFileOpen,
            this.toolStripSeparator1,
            this.toolStripButtonPreviousFile,
            this.toolStripButtonNextFile,
            this.toolStripSeparator4,
            this.toolStripButtonSetStart,
            this.toolStripButtonSetEnd,
            this.toolStripButtonClearSelection,
            this.toolStripSeparator2,
            this.toolStripButtonAddTask,
            this.toolStripSeparator3,
            this.toolStripButtonShowTasks,
            this.toolStripSeparator5,
            this.toolStripButtonSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(922, 54);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonFileOpen
            // 
            this.toolStripButtonFileOpen.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_folder_293677;
            this.toolStripButtonFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFileOpen.Name = "toolStripButtonFileOpen";
            this.toolStripButtonFileOpen.Size = new System.Drawing.Size(68, 51);
            this.toolStripButtonFileOpen.Text = "Open file...";
            this.toolStripButtonFileOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFileOpen.Click += new System.EventHandler(this.toolStripButtonFileOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonPreviousFile
            // 
            this.toolStripButtonPreviousFile.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_nav_left_293639;
            this.toolStripButtonPreviousFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreviousFile.Name = "toolStripButtonPreviousFile";
            this.toolStripButtonPreviousFile.Size = new System.Drawing.Size(75, 51);
            this.toolStripButtonPreviousFile.Text = "Previous file";
            this.toolStripButtonPreviousFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonPreviousFile.Click += new System.EventHandler(this.toolStripButtonPreviousFile_Click);
            // 
            // toolStripButtonNextFile
            // 
            this.toolStripButtonNextFile.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_nav_right_293640;
            this.toolStripButtonNextFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextFile.Name = "toolStripButtonNextFile";
            this.toolStripButtonNextFile.Size = new System.Drawing.Size(55, 51);
            this.toolStripButtonNextFile.Text = "Next file";
            this.toolStripButtonNextFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonNextFile.Click += new System.EventHandler(this.toolStripButtonNextFile_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonSetStart
            // 
            this.toolStripButtonSetStart.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_triangle__right_293653;
            this.toolStripButtonSetStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetStart.Name = "toolStripButtonSetStart";
            this.toolStripButtonSetStart.Size = new System.Drawing.Size(75, 51);
            this.toolStripButtonSetStart.Text = "Set clip start";
            this.toolStripButtonSetStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSetStart.Click += new System.EventHandler(this.toolStripButtonSetStart_Click);
            // 
            // toolStripButtonSetEnd
            // 
            this.toolStripButtonSetEnd.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_triangle__left_293652;
            this.toolStripButtonSetEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetEnd.Name = "toolStripButtonSetEnd";
            this.toolStripButtonSetEnd.Size = new System.Drawing.Size(72, 51);
            this.toolStripButtonSetEnd.Text = "Set clip end";
            this.toolStripButtonSetEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSetEnd.Click += new System.EventHandler(this.toolStripButtonSetEnd_Click);
            // 
            // toolStripButtonClearSelection
            // 
            this.toolStripButtonClearSelection.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_trash_293706;
            this.toolStripButtonClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSelection.Name = "toolStripButtonClearSelection";
            this.toolStripButtonClearSelection.Size = new System.Drawing.Size(93, 51);
            this.toolStripButtonClearSelection.Text = "Clear clip range";
            this.toolStripButtonClearSelection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonClearSelection.Click += new System.EventHandler(this.toolStripButtonClearSelection_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonAddTask
            // 
            this.toolStripButtonAddTask.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_video_293710;
            this.toolStripButtonAddTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddTask.Name = "toolStripButtonAddTask";
            this.toolStripButtonAddTask.Size = new System.Drawing.Size(103, 51);
            this.toolStripButtonAddTask.Text = "Enqueue clip task";
            this.toolStripButtonAddTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAddTask.Click += new System.EventHandler(this.toolStripButtonAddTask_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonShowTasks
            // 
            this.toolStripButtonShowTasks.CheckOnClick = true;
            this.toolStripButtonShowTasks.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_list_293685;
            this.toolStripButtonShowTasks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowTasks.Name = "toolStripButtonShowTasks";
            this.toolStripButtonShowTasks.Size = new System.Drawing.Size(69, 51);
            this.toolStripButtonShowTasks.Text = "Show tasks";
            this.toolStripButtonShowTasks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonShowTasks.CheckedChanged += new System.EventHandler(this.toolStripButtonShowTasks_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.Image = global::SimpleVideoCutter.Properties.Resources.iconfinder_cog_293670;
            this.toolStripButtonSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(53, 51);
            this.toolStripButtonSettings.Text = "Settings";
            this.toolStripButtonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
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
            this.splitContainer1.Size = new System.Drawing.Size(922, 488);
            this.splitContainer1.SplitterDistance = 741;
            this.splitContainer1.TabIndex = 7;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelVolume,
            this.toolStripStatusLabelFilePath,
            this.toolStripStatusLabelFileDate,
            this.toolStripStatusLabelIndex,
            this.toolStripStatusLabelSelection});
            this.statusStrip.Location = new System.Drawing.Point(0, 542);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(922, 22);
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
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.MediaPlayer = null;
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(922, 432);
            this.vlcControl1.TabIndex = 5;
            this.vlcControl1.Text = "videoView1";
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
            // timerHoverPositionChanged
            // 
            this.timerHoverPositionChanged.Interval = 50;
            this.timerHoverPositionChanged.Tick += new System.EventHandler(this.timerHoverPositionChanged_Tick);
            // 
            // videoCutterTimeline1
            // 
            this.videoCutterTimeline1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.videoCutterTimeline1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.videoCutterTimeline1.HoverPosition = null;
            this.videoCutterTimeline1.Length = ((long)(0));
            this.videoCutterTimeline1.Location = new System.Drawing.Point(0, 432);
            this.videoCutterTimeline1.Name = "videoCutterTimeline1";
            this.videoCutterTimeline1.Position = ((long)(0));
            this.videoCutterTimeline1.Size = new System.Drawing.Size(922, 56);
            this.videoCutterTimeline1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 564);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Simple video cutter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelTasks.ResumeLayout(false);
            this.panelTasks.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewHover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VideoCutterTimeline videoCutterTimeline1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetEnd;
        private System.Windows.Forms.Panel panelTasks;
        private System.Windows.Forms.ListView listViewTasks;
        private System.Windows.Forms.Label labelTasks;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddTask;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSelection;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonPreviousFile;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ColumnHeader columnDuration;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVolume;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFilePath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFileDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelIndex;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowTasks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private LibVLCSharp.WinForms.VideoView vlcControl1;
        private LibVLCSharp.WinForms.VideoView videoViewHover;
        private System.Windows.Forms.Timer timerHoverPositionChanged;
    }
}

