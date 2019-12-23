namespace SimpleVideoCutter
{
    partial class FormAddTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddTask));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSaveProfile = new System.Windows.Forms.Button();
            this.labelFFmpegArguments = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.labelFFmpegProfile = new System.Windows.Forms.Label();
            this.textBoxOutputFilePath = new System.Windows.Forms.TextBox();
            this.labelOriginalFilePath = new System.Windows.Forms.Label();
            this.textBoxOriginalFilePath = new System.Windows.Forms.TextBox();
            this.labelOutputFilePath = new System.Windows.Forms.Label();
            this.comboBoxFFmpegProfile = new System.Windows.Forms.ComboBox();
            this.textBoxFFmpegArguments = new System.Windows.Forms.TextBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonEnqueue = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveProfile, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelFFmpegArguments, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDuration, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelFFmpegProfile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOutputFilePath, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelOriginalFilePath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOriginalFilePath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelOutputFilePath, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFFmpegProfile, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFFmpegArguments, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelDuration, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFileType, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 104);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 181);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonSaveProfile
            // 
            this.buttonSaveProfile.Location = new System.Drawing.Point(450, 66);
            this.buttonSaveProfile.Name = "buttonSaveProfile";
            this.buttonSaveProfile.Size = new System.Drawing.Size(160, 23);
            this.buttonSaveProfile.TabIndex = 1;
            this.buttonSaveProfile.Text = "Create or update profile";
            this.buttonSaveProfile.UseVisualStyleBackColor = true;
            this.buttonSaveProfile.Click += new System.EventHandler(this.buttonSaveProfile_Click);
            // 
            // labelFFmpegArguments
            // 
            this.labelFFmpegArguments.AutoSize = true;
            this.labelFFmpegArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFFmpegArguments.Location = new System.Drawing.Point(13, 63);
            this.labelFFmpegArguments.Name = "labelFFmpegArguments";
            this.labelFFmpegArguments.Size = new System.Drawing.Size(97, 29);
            this.labelFFmpegArguments.TabIndex = 1;
            this.labelFFmpegArguments.Text = "FFmpeg arguments";
            this.labelFFmpegArguments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDuration.Location = new System.Drawing.Point(116, 148);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.ReadOnly = true;
            this.textBoxDuration.Size = new System.Drawing.Size(328, 20);
            this.textBoxDuration.TabIndex = 2;
            // 
            // labelFFmpegProfile
            // 
            this.labelFFmpegProfile.AutoSize = true;
            this.labelFFmpegProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFFmpegProfile.Location = new System.Drawing.Point(13, 36);
            this.labelFFmpegProfile.Name = "labelFFmpegProfile";
            this.labelFFmpegProfile.Size = new System.Drawing.Size(97, 27);
            this.labelFFmpegProfile.TabIndex = 4;
            this.labelFFmpegProfile.Text = "FFmpeg profile:";
            this.labelFFmpegProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxOutputFilePath
            // 
            this.textBoxOutputFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutputFilePath.Location = new System.Drawing.Point(116, 122);
            this.textBoxOutputFilePath.Name = "textBoxOutputFilePath";
            this.textBoxOutputFilePath.ReadOnly = true;
            this.textBoxOutputFilePath.Size = new System.Drawing.Size(328, 20);
            this.textBoxOutputFilePath.TabIndex = 2;
            // 
            // labelOriginalFilePath
            // 
            this.labelOriginalFilePath.AutoSize = true;
            this.labelOriginalFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOriginalFilePath.Location = new System.Drawing.Point(13, 10);
            this.labelOriginalFilePath.Name = "labelOriginalFilePath";
            this.labelOriginalFilePath.Size = new System.Drawing.Size(97, 26);
            this.labelOriginalFilePath.TabIndex = 0;
            this.labelOriginalFilePath.Text = "Original file path:";
            this.labelOriginalFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxOriginalFilePath
            // 
            this.textBoxOriginalFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOriginalFilePath.Location = new System.Drawing.Point(116, 13);
            this.textBoxOriginalFilePath.Name = "textBoxOriginalFilePath";
            this.textBoxOriginalFilePath.ReadOnly = true;
            this.textBoxOriginalFilePath.Size = new System.Drawing.Size(328, 20);
            this.textBoxOriginalFilePath.TabIndex = 1;
            // 
            // labelOutputFilePath
            // 
            this.labelOutputFilePath.AutoSize = true;
            this.labelOutputFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOutputFilePath.Location = new System.Drawing.Point(13, 119);
            this.labelOutputFilePath.Name = "labelOutputFilePath";
            this.labelOutputFilePath.Size = new System.Drawing.Size(97, 26);
            this.labelOutputFilePath.TabIndex = 1;
            this.labelOutputFilePath.Text = "Output file path:";
            this.labelOutputFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxFFmpegProfile
            // 
            this.comboBoxFFmpegProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFFmpegProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFFmpegProfile.FormattingEnabled = true;
            this.comboBoxFFmpegProfile.Location = new System.Drawing.Point(116, 39);
            this.comboBoxFFmpegProfile.Name = "comboBoxFFmpegProfile";
            this.comboBoxFFmpegProfile.Size = new System.Drawing.Size(328, 21);
            this.comboBoxFFmpegProfile.TabIndex = 3;
            this.comboBoxFFmpegProfile.SelectedIndexChanged += new System.EventHandler(this.comboBoxFFmpegProfile_SelectedIndexChanged);
            // 
            // textBoxFFmpegArguments
            // 
            this.textBoxFFmpegArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFFmpegArguments.Location = new System.Drawing.Point(116, 66);
            this.textBoxFFmpegArguments.Name = "textBoxFFmpegArguments";
            this.textBoxFFmpegArguments.Size = new System.Drawing.Size(328, 20);
            this.textBoxFFmpegArguments.TabIndex = 6;
            this.textBoxFFmpegArguments.TextChanged += new System.EventHandler(this.textBoxFFmpegArguments_TextChanged);
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDuration.Location = new System.Drawing.Point(13, 145);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(97, 26);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Text = "Duration:";
            this.labelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(13, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Output file type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(450, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hint: can be changed in settings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Location = new System.Drawing.Point(116, 95);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(328, 21);
            this.comboBoxFileType.TabIndex = 11;
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonEnqueue);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 298);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(623, 46);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonEnqueue
            // 
            this.buttonEnqueue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEnqueue.Location = new System.Drawing.Point(525, 13);
            this.buttonEnqueue.Name = "buttonEnqueue";
            this.buttonEnqueue.Size = new System.Drawing.Size(75, 23);
            this.buttonEnqueue.TabIndex = 1;
            this.buttonEnqueue.Text = "Enqueue";
            this.buttonEnqueue.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(444, 13);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightYellow;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10);
            this.label3.Size = new System.Drawing.Size(623, 104);
            this.label3.TabIndex = 2;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // FormAddTask
            // 
            this.AcceptButton = this.buttonEnqueue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(623, 344);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddTask";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enqueue task";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelOriginalFilePath;
        private System.Windows.Forms.TextBox textBoxOriginalFilePath;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Label labelFFmpegProfile;
        private System.Windows.Forms.TextBox textBoxOutputFilePath;
        private System.Windows.Forms.Label labelOutputFilePath;
        private System.Windows.Forms.ComboBox comboBoxFFmpegProfile;
        private System.Windows.Forms.TextBox textBoxFFmpegArguments;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelFFmpegArguments;
        private System.Windows.Forms.Button buttonSaveProfile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonEnqueue;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.Label label3;
    }
}