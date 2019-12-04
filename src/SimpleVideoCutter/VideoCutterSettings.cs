using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public static VideoCutterSettings Instance { get; }  = new VideoCutterSettings();


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

        }
        public void StoreSettings()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(configFile, json);
        }
    }
}