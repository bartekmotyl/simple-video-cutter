namespace SimpleVideoCutter
{
    partial class VideoCutterTimeline
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VideoCutterTimeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "VideoCutterTimeline";
            this.Size = new System.Drawing.Size(981, 64);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VideoCutterTimeline_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VideoCutterTimeline_MouseClick);
            this.MouseEnter += new System.EventHandler(this.VideoCutterTimeline_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.VideoCutterTimeline_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoCutterTimeline_MouseMove);
            this.Resize += new System.EventHandler(this.VideoCutterTimeline_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
