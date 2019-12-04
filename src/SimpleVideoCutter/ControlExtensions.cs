using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{


    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            try
            {
                if (!control.IsDisposed && control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidAsynchronousStateException)
            {
            }
        }

        public static void InvokeIfRequired<T>(this Control control, Action<T> action, T parameter)
        {
            try
            { 
                if (!control.IsDisposed && control.InvokeRequired)
                    control.Invoke(action, parameter);
                else
                    action(parameter);
                }
            catch (ObjectDisposedException)
            {
            }
        }
    }
}