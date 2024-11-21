using System.IO;
using static SimpleVideoCutter.FileHelper;

namespace SimpleVideoCutter.Actions
{
    internal class MoveInputFileToRelativeDirectory : ActionAfterTaskCompletion, IActionRemovesInputFile
    {
        public readonly string RelativeTargetDirectory;

        public MoveInputFileToRelativeDirectory(FFmpegTask task) : base(task)
        {
            this.RelativeTargetDirectory = VideoCutterSettings.Instance.ActionInputFileRelativeTargetDirectory;
        }

        protected override void DoAction()
        {
            if (this.Task.InputFilePath != null && this.Task.InputFileName != null)
            {
                string targetDirectory = Path.Combine(Path.GetDirectoryName(this.Task.InputFilePath) ?? ".", this.RelativeTargetDirectory);
                string targetPath = Path.Combine(targetDirectory, this.Task.InputFileName);

                MaybeCreateParentDirectory(targetPath);

                File.Move(this.Task.InputFilePath, targetPath);
            }
        }
    }
}
