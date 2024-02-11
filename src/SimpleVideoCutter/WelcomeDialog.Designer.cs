namespace SimpleVideoCutter
{
    partial class WelcomeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeDialog));
            tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanelTexts = new System.Windows.Forms.FlowLayoutPanel();
            labelOpenSource = new System.Windows.Forms.Label();
            labelOpenSourceExplanation = new System.Windows.Forms.Label();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            flowLayoutPanelBottom = new System.Windows.Forms.FlowLayoutPanel();
            pictureBoxWebIcon = new System.Windows.Forms.PictureBox();
            labelProjectPage = new System.Windows.Forms.Label();
            linkLabel = new System.Windows.Forms.LinkLabel();
            tableLayoutPanelMain.SuspendLayout();
            flowLayoutPanelTexts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            flowLayoutPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebIcon).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.8568211F));
            tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.14318F));
            tableLayoutPanelMain.Controls.Add(flowLayoutPanelTexts, 1, 0);
            tableLayoutPanelMain.Controls.Add(pictureBoxLogo, 0, 0);
            tableLayoutPanelMain.Controls.Add(flowLayoutPanelBottom, 0, 1);
            tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.12618F));
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.8738174F));
            tableLayoutPanelMain.Size = new System.Drawing.Size(887, 317);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // flowLayoutPanelTexts
            // 
            flowLayoutPanelTexts.Controls.Add(labelOpenSource);
            flowLayoutPanelTexts.Controls.Add(labelOpenSourceExplanation);
            flowLayoutPanelTexts.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelTexts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanelTexts.Location = new System.Drawing.Point(188, 3);
            flowLayoutPanelTexts.Name = "flowLayoutPanelTexts";
            flowLayoutPanelTexts.Padding = new System.Windows.Forms.Padding(10);
            flowLayoutPanelTexts.Size = new System.Drawing.Size(696, 248);
            flowLayoutPanelTexts.TabIndex = 0;
            // 
            // labelOpenSource
            // 
            labelOpenSource.AutoSize = true;
            labelOpenSource.Dock = System.Windows.Forms.DockStyle.Fill;
            labelOpenSource.Font = new System.Drawing.Font("Tahoma", 19.8000011F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelOpenSource.ForeColor = System.Drawing.Color.White;
            labelOpenSource.Location = new System.Drawing.Point(13, 10);
            labelOpenSource.Name = "labelOpenSource";
            labelOpenSource.Size = new System.Drawing.Size(616, 41);
            labelOpenSource.TabIndex = 0;
            labelOpenSource.Text = "Free && Open Source";
            // 
            // labelOpenSourceExplanation
            // 
            labelOpenSourceExplanation.AutoSize = true;
            labelOpenSourceExplanation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelOpenSourceExplanation.ForeColor = System.Drawing.Color.White;
            labelOpenSourceExplanation.Location = new System.Drawing.Point(13, 61);
            labelOpenSourceExplanation.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            labelOpenSourceExplanation.Name = "labelOpenSourceExplanation";
            labelOpenSourceExplanation.Size = new System.Drawing.Size(616, 72);
            labelOpenSourceExplanation.TabIndex = 1;
            labelOpenSourceExplanation.Text = "Simple Video Cutter is open source project and available completely for free!. If you like it please consider tweeting, posting on FB, or telling your friends about it! ";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.film_reels;
            pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(179, 248);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            // 
            // flowLayoutPanelBottom
            // 
            tableLayoutPanelMain.SetColumnSpan(flowLayoutPanelBottom, 2);
            flowLayoutPanelBottom.Controls.Add(pictureBoxWebIcon);
            flowLayoutPanelBottom.Controls.Add(labelProjectPage);
            flowLayoutPanelBottom.Controls.Add(linkLabel);
            flowLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelBottom.Location = new System.Drawing.Point(3, 257);
            flowLayoutPanelBottom.Name = "flowLayoutPanelBottom";
            flowLayoutPanelBottom.Size = new System.Drawing.Size(881, 57);
            flowLayoutPanelBottom.TabIndex = 2;
            // 
            // pictureBoxWebIcon
            // 
            pictureBoxWebIcon.Image = Properties.Resources.web;
            pictureBoxWebIcon.Location = new System.Drawing.Point(3, 3);
            pictureBoxWebIcon.Name = "pictureBoxWebIcon";
            pictureBoxWebIcon.Size = new System.Drawing.Size(48, 48);
            pictureBoxWebIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxWebIcon.TabIndex = 0;
            pictureBoxWebIcon.TabStop = false;
            // 
            // labelProjectPage
            // 
            labelProjectPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelProjectPage.AutoSize = true;
            labelProjectPage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelProjectPage.ForeColor = System.Drawing.Color.White;
            labelProjectPage.Location = new System.Drawing.Point(57, 15);
            labelProjectPage.Name = "labelProjectPage";
            labelProjectPage.Size = new System.Drawing.Size(151, 24);
            labelProjectPage.TabIndex = 1;
            labelProjectPage.Text = "Project page: ";
            // 
            // linkLabel
            // 
            linkLabel.ActiveLinkColor = System.Drawing.Color.White;
            linkLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            linkLabel.AutoSize = true;
            linkLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            linkLabel.ForeColor = System.Drawing.Color.White;
            linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            linkLabel.LinkColor = System.Drawing.Color.White;
            linkLabel.Location = new System.Drawing.Point(214, 15);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new System.Drawing.Size(554, 24);
            linkLabel.TabIndex = 2;
            linkLabel.TabStop = true;
            linkLabel.Text = "https://github.com/bartekmotyl/simple-video-cutter";
            linkLabel.VisitedLinkColor = System.Drawing.Color.White;
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            // 
            // WelcomeDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            ClientSize = new System.Drawing.Size(887, 317);
            Controls.Add(tableLayoutPanelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WelcomeDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Simple Video Cutter is free and open source!";
            KeyDown += WelcomeDialog_KeyDown;
            tableLayoutPanelMain.ResumeLayout(false);
            flowLayoutPanelTexts.ResumeLayout(false);
            flowLayoutPanelTexts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            flowLayoutPanelBottom.ResumeLayout(false);
            flowLayoutPanelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTexts;
        private System.Windows.Forms.Label labelOpenSource;
        private System.Windows.Forms.Label labelOpenSourceExplanation;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBottom;
        private System.Windows.Forms.PictureBox pictureBoxWebIcon;
        private System.Windows.Forms.Label labelProjectPage;
        private System.Windows.Forms.LinkLabel linkLabel;
    }
}