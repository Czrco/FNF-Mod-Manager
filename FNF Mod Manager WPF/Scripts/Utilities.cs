using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
// FILE DESCRIPTION
// this is for other shits like checking for intenet and downloading strings.
// don't worry about this file too much unless if you want to add a miscallaneous function.
// FILE DESCRIPTION END
namespace Scripts
{
    class Utilities
    {

        public bool InternetConnectivity()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void OpenURL(string url)
        {
            var uri = url;
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        public string StringDownload(string link)
        {
            string webData;
            WebClient wc = new WebClient();
            webData = wc.DownloadString(link);
            return webData;
        }

        public string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 0; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        public void WriteLine(string fileName, string file)
        {
            File.AppendAllText(fileName, file + Environment.NewLine);
        }

        public string ReadFile(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public string FilePrompt(string filter, string filter1)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = filter1.Replace("*", "");
            fileDialog.Filter = filter + "|" + filter1;
            fileDialog.ShowDialog();
            return fileDialog.FileName.ToString();
        }
    }
}
