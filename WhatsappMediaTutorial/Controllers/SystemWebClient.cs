using System;
using System.Net;

namespace WhatsappMediaTutorial.Controllers
{
    public interface IWebClient : IDisposable
    {
        // Required methods (subset of `System.Net.WebClient` methods).
        void DownloadFile(string address, string fileName);
    }

    /// <summary>
    /// System web client.
    /// </summary>
    public class SystemWebClient : WebClient, IWebClient
    {
        public new virtual void DownloadFile(string address, string filename)
        {
            base.DownloadFile(address, filename);
        }
    }
}