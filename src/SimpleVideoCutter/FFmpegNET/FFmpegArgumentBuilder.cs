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
                if (VideoCutterSettings.Instance.LosslessInputSeeking)
                {
                    commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0:0.000} ", start.TotalSeconds);
                }
                commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
                if (VideoCutterSettings.Instance.LosslessOutputSeeking && !VideoCutterSettings.Instance.LosslessInputSeeking)
                {
                    commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0:0.000} ", start.TotalSeconds);
                }
                commandBuilder.AppendFormat(" -codec copy ");
                commandBuilder.AppendFormat(" -copyts ");
                commandBuilder.AppendFormat(" -avoid_negative_ts make_zero ");
                
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -to {0:0.000} ", end.TotalSeconds);
                commandBuilder.AppendFormat(" -map 0:v -map 0:a? ");
            }
            else
            {
                if (VideoCutterSettings.Instance.LossyInputSeeking)
                {
                    commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0:0.000} ", start.TotalSeconds);
                }
                commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
                if (VideoCutterSettings.Instance.LossyOutputSeeking && !VideoCutterSettings.Instance.LossyInputSeeking)
                {
                    commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0:0.000} ", start.TotalSeconds);
                }
                commandBuilder.AppendFormat(" -copyts ");
                commandBuilder.AppendFormat(" -avoid_negative_ts make_zero ");
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -to {0:0.000} ", end.TotalSeconds);
                commandBuilder.AppendFormat(" -map 0:v -map 0:a? ");
            }

            var cmd = commandBuilder.AppendFormat(" \"{0}\" ", outputFileFullPath).ToString();
            return cmd;
        }
    }
}