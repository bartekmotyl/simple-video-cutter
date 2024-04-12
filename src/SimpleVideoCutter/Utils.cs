using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SimpleVideoCutter
{
    public static class Utils
    {
        // Return a deep clone of an object of type T.
        // Copied from https://code-maze.com/csharp-deep-copy-of-object/
        public static T DeepCloneXML<T>(T input)
        {
            using var stream = new MemoryStream();

            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, input);
            stream.Position = 0;
            return (T)serializer.Deserialize(stream)!;
        }

        public static string GetCurrentRelease()
        {
            var currVer = Assembly.GetExecutingAssembly().GetName().Version ?? new Version(1, 0, 0, 0);
            var currentRelease = $"{currVer.Major}.{currVer.Minor}.{currVer.Build}";
            return currentRelease;
        }


        // Return True if a certain percent of a rectangle is shown across the total screen area of all monitors, otherwise return False.
        // Copied from https://stackoverflow.com/a/29596412
        public static bool IsOnScreen(System.Drawing.Point RecLocation, System.Drawing.Size RecSize, double MinPercentOnScreen = 0.2)
        {
            double PixelsVisible = 0;
            System.Drawing.Rectangle Rec = new System.Drawing.Rectangle(RecLocation, RecSize);

            foreach (Screen Scrn in Screen.AllScreens)
            {
                System.Drawing.Rectangle r = System.Drawing.Rectangle.Intersect(Rec, Scrn.WorkingArea);
                // intersect rectangle with screen
                if (r.Width != 0 & r.Height != 0)
                {
                    PixelsVisible += (r.Width * r.Height);
                    // tally visible pixels
                }
            }
            return PixelsVisible >= (Rec.Width * Rec.Height) * MinPercentOnScreen;
        }

        public static string ToNormalizedString(this TimeSpan time, bool includeFractionalSeconds = false)
        {
            if (time.TotalDays >= 1.0)
            {
                return includeFractionalSeconds ? 
                    string.Format($"{time:dd\\:hh\\:mm\\:ss\\:fff}") :
                    string.Format($"{time:dd\\:hh\\:mm\\:ss}");
            }
            else if (time.TotalHours >= 1.0)
            {
                return includeFractionalSeconds ?
                string.Format($"{time:hh\\:mm\\:ss\\:fff}") :
                string.Format($"{time:hh\\:mm\\:ss}");
            }
            else
            {
                return includeFractionalSeconds ?
                string.Format($"{time:mm\\:ss\\:fff}") :
                string.Format($"{time:mm\\:ss}");
            }
        }
    }

    public class Debouncer
    {
        private CancellationTokenSource? cancelTokenSource = null;

        public void Debounce(Action action, int milliseconds = 300)
        {
            cancelTokenSource?.Cancel();
            cancelTokenSource = new CancellationTokenSource();

            Task.Delay(milliseconds, cancelTokenSource.Token)
                .ContinueWith(t =>
                {
                    if (!t.IsCanceled)
                    {
                        action();
                    }
                }, TaskScheduler.Default);
        }
    }
}
