using SimpleVideoCutter.Properties;
using SimpleVideoCutter.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    public partial class FormAddTask : Form
    {
        private FFmpegTask task;
        private bool guiUpdateInProgres = false;
        private bool selectionsOnKeyFrames = false;


        public FormAddTask(FFmpegTask task, bool selectionsOnKeyFrames)
        {
            InitializeComponent();
            this.selectionsOnKeyFrames = selectionsOnKeyFrames;

            this.Task = task.DeepClone();
            TaskToGUI();
            buttonEnqueueReEncoding.Focus();
        }

        public FFmpegTask Task { get => task; set => task = value; }

        private void TaskToGUI()
        {
            guiUpdateInProgres = true;
            try
            {
                this.textBoxOriginalFilePath.Text = Task.InputFilePath;
                this.textBoxOutputFilePath.Text = Task.OutputFilePath;
                this.textBoxDuration.Text = TimeSpan.FromMilliseconds(Task.OverallDuration).ToString(@"hh\:mm\:ss\.fff");
                UpdatePossibilities();
            }
            finally
            {
                guiUpdateInProgres = false; 
            }

        }

        private void UpdatePossibilities()
        {
            var losslessCutPossible = selectionsOnKeyFrames && string.IsNullOrEmpty(Task.Profile.FileType); 

            buttonAdjustSelections.Visible = !losslessCutPossible;
            buttonEnqueueLoseless.Enabled = losslessCutPossible;
            buttonEnqueueReEncoding.Enabled = true;

            if (losslessCutPossible)
            {
                labelLossless.Text = "Lossless cut possible";
                labelReEncode.Text = "Cut with re-encoding possible, but may take long time!";
                groupBoxLosslessCut.BackColor = Color.Honeydew;
            }
            else
            {
                labelLossless.Text = "Lossless cut not possible!";
                labelReEncode.Text = "Cut with re-encoding possible, but may take long time!";
            }
        }

        internal class ComboBoxItem
        {
            public string Title { get; set; }
            public string Value { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is ComboBoxItem)
                {
                    var other = obj as ComboBoxItem;
                    return String.Equals(Value, other.Value);
                }
                else
                    return false;
            }

            public override int GetHashCode()
            {
                return Value == null ? 0 : Value.GetHashCode();
            }
        }

        private void richTextBoxExplanation_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void buttonEnqueueLoseless_Click(object sender, EventArgs e)
        {
        }

        private void buttonEnqueueReEncoding_Click(object sender, EventArgs e)
        {
            Task.Profile = FFmpegCutProfile.ReEncode.Clone();
        }
    }
}
