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
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // buttonSaveProfile
            // 
            resources.ApplyResources(this.buttonSaveProfile, "buttonSaveProfile");
            this.buttonSaveProfile.Name = "buttonSaveProfile";
            this.buttonSaveProfile.UseVisualStyleBackColor = true;
            this.buttonSaveProfile.Click += new System.EventHandler(this.buttonSaveProfile_Click);
            // 
            // labelFFmpegArguments
            // 
            resources.ApplyResources(this.labelFFmpegArguments, "labelFFmpegArguments");
            this.labelFFmpegArguments.Name = "labelFFmpegArguments";
            // 
            // textBoxDuration
            // 
            resources.ApplyResources(this.textBoxDuration, "textBoxDuration");
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.ReadOnly = true;
            // 
            // labelFFmpegProfile
            // 
            resources.ApplyResources(this.labelFFmpegProfile, "labelFFmpegProfile");
            this.labelFFmpegProfile.Name = "labelFFmpegProfile";
            // 
            // textBoxOutputFilePath
            // 
            resources.ApplyResources(this.textBoxOutputFilePath, "textBoxOutputFilePath");
            this.textBoxOutputFilePath.Name = "textBoxOutputFilePath";
            this.textBoxOutputFilePath.ReadOnly = true;
            // 
            // labelOriginalFilePath
            // 
            resources.ApplyResources(this.labelOriginalFilePath, "labelOriginalFilePath");
            this.labelOriginalFilePath.Name = "labelOriginalFilePath";
            // 
            // textBoxOriginalFilePath
            // 
            resources.ApplyResources(this.textBoxOriginalFilePath, "textBoxOriginalFilePath");
            this.textBoxOriginalFilePath.Name = "textBoxOriginalFilePath";
            this.textBoxOriginalFilePath.ReadOnly = true;
            // 
            // labelOutputFilePath
            // 
            resources.ApplyResources(this.labelOutputFilePath, "labelOutputFilePath");
            this.labelOutputFilePath.Name = "labelOutputFilePath";
            // 
            // comboBoxFFmpegProfile
            // 
            resources.ApplyResources(this.comboBoxFFmpegProfile, "comboBoxFFmpegProfile");
            this.comboBoxFFmpegProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFFmpegProfile.FormattingEnabled = true;
            this.comboBoxFFmpegProfile.Name = "comboBoxFFmpegProfile";
            this.comboBoxFFmpegProfile.SelectedIndexChanged += new System.EventHandler(this.comboBoxFFmpegProfile_SelectedIndexChanged);
            // 
            // textBoxFFmpegArguments
            // 
            resources.ApplyResources(this.textBoxFFmpegArguments, "textBoxFFmpegArguments");
            this.textBoxFFmpegArguments.Name = "textBoxFFmpegArguments";
            this.textBoxFFmpegArguments.TextChanged += new System.EventHandler(this.textBoxFFmpegArguments_TextChanged);
            // 
            // labelDuration
            // 
            resources.ApplyResources(this.labelDuration, "labelDuration");
            this.labelDuration.Name = "labelDuration";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBoxFileType
            // 
            resources.ApplyResources(this.comboBoxFileType, "comboBoxFileType");
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonEnqueue);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // buttonEnqueue
            // 
            this.buttonEnqueue.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.buttonEnqueue, "buttonEnqueue");
            this.buttonEnqueue.Name = "buttonEnqueue";
            this.buttonEnqueue.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightYellow;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // FormAddTask
            // 
            this.AcceptButton = this.buttonEnqueue;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddTask";
            this.ShowInTaskbar = false;
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