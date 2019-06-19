using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using static System.Linq.Enumerable;
using Microsoft.Win32;
using System.Net;
using System;
using System.IO;

namespace WhatsappMediaTutorial.Controllers
{
    public class WhatsAppMediaController : TwilioController
    {
        string GOOD_BOY_URL = "https://images.unsplash.com/photo-1518717758536-85ae29035b6d?ixlib=" +
           "rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80";
        
        public virtual SystemWebClient webClient()
        {
            return new SystemWebClient();
        }

        [HttpPostAttribute]
        public TwiMLResult Create(FormCollection formCollection)
        {
            var numMedia = int.Parse(formCollection["NumMedia"]);

            foreach (int resourceId in Range(0, numMedia))
            {
                var mediaUrl = formCollection[$"MediaUrl{resourceId}"];
                var mimeType = formCollection[$"MediaContentType{resourceId}"];
                var fileExtension = GetDefaultExtension(mimeType);
                var fileName = mediaUrl.Split('/').Last();
                var filePath = AppDataDirectory + fileName + "." + fileExtension;
                Debug.WriteLine(mediaUrl);
                Debug.WriteLine(filePath);
                webClient().DownloadFile(mediaUrl, filePath);
            }

            var response = new MessagingResponse();

            if (numMedia > 0)
            {
                response.Message("Thanks for the image(s)");
            } else
            {
                response.Message("Send us an image!");
            }

            return TwiML(response);
        }

        private string AppDataDirectory
        {
            get {
                var dataDirectory = Path.Combine(
                    Environment.CurrentDirectory, 
                    @"..\..\..\WhatsAppMediaTutorial\App_Data\"
                );
                return Path.GetFullPath(dataDirectory);
            }
        }

        public static string GetDefaultExtension(string mimeType)
        {
            var key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
            var value = key != null ? key.GetValue("Extension", null) : null;
            var result = value != null ? value.ToString() : string.Empty;

            return result;
        }
    
        private void LogParamsAsJson() => Debug.WriteLine(JsonConvert.SerializeObject(
                Request.Params.AllKeys.ToDictionary(r => r, r => Request.Params[r]),
                Formatting.Indented
            ).ToString());
    }
}
