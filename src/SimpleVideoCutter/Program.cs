using CommandLine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{

    public class CommandLineOptions
    {
        [Option("configApplicationData", Default = false, SetName = "config")]
        public bool ConfigApplicationData { get; set; }

        [Option("configLocalApplicationData", Default = false, SetName = "config")]
        public bool ConfigLocalApplicationData { get; set; }
        
        [Option("configCurrentFolder", Default = false, SetName = "config")]
        public bool ConfigCurrentFolder { get; set; }
        
        [Value(0, Default = null, MetaName = "videoFile")]
        public string VideoFile { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string fileToLoadOnStartup = null;
            string svcFolder = "SimpleVideoCutter";
            string configFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), svcFolder);

            var result = Parser.Default.ParseArguments<CommandLineOptions>(args);
            result.WithParsed(parsed =>
            {
                if (parsed.ConfigCurrentFolder)
                {
                    configFolder = ".";
                }
                else if (parsed.ConfigApplicationData)
                {
                    configFolder = Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.ApplicationData), svcFolder);
                }
                else if (parsed.ConfigLocalApplicationData)
                {
                    configFolder = Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData), svcFolder);
                }
                fileToLoadOnStartup = parsed.VideoFile;
            }).WithNotParsed(errs =>
            {
                // just ignore
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainForm(fileToLoadOnStartup, configFolder);
            Application.Run(form);
        }
    }
}
