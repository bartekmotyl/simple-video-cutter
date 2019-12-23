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
        private bool profileDirty = false;
        private bool guiUpdateInProgres = false; 

        public FormAddTask(FFmpegTask task)
        {
            InitializeComponent();
            
            InitializeFileTypes();
            InitializeProfiles();

            this.Task = task.DeepClone();
            TaskToGUI();
            buttonEnqueue.Focus();
        }

        public FFmpegTask Task { get => task; set => task = value; }

        private void TaskToGUI()
        {
            guiUpdateInProgres = true;
            try
            {
                this.textBoxOriginalFilePath.Text = Task.InputFilePath;
                this.textBoxOutputFilePath.Text = Task.OutputFilePath;
                this.textBoxDuration.Text = TimeSpan.FromMilliseconds(Task.Duration).ToString(@"hh\:mm\:ss\.fff");

                ProfileToGUI();

                this.buttonSaveProfile.Enabled = profileDirty;
                this.buttonEnqueue.Enabled = !profileDirty;
            }
            finally
            {
                guiUpdateInProgres = false; 
            }

        }

        private void ProfileToGUI()
        {
            this.comboBoxFFmpegProfile.SelectedItem = new ComboBoxItem() { Value = Task.Profile.Name };
            this.comboBoxFileType.SelectedItem = new ComboBoxItem() { Value = Task.Profile.FileType ?? "" };
            this.textBoxFFmpegArguments.Text = Task.Profile.Arguments;

            FileTypeToGUI();
        }

        private void FileTypeToGUI()
        {
            if (!string.IsNullOrEmpty(Task.Profile.FileType))
            {
                var extension = Task.Profile.FileType.StartsWith(".") ? Task.Profile.FileType.Substring(1) : Task.Profile.FileType;
                Task.OutputFilePath = Path.ChangeExtension(Task.OutputFilePath, extension);
            }
            else
            {
                var origExtenstion = Path.GetExtension(Task.InputFilePath);
                Task.OutputFilePath = Path.ChangeExtension(Task.OutputFilePath, origExtenstion);
            }
        }

        private void InitializeFileTypes() 
        {
            comboBoxFileType.Items.Clear();
            comboBoxFileType.Items.Add(new ComboBoxItem()
            {
                Title = "(same as source)",
                Value = "",
            });

            foreach (var extension in VideoCutterSettings.Instance.VideoFilesExtensions)
            {
                this.comboBoxFileType.Items.Add(new ComboBoxItem()
                {
                    Title = extension,
                    Value = extension,
                });
            }
            
            comboBoxFileType.ValueMember = "Value";
            comboBoxFileType.DisplayMember = "Title";
        }
        private void InitializeProfiles()
        {
            comboBoxFFmpegProfile.Items.Clear();

            foreach (var profile in VideoCutterSettings.Instance.FFmpegCutProfiles)
            {
                this.comboBoxFFmpegProfile.Items.Add(new ComboBoxItem()
                {
                    Title = profile.Name,
                    Value = profile.Name,
                });
            }

            comboBoxFFmpegProfile.ValueMember = "Value";
            comboBoxFFmpegProfile.DisplayMember = "Title";
        }


        private void comboBoxFFmpegProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guiUpdateInProgres)
                return; 

            var selectedItem = comboBoxFFmpegProfile.SelectedItem as ComboBoxItem;
            
            var selectedProfile = VideoCutterSettings.Instance.FFmpegCutProfiles
                .FirstOrDefault(p => p.Name == selectedItem.Value);

            if (selectedProfile == null)
                return; // wtf?

            Task.Profile = selectedProfile.DeepClone();
            profileDirty = false; 

            TaskToGUI();
        }




        private void comboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guiUpdateInProgres)
                return;

            var selectedItem = comboBoxFileType.SelectedItem as ComboBoxItem;
            var selectedFileType = selectedItem.Value;

            Task.Profile.FileType = selectedFileType == "" ? null : selectedFileType;
            profileDirty = true;

            TaskToGUI();
        }

        private void textBoxFFmpegArguments_TextChanged(object sender, EventArgs e)
        {
            if (guiUpdateInProgres)
                return;

            profileDirty = true;
            Task.Profile.Arguments = textBoxFFmpegArguments.Text;

            TaskToGUI();

        }

        private void buttonSaveProfile_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogProfileName(Task.Profile.Name))
            {
                var result = dialog.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                var profileName = dialog.ProfileName;

                var existingProfile = VideoCutterSettings.Instance.FFmpegCutProfiles.FirstOrDefault(p => p.Name == profileName);
                if (existingProfile != null)
                {
                    var answer = MessageBox.Show($"Are you sure you want to overwrite profile '{existingProfile.Name}'?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (answer != DialogResult.OK)
                        return;

                    existingProfile.Arguments = Task.Profile.Arguments;
                    existingProfile.FileType = Task.Profile.FileType;
                }
                else
                {
                    var newProfile = new FFmpegCutProfile()
                    {
                        Name = profileName,
                        Arguments = Task.Profile.Arguments,
                        FileType = Task.Profile.FileType,
                    };
                    var profiles = VideoCutterSettings.Instance.FFmpegCutProfiles.ToList();
                    profiles.Add(newProfile);
                    VideoCutterSettings.Instance.FFmpegCutProfiles = profiles.ToArray();
                }

                Task.Profile.Name = VideoCutterSettings.Instance.SelectedFFmpegCutProfile = profileName;
                profileDirty = false;
                InitializeProfiles();
                TaskToGUI();
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


    }
}
