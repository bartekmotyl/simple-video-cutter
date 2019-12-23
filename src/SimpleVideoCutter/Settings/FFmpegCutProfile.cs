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
        public string Name { get; set; }
        public string Arguments { get; set; }
        public string FileType { get; set; }
    }
}
