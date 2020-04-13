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
            this.comboBoxDefaultDirectory = new System.Windows.Forms.ComboBox();
            this.comboBoxOutputDirectory = new System.Windows.Forms.ComboBox();
            this.textBoxOutputFilePattern = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // textBoxFFmpegPath
            // 
            resources.ApplyResources(this.textBoxFFmpegPath, "textBoxFFmpegPath");
            this.textBoxFFmpegPath.Name = "textBoxFFmpegPath";
            this.toolTip1.SetToolTip(this.textBoxFFmpegPath, resources.GetString("textBoxFFmpegPath.ToolTip"));
            this.textBoxFFmpegPath.TextChanged += new System.EventHandler(this.textBoxFFmpegPath_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // textBoxVideoFileExtensions
            // 
            resources.ApplyResources(this.textBoxVideoFileExtensions, "textBoxVideoFileExtensions");
            this.textBoxVideoFileExtensions.Name = "textBoxVideoFileExtensions";
            this.textBoxVideoFileExtensions.ReadOnly = true;
            this.toolTip1.SetToolTip(this.textBoxVideoFileExtensions, resources.GetString("textBoxVideoFileExtensions.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // buttonOutputDirectory
            // 
            resources.ApplyResources(this.buttonOutputDirectory, "buttonOutputDirectory");
            this.buttonOutputDirectory.Name = "buttonOutputDirectory";
            this.toolTip1.SetToolTip(this.buttonOutputDirectory, resources.GetString("buttonOutputDirectory.ToolTip"));
            this.buttonOutputDirectory.UseVisualStyleBackColor = true;
            this.buttonOutputDirectory.Click += new System.EventHandler(this.buttonOutputDirectory_Click);
            // 
            // buttonFFmpegPath
            // 
            resources.ApplyResources(this.buttonFFmpegPath, "buttonFFmpegPath");
            this.buttonFFmpegPath.Name = "buttonFFmpegPath";
            this.toolTip1.SetToolTip(this.buttonFFmpegPath, resources.GetString("buttonFFmpegPath.ToolTip"));
            this.buttonFFmpegPath.UseVisualStyleBackColor = true;
            this.buttonFFmpegPath.Click += new System.EventHandler(this.buttonFFmpegPath_Click);
            // 
            // buttonDefaultDirectory
            // 
            resources.ApplyResources(this.buttonDefaultDirectory, "buttonDefaultDirectory");
            this.buttonDefaultDirectory.Name = "buttonDefaultDirectory";
            this.toolTip1.SetToolTip(this.buttonDefaultDirectory, resources.GetString("buttonDefaultDirectory.ToolTip"));
            this.buttonDefaultDirectory.UseVisualStyleBackColor = true;
            this.buttonDefaultDirectory.Click += new System.EventHandler(this.buttonDefaultDirectory_Click);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // comboBoxDefaultDirectory
            // 
            resources.ApplyResources(this.comboBoxDefaultDirectory, "comboBoxDefaultDirectory");
            this.comboBoxDefaultDirectory.FormattingEnabled = true;
            this.comboBoxDefaultDirectory.Items.AddRange(new object[] {
            resources.GetString("comboBoxDefaultDirectory.Items"),
            resources.GetString("comboBoxDefaultDirectory.Items1"),
            resources.GetString("comboBoxDefaultDirectory.Items2")});
            this.comboBoxDefaultDirectory.Name = "comboBoxDefaultDirectory";
            this.toolTip1.SetToolTip(this.comboBoxDefaultDirectory, resources.GetString("comboBoxDefaultDirectory.ToolTip"));
            // 
            // comboBoxOutputDirectory
            // 
            resources.ApplyResources(this.comboBoxOutputDirectory, "comboBoxOutputDirectory");
            this.comboBoxOutputDirectory.FormattingEnabled = true;
            this.comboBoxOutputDirectory.Items.AddRange(new object[] {
            resources.GetString("comboBoxOutputDirectory.Items"),
            resources.GetString("comboBoxOutputDirectory.Items1"),
            resources.GetString("comboBoxOutputDirectory.Items2"),
            resources.GetString("comboBoxOutputDirectory.Items3")});
            this.comboBoxOutputDirectory.Name = "comboBoxOutputDirectory";
            this.toolTip1.SetToolTip(this.comboBoxOutputDirectory, resources.GetString("comboBoxOutputDirectory.ToolTip"));
            // 
            // textBoxOutputFilePattern
            // 
            resources.ApplyResources(this.textBoxOutputFilePattern, "textBoxOutputFilePattern");
            this.textBoxOutputFilePattern.Name = "textBoxOutputFilePattern";
            this.toolTip1.SetToolTip(this.textBoxOutputFilePattern, resources.GetString("textBoxOutputFilePattern.ToolTip"));
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.toolTip1.SetToolTip(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.toolTip1.SetToolTip(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.toolTip1.SetToolTip(this.buttonCancel, resources.GetString("buttonCancel.ToolTip"));
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.toolTip1.SetToolTip(this.buttonOK, resources.GetString("buttonOK.ToolTip"));
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
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