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
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxLosslessCut = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelLosslessCut = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelReEncodeButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonEnqueueLoseless = new System.Windows.Forms.Button();
            this.buttonAdjustSelections = new System.Windows.Forms.Button();
            this.labelLossless = new System.Windows.Forms.Label();
            this.groupBoxReEncodeCut = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelReEncodeCut = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEnqueueReEncoding = new System.Windows.Forms.Button();
            this.labelReEncode = new System.Windows.Forms.Label();
            this.groupBoxVideoParameters = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelVideoParameters = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOutputFilePath = new System.Windows.Forms.TextBox();
            this.labelOutputFilePath = new System.Windows.Forms.Label();
            this.textBoxOriginalFilePath = new System.Windows.Forms.TextBox();
            this.labelOriginalFilePath = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.richTextBoxExplanation = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.groupBoxLosslessCut.SuspendLayout();
            this.tableLayoutPanelLosslessCut.SuspendLayout();
            this.flowLayoutPanelReEncodeButtons.SuspendLayout();
            this.groupBoxReEncodeCut.SuspendLayout();
            this.tableLayoutPanelReEncodeCut.SuspendLayout();
            this.groupBoxVideoParameters.SuspendLayout();
            this.tableLayoutPanelVideoParameters.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDuration
            // 
            resources.ApplyResources(this.textBoxDuration, "textBoxDuration");
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.ReadOnly = true;
            // 
            // labelDuration
            // 
            resources.ApplyResources(this.labelDuration, "labelDuration");
            this.labelDuration.Name = "labelDuration";
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Controls.Add(this.buttonCancel);
            resources.ApplyResources(this.flowLayoutPanelButtons, "flowLayoutPanelButtons");
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxLosslessCut
            // 
            this.groupBoxLosslessCut.Controls.Add(this.tableLayoutPanelLosslessCut);
            resources.ApplyResources(this.groupBoxLosslessCut, "groupBoxLosslessCut");
            this.groupBoxLosslessCut.Name = "groupBoxLosslessCut";
            this.groupBoxLosslessCut.TabStop = false;
            // 
            // tableLayoutPanelLosslessCut
            // 
            resources.ApplyResources(this.tableLayoutPanelLosslessCut, "tableLayoutPanelLosslessCut");
            this.tableLayoutPanelLosslessCut.Controls.Add(this.flowLayoutPanelReEncodeButtons, 1, 1);
            this.tableLayoutPanelLosslessCut.Controls.Add(this.labelLossless, 0, 0);
            this.tableLayoutPanelLosslessCut.Name = "tableLayoutPanelLosslessCut";
            // 
            // flowLayoutPanelReEncodeButtons
            // 
            resources.ApplyResources(this.flowLayoutPanelReEncodeButtons, "flowLayoutPanelReEncodeButtons");
            this.tableLayoutPanelLosslessCut.SetColumnSpan(this.flowLayoutPanelReEncodeButtons, 2);
            this.flowLayoutPanelReEncodeButtons.Controls.Add(this.buttonEnqueueLoseless);
            this.flowLayoutPanelReEncodeButtons.Controls.Add(this.buttonAdjustSelections);
            this.flowLayoutPanelReEncodeButtons.Name = "flowLayoutPanelReEncodeButtons";
            // 
            // buttonEnqueueLoseless
            // 
            resources.ApplyResources(this.buttonEnqueueLoseless, "buttonEnqueueLoseless");
            this.buttonEnqueueLoseless.BackColor = System.Drawing.SystemColors.Control;
            this.buttonEnqueueLoseless.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEnqueueLoseless.Name = "buttonEnqueueLoseless";
            this.buttonEnqueueLoseless.UseVisualStyleBackColor = false;
            this.buttonEnqueueLoseless.Click += new System.EventHandler(this.buttonEnqueueLoseless_Click);
            // 
            // buttonAdjustSelections
            // 
            resources.ApplyResources(this.buttonAdjustSelections, "buttonAdjustSelections");
            this.buttonAdjustSelections.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.buttonAdjustSelections.Name = "buttonAdjustSelections";
            this.buttonAdjustSelections.UseVisualStyleBackColor = false;
            // 
            // labelLossless
            // 
            resources.ApplyResources(this.labelLossless, "labelLossless");
            this.tableLayoutPanelLosslessCut.SetColumnSpan(this.labelLossless, 2);
            this.labelLossless.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLossless.Name = "labelLossless";
            // 
            // groupBoxReEncodeCut
            // 
            this.groupBoxReEncodeCut.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxReEncodeCut.Controls.Add(this.tableLayoutPanelReEncodeCut);
            resources.ApplyResources(this.groupBoxReEncodeCut, "groupBoxReEncodeCut");
            this.groupBoxReEncodeCut.Name = "groupBoxReEncodeCut";
            this.groupBoxReEncodeCut.TabStop = false;
            // 
            // tableLayoutPanelReEncodeCut
            // 
            resources.ApplyResources(this.tableLayoutPanelReEncodeCut, "tableLayoutPanelReEncodeCut");
            this.tableLayoutPanelReEncodeCut.Controls.Add(this.buttonEnqueueReEncoding, 1, 2);
            this.tableLayoutPanelReEncodeCut.Controls.Add(this.labelReEncode, 0, 0);
            this.tableLayoutPanelReEncodeCut.Name = "tableLayoutPanelReEncodeCut";
            // 
            // buttonEnqueueReEncoding
            // 
            resources.ApplyResources(this.buttonEnqueueReEncoding, "buttonEnqueueReEncoding");
            this.buttonEnqueueReEncoding.BackColor = System.Drawing.SystemColors.Control;
            this.buttonEnqueueReEncoding.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEnqueueReEncoding.Name = "buttonEnqueueReEncoding";
            this.buttonEnqueueReEncoding.UseVisualStyleBackColor = false;
            this.buttonEnqueueReEncoding.Click += new System.EventHandler(this.buttonEnqueueReEncoding_Click);
            // 
            // labelReEncode
            // 
            resources.ApplyResources(this.labelReEncode, "labelReEncode");
            this.tableLayoutPanelReEncodeCut.SetColumnSpan(this.labelReEncode, 2);
            this.labelReEncode.Name = "labelReEncode";
            // 
            // groupBoxVideoParameters
            // 
            this.groupBoxVideoParameters.Controls.Add(this.tableLayoutPanelVideoParameters);
            resources.ApplyResources(this.groupBoxVideoParameters, "groupBoxVideoParameters");
            this.groupBoxVideoParameters.Name = "groupBoxVideoParameters";
            this.groupBoxVideoParameters.TabStop = false;
            // 
            // tableLayoutPanelVideoParameters
            // 
            resources.ApplyResources(this.tableLayoutPanelVideoParameters, "tableLayoutPanelVideoParameters");
            this.tableLayoutPanelVideoParameters.Controls.Add(this.label2, 1, 3);
            this.tableLayoutPanelVideoParameters.Controls.Add(this.textBoxOutputFilePath, 1, 2);
            this.tableLayoutPanelVideoParameters.Controls.Add(this.labelOutputFilePath, 0, 2);
            this.tableLayoutPanelVideoParameters.Controls.Add(this.textBoxOriginalFilePath, 1, 0);
            this.tableLayoutPanelVideoParameters.Controls.Add(this.labelOriginalFilePath, 0, 0);
            this.tableLayoutPanelVideoParameters.Controls.Add(this.textBoxDuration, 1, 1);
            this.tableLayoutPanelVideoParameters.Controls.Add(this.labelDuration, 0, 1);
            this.tableLayoutPanelVideoParameters.Name = "tableLayoutPanelVideoParameters";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBoxOutputFilePath
            // 
            resources.ApplyResources(this.textBoxOutputFilePath, "textBoxOutputFilePath");
            this.textBoxOutputFilePath.Name = "textBoxOutputFilePath";
            this.textBoxOutputFilePath.ReadOnly = true;
            // 
            // labelOutputFilePath
            // 
            resources.ApplyResources(this.labelOutputFilePath, "labelOutputFilePath");
            this.labelOutputFilePath.Name = "labelOutputFilePath";
            // 
            // textBoxOriginalFilePath
            // 
            resources.ApplyResources(this.textBoxOriginalFilePath, "textBoxOriginalFilePath");
            this.textBoxOriginalFilePath.Name = "textBoxOriginalFilePath";
            this.textBoxOriginalFilePath.ReadOnly = true;
            // 
            // labelOriginalFilePath
            // 
            resources.ApplyResources(this.labelOriginalFilePath, "labelOriginalFilePath");
            this.labelOriginalFilePath.Name = "labelOriginalFilePath";
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.richTextBoxExplanation);
            resources.ApplyResources(this.panelDetails, "panelDetails");
            this.panelDetails.Name = "panelDetails";
            // 
            // richTextBoxExplanation
            // 
            this.richTextBoxExplanation.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxExplanation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.richTextBoxExplanation, "richTextBoxExplanation");
            this.richTextBoxExplanation.Name = "richTextBoxExplanation";
            this.richTextBoxExplanation.ReadOnly = true;
            this.richTextBoxExplanation.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxExplanation_LinkClicked);
            // 
            // FormAddTask
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxReEncodeCut);
            this.Controls.Add(this.groupBoxLosslessCut);
            this.Controls.Add(this.groupBoxVideoParameters);
            this.Controls.Add(this.flowLayoutPanelButtons);
            this.Controls.Add(this.panelDetails);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddTask";
            this.ShowInTaskbar = false;
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.groupBoxLosslessCut.ResumeLayout(false);
            this.tableLayoutPanelLosslessCut.ResumeLayout(false);
            this.tableLayoutPanelLosslessCut.PerformLayout();
            this.flowLayoutPanelReEncodeButtons.ResumeLayout(false);
            this.flowLayoutPanelReEncodeButtons.PerformLayout();
            this.groupBoxReEncodeCut.ResumeLayout(false);
            this.tableLayoutPanelReEncodeCut.ResumeLayout(false);
            this.tableLayoutPanelReEncodeCut.PerformLayout();
            this.groupBoxVideoParameters.ResumeLayout(false);
            this.tableLayoutPanelVideoParameters.ResumeLayout(false);
            this.tableLayoutPanelVideoParameters.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxLosslessCut;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLosslessCut;
        private System.Windows.Forms.Label labelLossless;
        private System.Windows.Forms.GroupBox groupBoxReEncodeCut;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelReEncodeCut;
        private System.Windows.Forms.GroupBox groupBoxVideoParameters;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVideoParameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOutputFilePath;
        private System.Windows.Forms.Label labelOutputFilePath;
        private System.Windows.Forms.TextBox textBoxOriginalFilePath;
        private System.Windows.Forms.Label labelOriginalFilePath;
        private System.Windows.Forms.Label labelReEncode;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.RichTextBox richTextBoxExplanation;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelReEncodeButtons;
        private System.Windows.Forms.Button buttonEnqueueLoseless;
        private System.Windows.Forms.Button buttonAdjustSelections;
        private System.Windows.Forms.Button buttonEnqueueReEncoding;
    }
}