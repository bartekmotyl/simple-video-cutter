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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            textBoxFFmpegPath = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBoxVideoFileExtensions = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            buttonOutputDirectory = new System.Windows.Forms.Button();
            buttonFFmpegPath = new System.Windows.Forms.Button();
            buttonDefaultDirectory = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            comboBoxDefaultDirectory = new System.Windows.Forms.ComboBox();
            comboBoxOutputDirectory = new System.Windows.Forms.ComboBox();
            textBoxOutputFilePattern = new System.Windows.Forms.TextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            comboBoxPreviewSize = new System.Windows.Forms.ComboBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonCancel = new System.Windows.Forms.Button();
            buttonOK = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // textBoxFFmpegPath
            // 
            resources.ApplyResources(textBoxFFmpegPath, "textBoxFFmpegPath");
            textBoxFFmpegPath.Name = "textBoxFFmpegPath";
            toolTip1.SetToolTip(textBoxFFmpegPath, resources.GetString("textBoxFFmpegPath.ToolTip"));
            textBoxFFmpegPath.TextChanged += textBoxFFmpegPath_TextChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // textBoxVideoFileExtensions
            // 
            resources.ApplyResources(textBoxVideoFileExtensions, "textBoxVideoFileExtensions");
            textBoxVideoFileExtensions.Name = "textBoxVideoFileExtensions";
            textBoxVideoFileExtensions.ReadOnly = true;
            toolTip1.SetToolTip(textBoxVideoFileExtensions, resources.GetString("textBoxVideoFileExtensions.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // buttonOutputDirectory
            // 
            resources.ApplyResources(buttonOutputDirectory, "buttonOutputDirectory");
            buttonOutputDirectory.Name = "buttonOutputDirectory";
            buttonOutputDirectory.UseVisualStyleBackColor = true;
            buttonOutputDirectory.Click += buttonOutputDirectory_Click;
            // 
            // buttonFFmpegPath
            // 
            resources.ApplyResources(buttonFFmpegPath, "buttonFFmpegPath");
            buttonFFmpegPath.Name = "buttonFFmpegPath";
            buttonFFmpegPath.UseVisualStyleBackColor = true;
            buttonFFmpegPath.Click += buttonFFmpegPath_Click;
            // 
            // buttonDefaultDirectory
            // 
            resources.ApplyResources(buttonDefaultDirectory, "buttonDefaultDirectory");
            buttonDefaultDirectory.Name = "buttonDefaultDirectory";
            buttonDefaultDirectory.UseVisualStyleBackColor = true;
            buttonDefaultDirectory.Click += buttonDefaultDirectory_Click;
            // 
            // comboBoxDefaultDirectory
            // 
            resources.ApplyResources(comboBoxDefaultDirectory, "comboBoxDefaultDirectory");
            comboBoxDefaultDirectory.FormattingEnabled = true;
            comboBoxDefaultDirectory.Items.AddRange(new object[] { resources.GetString("comboBoxDefaultDirectory.Items"), resources.GetString("comboBoxDefaultDirectory.Items1"), resources.GetString("comboBoxDefaultDirectory.Items2") });
            comboBoxDefaultDirectory.Name = "comboBoxDefaultDirectory";
            toolTip1.SetToolTip(comboBoxDefaultDirectory, resources.GetString("comboBoxDefaultDirectory.ToolTip"));
            // 
            // comboBoxOutputDirectory
            // 
            resources.ApplyResources(comboBoxOutputDirectory, "comboBoxOutputDirectory");
            comboBoxOutputDirectory.FormattingEnabled = true;
            comboBoxOutputDirectory.Items.AddRange(new object[] { resources.GetString("comboBoxOutputDirectory.Items"), resources.GetString("comboBoxOutputDirectory.Items1"), resources.GetString("comboBoxOutputDirectory.Items2"), resources.GetString("comboBoxOutputDirectory.Items3") });
            comboBoxOutputDirectory.Name = "comboBoxOutputDirectory";
            toolTip1.SetToolTip(comboBoxOutputDirectory, resources.GetString("comboBoxOutputDirectory.ToolTip"));
            // 
            // textBoxOutputFilePattern
            // 
            resources.ApplyResources(textBoxOutputFilePattern, "textBoxOutputFilePattern");
            textBoxOutputFilePattern.Name = "textBoxOutputFilePattern";
            toolTip1.SetToolTip(textBoxOutputFilePattern, resources.GetString("textBoxOutputFilePattern.ToolTip"));
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(comboBoxOutputDirectory, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxVideoFileExtensions, 1, 6);
            tableLayoutPanel1.Controls.Add(buttonFFmpegPath, 2, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 6);
            tableLayoutPanel1.Controls.Add(buttonDefaultDirectory, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonOutputDirectory, 2, 1);
            tableLayoutPanel1.Controls.Add(textBoxFFmpegPath, 1, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 4);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(comboBoxDefaultDirectory, 1, 0);
            tableLayoutPanel1.Controls.Add(textBoxOutputFilePattern, 1, 3);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(comboBoxPreviewSize, 1, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // comboBoxPreviewSize
            // 
            resources.ApplyResources(comboBoxPreviewSize, "comboBoxPreviewSize");
            comboBoxPreviewSize.DisplayMember = "Title";
            comboBoxPreviewSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxPreviewSize.FormattingEnabled = true;
            comboBoxPreviewSize.Name = "comboBoxPreviewSize";
            comboBoxPreviewSize.ValueMember = "Value";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Controls.Add(buttonOK);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(buttonCancel, "buttonCancel");
            buttonCancel.Name = "buttonCancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(buttonOK, "buttonOK");
            buttonOK.Name = "buttonOK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // FormSettings
            // 
            AcceptButton = buttonOK;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancel;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSettings";
            ShowIcon = false;
            ShowInTaskbar = false;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPreviewSize;
    }
}