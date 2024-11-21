namespace SimpleVideoCutter
{
    partial class ChooseOutputDirectory
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
            labelPath = new System.Windows.Forms.Label();
            panelMain = new System.Windows.Forms.Panel();
            toggleEditModeButton = new System.Windows.Forms.Button();
            panelDirectoryList = new System.Windows.Forms.FlowLayoutPanel();
            labelDialogExplanation = new System.Windows.Forms.Label();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // labelPath
            // 
            labelPath.AutoSize = true;
            labelPath.Location = new System.Drawing.Point(10, 20);
            labelPath.Name = "labelPath";
            labelPath.Size = new System.Drawing.Size(37, 20);
            labelPath.TabIndex = 12;
            labelPath.Text = "Path";
            // 
            // panelMain
            // 
            panelMain.AutoSize = true;
            panelMain.Controls.Add(toggleEditModeButton);
            panelMain.Controls.Add(labelPath);
            panelMain.Controls.Add(panelDirectoryList);
            panelMain.Controls.Add(labelDialogExplanation);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(543, 232);
            panelMain.TabIndex = 14;
            // 
            // toggleEditModeButton
            // 
            toggleEditModeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            toggleEditModeButton.Location = new System.Drawing.Point(349, 191);
            toggleEditModeButton.Name = "toggleEditModeButton";
            toggleEditModeButton.Size = new System.Drawing.Size(182, 29);
            toggleEditModeButton.TabIndex = 16;
            toggleEditModeButton.Text = "Edit directories";
            toggleEditModeButton.UseVisualStyleBackColor = true;
            toggleEditModeButton.Click += ToggleEditModeButton_Click;
            // 
            // panelDirectoryList
            // 
            panelDirectoryList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelDirectoryList.AutoSize = true;
            panelDirectoryList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            panelDirectoryList.Location = new System.Drawing.Point(1, 85);
            panelDirectoryList.MinimumSize = new System.Drawing.Size(101, 100);
            panelDirectoryList.Name = "panelDirectoryList";
            panelDirectoryList.Size = new System.Drawing.Size(542, 100);
            panelDirectoryList.TabIndex = 14;
            panelDirectoryList.WrapContents = false;
            // 
            // labelDialogExplanation
            // 
            labelDialogExplanation.AutoSize = true;
            labelDialogExplanation.Location = new System.Drawing.Point(10, 0);
            labelDialogExplanation.Name = "labelDialogExplanation";
            labelDialogExplanation.Size = new System.Drawing.Size(530, 20);
            labelDialogExplanation.TabIndex = 15;
            labelDialogExplanation.Text = "Press a number key to output the video into the corresponding subdirectory of ";
            // 
            // ChooseOutputDirectory
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(543, 232);
            Controls.Add(panelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseOutputDirectory";
            ShowInTaskbar = false;
            Text = "Output to Subdirectory";
            KeyDown += ChooseOutputDirectory_KeyDown;
            KeyPress += ChooseOutputDirectory_KeyPress;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button toggleEditModeButton;
        private System.Windows.Forms.FlowLayoutPanel panelDirectoryList;
        private System.Windows.Forms.Label labelDialogExplanation;
    }
}