using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.Settings
{
    [Serializable]
    public class FFmpegCutProfile
    {
        public static readonly FFmpegCutProfile Lossless = new FFmpegCutProfile()
        {
            Name = "Lossless",
            Arguments = "-codec copy",
        };

        public static readonly FFmpegCutProfile ReEncode = new FFmpegCutProfile()
        {
            Name = "Re-encode",
            Arguments = "",
        };
        public string Name { get; set; }
        public string Arguments { get; set; }
        public string FileType { get; set; }

        public FFmpegCutProfile Clone()
        {
            
            return MemberwiseClone() as FFmpegCutProfile;
        }
    }
}
