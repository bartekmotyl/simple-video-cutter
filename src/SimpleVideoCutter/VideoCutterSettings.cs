using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter
{
    public class VideoCutterSettings
    {
        public string DefaultInitialDirectory { get; set; } = "{UserVideos}";
        public string OutputDirectory { get; set; } = "{UserVideos}";
        public string OutputFilePattern { get; set; } = "{FileDate}-{FileNameWithoutExtension}.{Timestamp}{FileExtension}";
        public string FFmpegPath { get; set; } = @"c:\ffmpeg\bin\ffmpeg.exe";
        public string[] VideoFilesExtensions { get; set; } = new string[] { ".mov", ".avi", ".mp4", ".wmv", ".rm", ".mpg" };

    }
}
