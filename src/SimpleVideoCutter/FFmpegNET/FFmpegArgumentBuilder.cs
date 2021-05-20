using FFmpeg.NET;
using FFmpeg.NET.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.FFmpegNET
{
    internal class FFmpegArgumentBuilder
    {
        public static string BuildArgumentsCutOperation(string inputFileFullPath, string outputFileFullPath,
            TimeSpan seek, TimeSpan duration, string customArguments)
        {
            var commandBuilder = new StringBuilder();
            
            commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0} ", seek);
            commandBuilder.AppendFormat(" -t {0} ", duration);
            commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
            commandBuilder.AppendFormat(" -map 0 ");
            commandBuilder.AppendFormat(" {0}", customArguments);
            
            return commandBuilder.AppendFormat(" \"{0}\" ", outputFileFullPath).ToString();
        }

    }
}