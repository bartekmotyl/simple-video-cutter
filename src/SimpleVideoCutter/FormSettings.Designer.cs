namespace SimpleVideoCutter
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFFmpegPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVideoFileExtensions = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOutputDirectory = new System.Windows.Forms.Button();
            this.buttonFFmpegPath = new System.Windows.Forms.Button();
            this.buttonDefaultDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxDefaultDirectory = new System.Windows.Forms.ComboBox();
            this.comboBoxOutputDirectory = new System.Windows.Forms.ComboBox();
            this.textBoxOutputFilePattern = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default directory:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output directory:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output file pattern:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxFFmpegPath
            // 
            this.textBoxFFmpegPath.Location = new System.Drawing.Point(129, 87);
            this.textBoxFFmpegPath.Name = "textBoxFFmpegPath";
            this.textBoxFFmpegPath.Size = new System.Drawing.Size(344, 20);
            this.textBoxFFmpegPath.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBoxFFmpegPath, "Path to ffmepg.exe executable");
            this.textBoxFFmpegPath.TextChanged += new System.EventHandler(this.textBoxFFmpegPath_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "ffmpeg.exe path:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxVideoFileExtensions
            // 
            this.textBoxVideoFileExtensions.Location = new System.Drawing.Point(129, 116);
            this.textBoxVideoFileExtensions.Name = "textBoxVideoFileExtensions";
            this.textBoxVideoFileExtensions.ReadOnly = true;
            this.textBoxVideoFileExtensions.Size = new System.Drawing.Size(344, 20);
            this.textBoxVideoFileExtensions.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBoxVideoFileExtensions, "Comma separated list of extensions (with dot) \r\nof video files to be considered. " +
        "Important when \r\nnavigating to previous/next video file in directory. ");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Exensions of video files:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonOutputDirectory
            // 
            this.buttonOutputDirectory.Location = new System.Drawing.Point(479, 32);
            this.buttonOutputDirectory.Name = "buttonOutputDirectory";
            this.buttonOutputDirectory.Size = new System.Drawing.Size(30, 23);
            this.buttonOutputDirectory.TabIndex = 10;
            this.buttonOutputDirectory.Text = "...";
            this.buttonOutputDirectory.UseVisualStyleBackColor = true;
            this.buttonOutputDirectory.Click += new System.EventHandler(this.buttonOutputDirectory_Click);
            // 
            // buttonFFmpegPath
            // 
            this.buttonFFmpegPath.Location = new System.Drawing.Point(479, 87);
            this.buttonFFmpegPath.Name = "buttonFFmpegPath";
            this.buttonFFmpegPath.Size = new System.Drawing.Size(30, 23);
            this.buttonFFmpegPath.TabIndex = 12;
            this.buttonFFmpegPath.Text = "...";
            this.buttonFFmpegPath.UseVisualStyleBackColor = true;
            this.buttonFFmpegPath.Click += new System.EventHandler(this.buttonFFmpegPath_Click);
            // 
            // buttonDefaultDirectory
            // 
            this.buttonDefaultDirectory.Location = new System.Drawing.Point(479, 3);
            this.buttonDefaultDirectory.Name = "buttonDefaultDirectory";
            this.buttonDefaultDirectory.Size = new System.Drawing.Size(30, 23);
            this.buttonDefaultDirectory.TabIndex = 13;
            this.buttonDefaultDirectory.Text = "...";
            this.buttonDefaultDirectory.UseVisualStyleBackColor = true;
            this.buttonDefaultDirectory.Click += new System.EventHandler(this.buttonDefaultDirectory_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.comboBoxOutputDirectory, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxVideoFileExtensions, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonFFmpegPath, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDefaultDirectory, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOutputDirectory, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFFmpegPath, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDefaultDirectory, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOutputFilePattern, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 162);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 168);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(549, 29);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(471, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(390, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // comboBoxDefaultDirectory
            // 
            this.comboBoxDefaultDirectory.FormattingEnabled = true;
            this.comboBoxDefaultDirectory.Items.AddRange(new object[] {
            "{UserVideos}",
            "{UserDocuments}",
            "{MyComputer}"});
            this.comboBoxDefaultDirectory.Location = new System.Drawing.Point(129, 3);
            this.comboBoxDefaultDirectory.Name = "comboBoxDefaultDirectory";
            this.comboBoxDefaultDirectory.Size = new System.Drawing.Size(344, 21);
            this.comboBoxDefaultDirectory.TabIndex = 14;
            this.toolTip1.SetToolTip(this.comboBoxDefaultDirectory, "Initial directory when opening video files. \r\nCan be specified either as absolute" +
        " path \r\nor by using one of predefined directories: \r\n{UserVideos}\r\n{UserDocument" +
        "s}\r\n{MyComputer}");
            // 
            // comboBoxOutputDirectory
            // 
            this.comboBoxOutputDirectory.FormattingEnabled = true;
            this.comboBoxOutputDirectory.Items.AddRange(new object[] {
            "{UserVideos}",
            "{UserDocuments}",
            "{MyComputer}"});
            this.comboBoxOutputDirectory.Location = new System.Drawing.Point(129, 32);
            this.comboBoxOutputDirectory.Name = "comboBoxOutputDirectory";
            this.comboBoxOutputDirectory.Size = new System.Drawing.Size(344, 21);
            this.comboBoxOutputDirectory.TabIndex = 15;
            this.toolTip1.SetToolTip(this.comboBoxOutputDirectory, "Output directory where created files are to be saved. \r\nCan be specified either a" +
        "s absolute path \r\nor by using one of predefined directories: \r\n{UserVideos}\r\n{Us" +
        "erDocuments}\r\n{MyComputer}\r\n");
            // 
            // textBoxOutputFilePattern
            // 
            this.textBoxOutputFilePattern.Location = new System.Drawing.Point(129, 61);
            this.textBoxOutputFilePattern.Name = "textBoxOutputFilePattern";
            this.textBoxOutputFilePattern.Size = new System.Drawing.Size(344, 20);
            this.textBoxOutputFilePattern.TabIndex = 16;
            this.toolTip1.SetToolTip(this.textBoxOutputFilePattern, resources.GetString("textBoxOutputFilePattern.ToolTip"));
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(549, 197);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFFmpegPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVideoFileExtensions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOutputDirectory;
        private System.Windows.Forms.Button buttonFFmpegPath;
        private System.Windows.Forms.Button buttonDefaultDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxOutputDirectory;
        private System.Windows.Forms.ComboBox comboBoxDefaultDirectory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxOutputFilePattern;
    }
}