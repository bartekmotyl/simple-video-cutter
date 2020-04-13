using SimpleVideoCutter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            var culture = CultureInfo.GetCultureInfo(VideoCutterSettings.Instance.Language);
            if (culture != null)
            {
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            this.toolTip1.SetToolTip(this.comboBoxDefaultDirectory, string.Format(
                GlobalStrings.FormSettings_DefaultDirecttoryTooltip,
                @"{UserVideos}\n{UserDocuments}\n{MyComputer}".Replace(
                    @"\n", Environment.NewLine)));

            this.toolTip1.SetToolTip(this.comboBoxOutputDirectory, string.Format(
                GlobalStrings.FormSettings_OutputDirectoryTooltip,
                @"{UserVideos}\n{UserDocuments}\n{MyComputer}".Replace(
                    @"\n", Environment.NewLine)));

            this.toolTip1.SetToolTip(this.textBoxOutputFilePattern, string.Format(
                GlobalStrings.FormSettings_OutputFileNamePatternTooltip,
                    "{FileName}",
                    "{FileNameWithoutExtension}",
                    "{FileExtension}",
                    "{FileDate}",
                    "{Timestamp}"));
        }

        public void ShowSettingsDialog()
        {
            VideoCutterSettings.Instance.LoadSettings();
            SettingsToGUI();
            this.ShowDialog();
        }


        private void SettingsToGUI()
        {
            var settings = VideoCutterSettings.Instance;

            comboBoxDefaultDirectory.Text = settings.DefaultInitialDirectory;
            comboBoxOutputDirectory.Text = settings.OutputDirectory;
            textBoxOutputFilePattern.Text = settings.OutputFilePattern;
            textBoxFFmpegPath.Text = settings.FFmpegPath;
            textBoxVideoFileExtensions.Text = String.Join(" ,", settings.VideoFilesExtensions);

            SetBackgroundOfFFmpegPath();
        }

        private void GUIToSettings()
        {
            var settings = VideoCutterSettings.Instance;

            settings.DefaultInitialDirectory = comboBoxDefaultDirectory.Text;
            settings.OutputDirectory = comboBoxOutputDirectory.Text;
            settings.OutputFilePattern = textBoxOutputFilePattern.Text;
            settings.FFmpegPath = textBoxFFmpegPath.Text;

            // TODO: parse VideoFilesExtensions

            settings.StoreSettings();
        }


        private string SelectFile(string fileName)
        {
            using (var dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.DefaultExt = "exe";
                dialog.CheckFileExists = true;
                dialog.Filter = $"{GlobalStrings.FormSettings_ExecutableFiles} (*.exe)|*.exe";

                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    return dialog.FileName;
                }
            }
            return null; 
        }

        private string SelectFolder()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }
            return null;
        }

        private void SetBackgroundOfFFmpegPath()
        {
            if (string.IsNullOrWhiteSpace(textBoxFFmpegPath.Text))
            {
                textBoxFFmpegPath.BackColor = Color.Orange;
            }
            else
            {
                textBoxFFmpegPath.BackColor = SystemColors.Window ;
            }
        }

        private void textBoxFFmpegPath_TextChanged(object sender, EventArgs e)
        {
            SetBackgroundOfFFmpegPath();
        }

        private void buttonFFmpegPath_Click(object sender, EventArgs e)
        {
            var ffmpegPath = SelectFile("ffmpeg.exe");
            if (ffmpegPath != null)
                textBoxFFmpegPath.Text = ffmpegPath;
        }

        private void buttonDefaultDirectory_Click(object sender, EventArgs e)
        {
            var defaultDirectoryPath = SelectFolder();
            if (defaultDirectoryPath != null)
                comboBoxDefaultDirectory.Text = defaultDirectoryPath;
        }

        private void buttonOutputDirectory_Click(object sender, EventArgs e)
        {
            var outputDirectoryPath = SelectFolder();
            if (outputDirectoryPath != null)
                comboBoxOutputDirectory.Text = outputDirectoryPath;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            GUIToSettings();
            Close();
        }
    }
}
