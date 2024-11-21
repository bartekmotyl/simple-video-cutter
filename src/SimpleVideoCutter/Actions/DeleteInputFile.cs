using System.IO;

namespace SimpleVideoCutter.Actions
{
    internal class DeleteInputFile : ActionAfterTaskCompletion, IActionRemovesInputFile
    {
        public DeleteInputFile(FFmpegTask task) : base(task) { }

        protected override void DoAction()
        {
            if (this.Task.InputFilePath != null)
            {
                File.Delete(this.Task.InputFilePath);
            }
        }
    }
}
