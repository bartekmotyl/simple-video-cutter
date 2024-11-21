using System;


namespace SimpleVideoCutter.Actions
{
    public abstract class ActionAfterTaskCompletion
    {
        public static readonly string ActionName = "";

        public FFmpegTask Task;

        public event EventHandler<ActionExecutingEventArgs>? ActionExecuting;

        public ActionAfterTaskCompletion(FFmpegTask task)
        {
            this.Task = task;
        }
        
        protected abstract void DoAction();

        public void Execute()
        {
            this.ActionExecuting?.Invoke(this, new ActionExecutingEventArgs(this, ActionName));

            this.DoAction();
        }
    }
}
