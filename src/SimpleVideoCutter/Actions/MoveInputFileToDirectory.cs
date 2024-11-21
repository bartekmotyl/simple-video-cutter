using System.IO;
using static SimpleVideoCutter.FileHelper;

namespace SimpleVideoCutter.Actions
{
    internal class MoveInputFileToDirectory : ActionAfterTaskCompletion, IActionRemovesInputFile
    {
        public readonly string TargetDirectory;

        public MoveInputFileToDirectory(FFmpegTask task) : base (task)
        {
            this.TargetDirectory = VideoCutterSettings.Instance.ActionInputFileTargetDirectory;
        }

        protected override void DoAction()
        {
            if (this.Task.InputFileName != null && this.Task.InputFilePath != null)
            {
                string targetPath = Path.Combine(TargetDirectory, this.Task.InputFileName);

                MaybeCreateParentDirectory(targetPath);

                File.Move(this.Task.InputFilePath, targetPath);
            }
        }
    }
}
