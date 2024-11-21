using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.Versioning;

namespace SimpleVideoCutter
{
    [SupportedOSPlatform("windows")]
    public partial class ChooseOutputDirectory : Form
    {
        private readonly FFmpegTask task;

        private bool isEditMode = false;

        private readonly int numberOfSubDirectories = 9;

        private readonly string explanationInEditMode = "Stop editing to activate the functionality of this dialog.";

        private readonly string explanationStandard;

        private readonly string? originalOutputDir;

        public FFmpegTask Task { get => task; }

        public ChooseOutputDirectory(FFmpegTask task)
        {
            InitializeComponent();
            this.task = task;

            this.GenerateControls();
            this.explanationStandard = labelDialogExplanation.Text;
            this.originalOutputDir = Path.GetDirectoryName(this.task.OutputFilePath);
            this.labelPath.Text = this.originalOutputDir == null ? "" : this.labelPath.Text = "\"" + this.originalOutputDir + "\"";
        }

        private void ChooseOutputDirectory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.isEditMode || !char.IsAsciiDigit(e.KeyChar))
            {
                return;
            }

            NumberedEditableButton editableButton = (NumberedEditableButton)panelDirectoryList.Controls[int.Parse(e.KeyChar.ToString()) - 1];
            this.SetTaskOutputFilePath(editableButton.Caption);

            this.Close();
        }


        private void SetTaskOutputFilePath(string subDir)
        {
            if(this.task.OutputFilePath != null)
            {
                this.task.OutputFilePath = Path.Combine(
                    Path.GetDirectoryName(task.OutputFilePath) ?? "",
                    subDir,
                    Path.GetFileName(task.OutputFilePath)
                );
            }
        }

        private void ChooseOutputDirectory_ButtonClick(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                this.SetTaskOutputFilePath(((NumberedEditableButton)sender).Caption);
            }

            this.Close();
        }

        private void GenerateControls()
        {
            for (int i = 1; i <= this.numberOfSubDirectories; i++)
            {
                var editableButton = new NumberedEditableButton(
                    i, VideoCutterSettings.Instance.QuickSubDirectories[i - 1],
                    700, 30,
                    new ColumnStyle[] { new ColumnStyle(SizeType.Percent, 5), new ColumnStyle(SizeType.Percent, 95) }
                );
                editableButton.Dock = DockStyle.Left;
                editableButton.EditMode = false;
                editableButton.ButtonClick += ChooseOutputDirectory_ButtonClick;

                panelDirectoryList.Controls.Add(editableButton);
            }
        }

        private void ToggleEditModeButton_Click(object sender, EventArgs e)
        {
            this.isEditMode = !this.isEditMode;

            foreach (NumberedEditableButton editableButton in panelDirectoryList.Controls)
            {
                editableButton.EditMode = this.isEditMode;
            }

            if (this.isEditMode)
            {
                labelDialogExplanation.Text = this.explanationInEditMode;
                labelPath.Text = String.Empty;
                this.toggleEditModeButton.Text = "Stop editing";
            }
            else // Edit mode was just left, so the settings will be saved now.
            {
                labelDialogExplanation.Text = this.explanationStandard;
                labelPath.Text = this.originalOutputDir == null ? "" : "\"" + this.originalOutputDir + "";
                this.toggleEditModeButton.Text = "Edit directories";

                VideoCutterSettings.Instance.QuickSubDirectories = this.panelDirectoryList.Controls.Cast<Control>()
                                       .OfType<NumberedEditableButton>()
                                       .Select(editableButton => editableButton.Caption)
                                       .ToArray();

                VideoCutterSettings.Instance.StoreSettings();
            }
        }

        private void ChooseOutputDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
