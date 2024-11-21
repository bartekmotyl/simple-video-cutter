using System;


namespace SimpleVideoCutter.Actions
{
    public class ActionExecutingEventArgs: EventArgs
    {
        public ActionAfterTaskCompletion Action;

        public string ActionName;

        public ActionExecutingEventArgs(ActionAfterTaskCompletion action, string actionName)
        { 
            this.Action = action;
            this.ActionName = actionName;
        }
    }
}
