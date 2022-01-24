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
            TimeSpan start, TimeSpan end, string customArguments)
        {
            var commandBuilder = new StringBuilder();

            // Warning! There is a difference when placin 'ss' before or after 'i'.
            // See more in https://trac.ffmpeg.org/wiki/Seeking
            commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0} ", start);
            //commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -t {0} ", end - start);
            commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
            commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0} ", start);
            commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -t {0} ", end - start);
            commandBuilder.AppendFormat(" -map 0 ");
            commandBuilder.AppendFormat(" {0}", customArguments);

            return commandBuilder.AppendFormat(" \"{0}\" ", outputFileFullPath).ToString();
        }

        /*
        public static string BuildArgumentsSingleCutOperation(string inputFileFullPath, string outputFileFullPath,
            (TimeSpan Start, TimeSpan End)[] selections, string customArguments)
        {
            var commandBuilder = new StringBuilder();

            commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
            commandBuilder.AppendFormat(" -map 0 ");
            if (selections.Length == 1)
            {
                var selection = selections[0];
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0} ", selection.Start);
                commandBuilder.AppendFormat(" -t {0} ", selection.End - selection.Start);
            }
            else
            {

                string betweens = string.Join("+", selections.Select(s =>
                    $"between(t,{FormatTimeSpan(s.Start)},{FormatTimeSpan(s.End)})").ToArray());
                commandBuilder.AppendFormat($" -vf \"select='{betweens}' setpts=N/FRAME_RATE/TB\" ");
                commandBuilder.AppendFormat($" -af \"aselect='{betweens}' asetpts=N/SR/TB\" ");
            }
            commandBuilder.AppendFormat(" {0}", customArguments);

            return commandBuilder.AppendFormat(" \"{0}\" ", outputFileFullPath).ToString();
        }
        */

        private static string FormatTimeSpan(TimeSpan ts)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:0.000}", ts.TotalSeconds);
        }
    }
}