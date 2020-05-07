namespace SimpleVideoCutter
{
    partial class FormFFmpegMissingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFFmpegMissingDialog));
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelFFmpegExlanation = new System.Windows.Forms.Label();
            this.linkLabelFFmpeg = new System.Windows.Forms.LinkLabel();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFFmpegDownload = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelDownloadSuccessful = new System.Windows.Forms.Label();
            this.flowLayoutPanelButton = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelFFmpegExlanation
            // 
            resources.ApplyResources(this.labelFFmpegExlanation, "labelFFmpegExlanation");
            this.labelFFmpegExlanation.Name = "labelFFmpegExlanation";
            // 
            // linkLabelFFmpeg
            // 
            resources.ApplyResources(this.linkLabelFFmpeg, "linkLabelFFmpeg");
            this.linkLabelFFmpeg.Name = "linkLabelFFmpeg";
            this.linkLabelFFmpeg.TabStop = true;
            this.linkLabelFFmpeg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonDownload
            // 
            resources.ApplyResources(this.buttonDownload, "buttonDownload");
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // progressBarDownload
            // 
            resources.ApplyResources(this.progressBarDownload, "progressBarDownload");
            this.progressBarDownload.Name = "progressBarDownload";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelFFmpegDownload);
            this.flowLayoutPanel1.Controls.Add(this.linkLabelFFmpeg);
            this.flowLayoutPanel1.Controls.Add(this.buttonDownload);
            this.flowLayoutPanel1.Controls.Add(this.labelFFmpegExlanation);
            this.flowLayoutPanel1.Controls.Add(this.progressBarDownload);
            this.flowLayoutPanel1.Controls.Add(this.labelError);
            this.flowLayoutPanel1.Controls.Add(this.labelDownloadSuccessful);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // labelFFmpegDownload
            // 
            resources.ApplyResources(this.labelFFmpegDownload, "labelFFmpegDownload");
            this.labelFFmpegDownload.Name = "labelFFmpegDownload";
            // 
            // labelError
            // 
            resources.ApplyResources(this.labelError, "labelError");
            this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelError.Name = "labelError";
            // 
            // labelDownloadSuccessful
            // 
            resources.ApplyResources(this.labelDownloadSuccessful, "labelDownloadSuccessful");
            this.labelDownloadSuccessful.ForeColor = System.Drawing.Color.Green;
            this.labelDownloadSuccessful.Name = "labelDownloadSuccessful";
            // 
            // flowLayoutPanelButton
            // 
            this.flowLayoutPanelButton.Controls.Add(this.buttonClose);
            resources.ApplyResources(this.flowLayoutPanelButton, "flowLayoutPanelButton");
            this.flowLayoutPanelButton.Name = "flowLayoutPanelButton";
            // 
            // FormFFmpegMissingDialog
            // 
            this.AcceptButton = this.buttonClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFFmpegMissingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelFFmpegExlanation;
        private System.Windows.Forms.LinkLabel linkLabelFFmpeg;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelFFmpegDownload;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButton;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelDownloadSuccessful;
    }
}