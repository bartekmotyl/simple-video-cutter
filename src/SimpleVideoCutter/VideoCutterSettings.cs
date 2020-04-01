﻿using Newtonsoft.Json;
using SimpleVideoCutter.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter
{
    public class VideoCutterSettings
    {
        private const string configFile = "config.json";

        public string DefaultInitialDirectory { get; set; } = "{UserVideos}";
        public string OutputDirectory { get; set; } = "{UserVideos}";
        public string OutputFilePattern { get; set; } = "{FileDate}-{FileNameWithoutExtension}.{Timestamp}{FileExtension}";
        public string FFmpegPath { get; set; } = null;
        public string[] VideoFilesExtensions { get; set; } = new string[] { ".mov", ".avi", ".mp4", ".wmv", ".rm", ".mpg" };
        public int HoverPreviewSize { get; set; } = 300;

        public bool Mute { get; set; } = false;
        public bool Autostart { get; set; } = true;
        public bool ShowTaskWindow { get; set; } = true;

        public FFmpegCutProfile[] FFmpegCutProfiles = new FFmpegCutProfile[]
        {
            new FFmpegCutProfile() { Name = "lossless", Arguments = "-codec copy", FileType = null},
        };

        public string SelectedFFmpegCutProfile { get; set; } = "lossless";

        public Rectangle MainWindowLocation { get; set; } = Rectangle.Empty;
        public bool MainWindowMaximized { get; set; } = false;
        public bool RestoreToolbarsLayout { get; set; } = true;

        public string ConfigVersion { get; set; } = "0.0.0";

        public static VideoCutterSettings Instance { get; }  = new VideoCutterSettings()
        {
            ConfigVersion = Utils.GetCurrentRelease()
        };

        protected VideoCutterSettings()
        {
        }

        public void LoadSettings()
        {
            if (File.Exists(configFile))
            {
                var json = File.ReadAllText(configFile);
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
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(configFile, json);
        }
    }
}