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
            resources.ApplyResources(tableLayoutPanelMain, "tableLayoutPanelMain");
            tableLayoutPanelMain.Controls.Add(flowLayoutPanelTexts, 1, 0);
            tableLayoutPanelMain.Controls.Add(pictureBoxLogo, 0, 0);
            tableLayoutPanelMain.Controls.Add(flowLayoutPanelBottom, 0, 1);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            // 
            // flowLayoutPanelTexts
            // 
            flowLayoutPanelTexts.Controls.Add(labelOpenSource);
            flowLayoutPanelTexts.Controls.Add(labelOpenSourceExplanation);
            resources.ApplyResources(flowLayoutPanelTexts, "flowLayoutPanelTexts");
            flowLayoutPanelTexts.Name = "flowLayoutPanelTexts";
            // 
            // labelOpenSource
            // 
            resources.ApplyResources(labelOpenSource, "labelOpenSource");
            labelOpenSource.ForeColor = System.Drawing.Color.White;
            labelOpenSource.Name = "labelOpenSource";
            // 
            // labelOpenSourceExplanation
            // 
            resources.ApplyResources(labelOpenSourceExplanation, "labelOpenSourceExplanation");
            labelOpenSourceExplanation.ForeColor = System.Drawing.Color.White;
            labelOpenSourceExplanation.Name = "labelOpenSourceExplanation";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.film_reels;
            resources.ApplyResources(pictureBoxLogo, "pictureBoxLogo");
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.TabStop = false;
            // 
            // flowLayoutPanelBottom
            // 
            tableLayoutPanelMain.SetColumnSpan(flowLayoutPanelBottom, 2);
            flowLayoutPanelBottom.Controls.Add(pictureBoxWebIcon);
            flowLayoutPanelBottom.Controls.Add(labelProjectPage);
            flowLayoutPanelBottom.Controls.Add(linkLabel);
            resources.ApplyResources(flowLayoutPanelBottom, "flowLayoutPanelBottom");
            flowLayoutPanelBottom.Name = "flowLayoutPanelBottom";
            // 
            // pictureBoxWebIcon
            // 
            pictureBoxWebIcon.Image = Properties.Resources.web;
            resources.ApplyResources(pictureBoxWebIcon, "pictureBoxWebIcon");
            pictureBoxWebIcon.Name = "pictureBoxWebIcon";
            pictureBoxWebIcon.TabStop = false;
            // 
            // labelProjectPage
            // 
            resources.ApplyResources(labelProjectPage, "labelProjectPage");
            labelProjectPage.ForeColor = System.Drawing.Color.White;
            labelProjectPage.Name = "labelProjectPage";
            // 
            // linkLabel
            // 
            linkLabel.ActiveLinkColor = System.Drawing.Color.White;
            resources.ApplyResources(linkLabel, "linkLabel");
            linkLabel.ForeColor = System.Drawing.Color.White;
            linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            linkLabel.LinkColor = System.Drawing.Color.White;
            linkLabel.Name = "linkLabel";
            linkLabel.TabStop = true;
            linkLabel.VisitedLinkColor = System.Drawing.Color.White;
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            // 
            // WelcomeDialog
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            Controls.Add(tableLayoutPanelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WelcomeDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
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