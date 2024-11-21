using System.IO;

namespace SimpleVideoCutter
{
    internal class FileHelper
    {        
        public static void MaybeCreateParentDirectory(string? path)
        {
            if (path != null && VideoCutterSettings.Instance.CreateMissingDirectories)
            {
                string? parentDirectory = Path.GetDirectoryName(path);

                if (parentDirectory == null)
                {
                    return;
                }

                Directory.CreateDirectory(parentDirectory);
            }
        }
    }
}
