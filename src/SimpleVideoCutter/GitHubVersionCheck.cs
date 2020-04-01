using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter
{
    internal class GitHubVersionCheck
    {
        public static async Task<string> GetLatestReleaseVersionFromGitHub()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("simple-video-cutter"));
                client.SetRequestTimeout(TimeSpan.FromSeconds(10));
                var releases = await client.Repository.Release.GetAll("bartekmotyl", "simple-video-cutter");
                var release = releases.FirstOrDefault();
                if (release != null)
                {
                    return release.Name;
                }
            }
            catch (Exception)
            {
                // well, just ingore, can happen when there is no internet connection
            }
            return null;
        }
    }

}
