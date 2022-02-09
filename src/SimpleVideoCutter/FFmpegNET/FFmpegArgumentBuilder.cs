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
        public static string BuildArgumentsSingleCutOperation(string inputFileFullPath, string outputFileFullPath,
            TimeSpan start, TimeSpan end, bool lossless)
        {
            var commandBuilder = new StringBuilder();

            // Warning! There is a difference when placin 'ss' before or after 'i'.
            // See more in https://trac.ffmpeg.org/wiki/Seeking

            if (lossless)
            {
                // Maybe also use -noaccurate_seek ?
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0:0.000} ", start.TotalSeconds);
                commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
                commandBuilder.AppendFormat(" -codec copy -copyts ");
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -to {0:0.000} ", end.TotalSeconds);
                commandBuilder.AppendFormat(" -map 0 ");
            }
            else
            {
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0:0.000} ", start.TotalSeconds);
                commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
                commandBuilder.AppendFormat(" -copyts ");
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -to {0:0.000} ", end.TotalSeconds);
                commandBuilder.AppendFormat(" -map 0 ");
            }

            return commandBuilder.AppendFormat(" \"{0}\" ", outputFileFullPath).ToString();
        }
    }
}