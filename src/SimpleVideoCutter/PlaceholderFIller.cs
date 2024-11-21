using System;
using System.IO;
using System.Runtime.Versioning;

namespace SimpleVideoCutter
{
    [SupportedOSPlatform("windows")]
    public class PlaceholderFiller
    {
        private VideoCutterTimeline VideoCutterTimeline;

        public PlaceholderFiller(VideoCutterTimeline videoCutterTimeline)
        {
            VideoCutterTimeline = videoCutterTimeline;
        }

        public string ReplaceStandardDirectoryPatterns(string str, string? path)
        {
            return str
                .Replace("{SameFolder}", Path.GetDirectoryName(path))
                .Replace("{UserVideos}", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
                .Replace("{UserDocuments}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                .Replace("{MyComputer}", Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
        }

        public string ReplaceFilePatterns(string str, string path)
        {
            var fileInfo = new FileInfo(path);

            return str
                .Replace("{FileName}", Path.GetFileName(path))
                .Replace("{FileNameWithoutExtension}", Path.GetFileNameWithoutExtension(path))
                .Replace("{FileExtension}", Path.GetExtension(path))
                .Replace("{FileDate}", string.Format("{0:yyyyMMdd-HHmmss}", fileInfo.LastWriteTime))
                .Replace("{Timestamp}", string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now))
                .Replace("{SelectionStart}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(VideoCutterTimeline.Selections.OverallStart!.Value)))
                .Replace("{SelectionEnd}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(VideoCutterTimeline.Selections.OverallEnd!.Value)))
                .Replace("{SelectionStartMs}", string.Format("{0}", VideoCutterTimeline.Selections.OverallStart.Value))
                .Replace("{SelectionEndMs}", string.Format("{0}", VideoCutterTimeline.Selections.OverallEnd.Value))
                .Replace("{Duration}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(VideoCutterTimeline.Selections.OverallDuration)));
        }
    }
}
