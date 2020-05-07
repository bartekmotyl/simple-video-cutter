using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    class CustomWebClient : WebClient
    {
		private readonly Timer timeoutTimer;

		public int TimeoutMs { get; set; }

		public CustomWebClient()
		{
			timeoutTimer = new Timer();
			timeoutTimer.Tick += (object sender, EventArgs e) =>
			{
				CancelAsync();
			};
		}


		protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest wr = base.GetWebRequest(address);
            wr.Timeout = TimeoutMs; // timeout in milliseconds (ms)
            return wr;
        }

		public new async Task DownloadFileTaskAsync(Uri address, string fileName)
		{
			timeoutTimer.Interval = TimeoutMs;
			timeoutTimer.Start();
			await base.DownloadFileTaskAsync(address, fileName);
			timeoutTimer.Stop();
		}

		protected override void OnDownloadProgressChanged(DownloadProgressChangedEventArgs e)
		{
			timeoutTimer.Stop();
			timeoutTimer.Start();
			base.OnDownloadProgressChanged(e);
		}

		private async Task RunWithTimeout(Task task)
		{
			if (task == await Task.WhenAny(task, Task.Delay(TimeoutMs)))
			{
				await task;
			}
			else
			{
				this.CancelAsync();
				throw new TimeoutException();
			}
			
		}
	}
}
