using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    public class VideoCutterSettings
    {
        private const string configFile = "config.json";

        public string DefaultInitialDirectory { get; set; } = "{UserVideos}";
        public string OutputDirectory { get; set; } = "{UserVideos}";
        public string OutputFilePattern { get; set; } = "{FileDate}-{FileNameWithoutExtension}.{Timestamp}{FileExtension}";
        public string[] QuickSubDirectories { get; set; } = Enumerable.Repeat("", 9).ToArray();
        public bool CreateMissingDirectories { get; set; } = false;
        public bool ShowQuickSubDirectoryDialog { get; set; } = false;
        public string? ActionAfterTaskCompletion { get; set; }
        public string ActionInputFileTargetDirectory { get; set; } = "";
        public string ActionInputFileRelativeTargetDirectory { get; set; } = "";
        public string FFmpegPath { get; set; } = @".\ffmpeg.exe";
        public string[] VideoFilesExtensions { get; set; } = new string[] { ".mov", ".avi", ".mp4", ".wmv", ".rm", ".mpg", ".mkv", ".webm", ".ts" };
        public bool Mute { get; set; } = false;
        public bool ShowPreview { get; set; } = true;
        public bool KeepSelectionAfterCut { get; set; } = true;
        public bool Autostart { get; set; } = true;
        public bool ShowTaskWindow { get; set; } = true;

        public Rectangle MainWindowLocation { get; set; } = Rectangle.Empty;
        public bool MainWindowMaximized { get; set; } = false;
        public bool RestoreToolbarsLayout { get; set; } = true;
        
        public bool LosslessInputSeeking { get; set; } = true;
        public bool LosslessOutputSeeking { get; set; } = false;
        public bool LossyInputSeeking { get; set; } = true;
        public bool LossyOutputSeeking { get; set; } = false;

        public string ConfigVersion { get; set; } = "0.0.0";
        public string LastVersion { get; set; } = "0.0.0";

        public string? Language { get; set; }
        public PreviewSize PreviewSize { get; set; } = PreviewSize.L;
 
        [JsonIgnore]
        public string ConfigFolder { get; set; } = AppDomain.CurrentDomain.BaseDirectory;


        public static VideoCutterSettings Instance { get; } = new VideoCutterSettings() 
        {
            ConfigVersion = Utils.GetCurrentRelease()
        };

        protected VideoCutterSettings()
        {
        }

        public string ConfigPath 
        { 
            get
            {
                return Path.Combine(Path.Combine(ConfigFolder, configFile));
            } 
        }

        public void LoadSettings()
        {
            if (File.Exists(ConfigPath))
            {
                var json = File.ReadAllText(ConfigPath);
                try
                {
                    JsonConvert.PopulateObject(json, this);
                }
                catch (Exception)
                {
                }
            }

            // After upgrading to new release we avoid restoring layouts, 
            // as usually the strcutre of layouts change in new relese and trying 
            // to restore incompatble layout leads to empty screen. 
            var appVer = new Version(Utils.GetCurrentRelease());
            var configVer = new Version(ConfigVersion);
            if (configVer != appVer) 
            {
                RestoreToolbarsLayout = false; 
            }
        }
        public void StoreSettings()
        {
            LastVersion = Utils.GetCurrentRelease();
            try
            {
                var folder = Path.GetDirectoryName(ConfigPath);
                if (folder != null && !Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception)
            {
                MessageBox.Show("Not possible to save settings. Please check whether folder is writable", 
                    "Config cannot be saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public enum PreviewSize
    {
        None,
        XS, 
        S,
        L,
        XL,

    }
}