using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VideoCutterSettings.Instance.LoadSettings();

            if (VideoCutterSettings.Instance.Language == null)
            {
                VideoCutterSettings.Instance.Language = Thread.CurrentThread.CurrentUICulture.Name;
            }
            else
            {
                var culture = CultureInfo.GetCultureInfo(VideoCutterSettings.Instance.Language);
                if (culture != null)
                {
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
