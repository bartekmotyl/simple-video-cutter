using SimpleVideoCutter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    public partial class FormFFmpegMissingDialog : Form
    {
        private bool stopDownloadRequest = false; 

        public FormFFmpegMissingDialog()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ffmpeg.zeranoe.com/builds/");
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            await DownloadLastestFFmpegVersion(Environment.Is64BitOperatingSystem);
        }

        public async Task DownloadLastestFFmpegVersion(bool x64)
        {
            var arch = x64 ? "win64" : "win32";
            var remoteFile = x64 ? "ffmpeg-latest-win64-static" : "ffmpeg-latest-win32-static";
            var url = $"https://ffmpeg.zeranoe.com/builds/{arch}/static/{remoteFile}.zip";
            var filename = "ffmpeg-latest-static.zip";
            var folderName = $"ffmpeg.{DateTime.Now:yyyyMMddHHmmss}";


            stopDownloadRequest = false;
            labelError.Visible = false;
            progressBarDownload.Value = 0;
            progressBarDownload.Visible = true;
            buttonClose.Text = GlobalStrings.GlobalCancel;

            try
            {
                using (var client = new CustomWebClient { TimeoutMs = 10000 })
                {
                    client.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                    {
                        progressBarDownload.Value = e.ProgressPercentage;
                        if (stopDownloadRequest)
                        {
                            client.CancelAsync();
                        }
                    };
                    client.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
                    {
                        if (!e.Cancelled && e.Error == null)
                        {
                            ZipFile.ExtractToDirectory(filename, folderName);
                            VideoCutterSettings.Instance.FFmpegPath = 
                                Path.Combine(Path.GetFullPath(folderName), remoteFile, "bin", "ffmpeg.exe");
                            labelDownloadSuccessful.Visible = true;
                            VideoCutterSettings.Instance.StoreSettings();
                        }
                    };

                    var uri = new Uri(url);
                    await client.DownloadFileTaskAsync(uri, filename);

                }
            } 
            catch (Exception)
            {
                labelError.Visible = true; 
            }
            progressBarDownload.Visible = false;
            buttonClose.Text = GlobalStrings.GlobalClose;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (progressBarDownload.Visible)
            {
                stopDownloadRequest = true; 
            }
            else
            {
                Close();
            }
        }
    }
}
