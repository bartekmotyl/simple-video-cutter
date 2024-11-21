using SimpleVideoCutter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    [SupportedOSPlatform("windows")]
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            var culture = CultureInfo.GetCultureInfo(VideoCutterSettings.Instance.Language ?? Thread.CurrentThread.CurrentUICulture.Name);
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

            this.comboBoxPreviewSize.DataSource =
                ((PreviewSize[])Enum.GetValues(typeof(PreviewSize))).Select(ps => new ComboBoxItem<PreviewSize>()
                {
                    Value = ps,
                    Title = ps.ToString()
                }).ToList();

            this.radioDeleteInputFile.Tag = typeof(Actions.DeleteInputFile).Name;
            this.radioMoveInputFileToRelativeDirectory.Tag = typeof(Actions.MoveInputFileToRelativeDirectory).Name;
            this.radioMoveInputFileToDirectory.Tag = typeof(Actions.MoveInputFileToDirectory).Name;
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
            comboBoxPreviewSize.SelectedValue = settings.PreviewSize;
            checkBoxShowQuickSubDirectoryDialog.Checked = settings.ShowQuickSubDirectoryDialog;
            groupInputFileActions.Controls.OfType<RadioButton>()
                .FirstOrDefault(rb => rb.Tag?.ToString() == settings.ActionAfterTaskCompletion, radioKeepInputFile)
                .Checked = true;
            textBoxInputFileTargetDirectory.Text = settings.ActionInputFileTargetDirectory;
            textBoxInputFileRelativeTargetDirectory.Text = settings.ActionInputFileRelativeTargetDirectory;
            checkBoxCreateMissingDirectories.Checked = settings.CreateMissingDirectories;

            SetBackgroundOfFFmpegPath();
        }

        private void GUIToSettings()
        {
            var settings = VideoCutterSettings.Instance;

            settings.DefaultInitialDirectory = comboBoxDefaultDirectory.Text;
            settings.OutputDirectory = comboBoxOutputDirectory.Text;
            settings.OutputFilePattern = textBoxOutputFilePattern.Text;
            settings.FFmpegPath = textBoxFFmpegPath.Text;
            settings.PreviewSize = (PreviewSize)(Enum.Parse(typeof(PreviewSize), comboBoxPreviewSize.SelectedValue?.ToString() ?? "L"));
            settings.ShowQuickSubDirectoryDialog = checkBoxShowQuickSubDirectoryDialog.Checked;
            settings.ActionAfterTaskCompletion = groupInputFileActions.Controls.OfType<RadioButton>().First(rb => rb.Checked).Tag?.ToString();
            settings.ActionInputFileTargetDirectory = textBoxInputFileTargetDirectory.Text;
            settings.ActionInputFileRelativeTargetDirectory = textBoxInputFileRelativeTargetDirectory.Text;
            settings.CreateMissingDirectories = checkBoxCreateMissingDirectories.Checked;

            // TODO: parse VideoFilesExtensions

            settings.StoreSettings();
        }


        private string? SelectFile(string fileName)
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

        private string? SelectFolder()
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
            if (string.IsNullOrWhiteSpace(textBoxFFmpegPath.Text) || !File.Exists(textBoxFFmpegPath.Text))
            {
                textBoxFFmpegPath.BackColor = Color.Orange;
            }
            else
            {
                textBoxFFmpegPath.BackColor = SystemColors.Window;
            }
        }

        private void TextBoxFFmpegPath_TextChanged(object sender, EventArgs e)
        {
            SetBackgroundOfFFmpegPath();
        }

        private void ButtonFFmpegPath_Click(object sender, EventArgs e)
        {
            var ffmpegPath = SelectFile("ffmpeg.exe");
            if (ffmpegPath != null)
                textBoxFFmpegPath.Text = ffmpegPath;
        }

        private void ButtonDefaultDirectory_Click(object sender, EventArgs e)
        {
            var defaultDirectoryPath = SelectFolder();
            if (defaultDirectoryPath != null)
                comboBoxDefaultDirectory.Text = defaultDirectoryPath;
        }

        private void ButtonOutputDirectory_Click(object sender, EventArgs e)
        {
            var outputDirectoryPath = SelectFolder();
            if (outputDirectoryPath != null)
                comboBoxOutputDirectory.Text = outputDirectoryPath;
        }

        private void ButtonInputFileTargetDirectory_Click(object sender, EventArgs e)
        {
            var moveToDirectoryPath = SelectFolder();

            if (moveToDirectoryPath != null)
                textBoxInputFileTargetDirectory.Text = moveToDirectoryPath;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            GUIToSettings();
            Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxPreviewSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }

        internal class ComboBoxItem<T>
        {
            public string? Title { get; set; }
            public T? Value { get; set; }

            public override bool Equals(object? obj)
            {
                if (obj is ComboBoxItem<T>)
                {
                    var other = obj as ComboBoxItem<T>;
                    return String.Equals(Value, other);
                }
                else
                    return false;
            }

            public override int GetHashCode()
            {
                return Value == null ? 0 : Value.GetHashCode();
            }
        }
    }
}
