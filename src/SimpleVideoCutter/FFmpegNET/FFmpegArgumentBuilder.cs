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
            (TimeSpan Seek, TimeSpan Duration)[] selections, string customArguments)
        {
            var commandBuilder = new StringBuilder();
            if (selections.Length == 1)
            {
                var selection = selections[0];
                commandBuilder.AppendFormat(CultureInfo.InvariantCulture, " -ss {0} ", selection.Seek);
                commandBuilder.AppendFormat(" -t {0} ", selection.Duration);
                commandBuilder.AppendFormat(" -i \"{0}\" ", inputFileFullPath);
                commandBuilder.AppendFormat(" -map 0 ");
                commandBuilder.AppendFormat(" {0}", customArguments);
            }
            else
            {

            }

            return commandBuilder.AppendFormat(" \"{0}\" ", outputFileFullPath).ToString();
        }

    }
}