using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Messaging;
using WhatsappMediaTutorial.Controllers;


namespace WhatsappMediaTutorial.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestInitialize]
        public void SetupTests()
        {
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            string requestData = "{\n  \"MediaContentType0\": \"image/jpeg\",\n  \"SmsMessageSid\": \"MM19df5a6293470c5e309890648740986a\"," +
                "\n  \"NumMedia\": \"1\",\n  \"SmsSid\": \"MM19df5a6293470c5e309890648740986a\",\n  \"SmsStatus\": \"received\",\n  " +
                "\"Body\": \"\",\n  \"To\": \"whatsapp:+14155238886\",\n  \"NumSegments\": \"1\",\n  " +
                "\"MessageSid\": \"MM19df5a6293470c5e309890648740986a\",\n  \"AccountSid\": \"AC4ee8a4bf66c95837fc46316395718baa\",\n  " +
                "\"From\": \"whatsapp:+5213321678083\",\n  " +
                "\"MediaUrl0\": \"https://api.twilio.com/2010-04-01/Accounts/AC4ee8a4bf66c95837fc46316395718baa/Messages/MM19df5a6293470c5e309890648740986a/Media/ME456a12de2891e2a69bc11a23aab6b9c5\",\n  " +
                "\"ApiVersion\": \"2010-04-01\",\n  \"ALL_HTTP\": \"HTTP_CACHE_CONTROL:max-age=259200\\r\\nHTTP_CONNECTION:close\\r\\nHTTP_CONTENT_LENGTH:540\\r\\nHTTP_CONTENT_TYPE:application/x-www-form-urlencoded\\r\\nHTTP_ACCEPT:*/*\\r" +
                "\\nHTTP_HOST:localhost:8081\\r\\nHTTP_USER_AGENT:TwilioProxy/1.1\\r\\nHTTP_X_FORWARDED_FOR:54.225.17.109\\r\\nHTTP_X_ORIGINAL_HOST:b924869a.ngrok.io\\r\\nHTTP_X_TWILIO_SIGNATURE:WctwS3sxSyuCNpIBxIRYE0sCYpY=\\r\\n\",\n  " +
                "\"ALL_RAW\": \"Cache-Control: max-age=259200\\r\\nConnection: close\\r\\nContent-Length: 540\\r\\nContent-Type: application/x-www-form-urlencoded\\r\\nAccept: */*\\r" +
                "\\nHost: localhost:8081\\r\\nUser-Agent: TwilioProxy/1.1\\r\\nX-Forwarded-For: 54.225.17.109\\r\\nX-Original-Host: b924869a.ngrok.io\\r" +
                "\\nX-Twilio-Signature: WctwS3sxSyuCNpIBxIRYE0sCYpY=\\r\\n\",\n  \"APPL_MD_PATH\": \"/LM/W3SVC/3/ROOT\",\n  " +
                "\"APPL_PHYSICAL_PATH\": \"C:\\\\Users\\\\Jose Oliveros\\\\source\\\\repos\\\\WhatsappMediaTutorial\\\\WhatsappMediaTutorial\\\\\",\n  \"AUTH_TYPE\": \"\",\n  \"AUTH_USER\": \"\",\n  " +
                "\"AUTH_PASSWORD\": \"\",\n  \"LOGON_USER\": \"\",\n  \"REMOTE_USER\": \"\",\n  \"CERT_COOKIE\": \"\",\n  \"CERT_FLAGS\": \"\",\n  \"CERT_ISSUER\": \"\",\n  \"CERT_KEYSIZE\": \"\",\n  " +
                "\"CERT_SECRETKEYSIZE\": \"\",\n  \"CERT_SERIALNUMBER\": \"\",\n  \"CERT_SERVER_ISSUER\": \"\",\n  \"CERT_SERVER_SUBJECT\": \"\",\n  \"CERT_SUBJECT\": \"\",\n  " +
                "\"CONTENT_LENGTH\": \"540\",\n  \"CONTENT_TYPE\": \"application/x-www-form-urlencoded\",\n  \"GATEWAY_INTERFACE\": \"CGI/1.1\",\n  \"HTTPS\": \"off\",\n  \"HTTPS_KEYSIZE\": \"\",\n  " +
                "\"HTTPS_SECRETKEYSIZE\": \"\",\n  \"HTTPS_SERVER_ISSUER\": \"\",\n  \"HTTPS_SERVER_SUBJECT\": \"\",\n  \"INSTANCE_ID\": \"3\",\n  \"INSTANCE_META_PATH\": \"/LM/W3SVC/3\",\n  " +
                "\"LOCAL_ADDR\": \"::1\",\n  \"PATH_INFO\": \"/WhatsAppMedia/Create\",\n  " +
                "\"PATH_TRANSLATED\": \"C:\\\\Users\\\\Jose Oliveros\\\\source\\\\repos\\\\WhatsappMediaTutorial\\\\WhatsappMediaTutorial\\\\WhatsAppMedia\\\\Create\",\n  \"QUERY_STRING\": \"\",\n  " +
                "\"REMOTE_ADDR\": \"::1\",\n  \"REMOTE_HOST\": \"::1\",\n  \"REMOTE_PORT\": \"50371\",\n  \"REQUEST_METHOD\": \"POST\",\n  \"SCRIPT_NAME\": \"/WhatsAppMedia/Create\",\n  " +
                "\"SERVER_NAME\": \"localhost\",\n  \"SERVER_PORT\": \"8081\",\n  \"SERVER_PORT_SECURE\": \"0\",\n  \"SERVER_PROTOCOL\": \"HTTP/1.1\",\n  \"SERVER_SOFTWARE\": \"Microsoft-IIS/10.0\",\n  " +
                "\"URL\": \"/WhatsAppMedia/Create\",\n  \"HTTP_CACHE_CONTROL\": \"max-age=259200\",\n  \"HTTP_CONNECTION\": \"close\",\n  \"HTTP_CONTENT_LENGTH\": \"540\",\n  " +
                "\"HTTP_CONTENT_TYPE\": \"application/x-www-form-urlencoded\",\n  \"HTTP_ACCEPT\": \"*/*\",\n  \"HTTP_HOST\": \"localhost:8081\",\n  \"HTTP_USER_AGENT\": \"TwilioProxy/1.1\",\n  " +
                "\"HTTP_X_FORWARDED_FOR\": \"54.225.17.109\",\n  \"HTTP_X_ORIGINAL_HOST\": \"b924869a.ngrok.io\",\n  \"HTTP_X_TWILIO_SIGNATURE\": \"WctwS3sxSyuCNpIBxIRYE0sCYpY=\"\n}";

            var rawParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestData);
            var _params = new NameValueCollection();
            var formCollection = new FormCollection();

            foreach (var pair in rawParams)
            {
                _params.Add(pair.Key, pair.Value);
                formCollection.Add(pair.Key, pair.Value);
            }

            var request = new Mock<HttpRequestBase>();
            request.SetupGet(x => x.Params).Returns(_params);
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);

            var controllerMock = new Mock<WhatsAppMediaController>() { CallBase = true };

            // Mock WebClient
            var webClientMock = new Mock<SystemWebClient>();
            webClientMock.Setup(w => w.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));
            controllerMock.Setup(c => c.webClient()).Returns(webClientMock.Object);

            controllerMock.Object.ControllerContext = new ControllerContext(context.Object, new RouteData(), controllerMock.Object);

            // Act
            TwiMLResult result = controllerMock.Object.Create(formCollection)
                as TwiMLResult;

            var expectedTwimlResponse = new MessagingResponse();
            expectedTwimlResponse.Message("Thanks for the image(s)");
            expectedTwimlResponse.Append(new Media(WhatsAppMediaController.GOOD_BOY_URL));
            var expectedTwimlResult = new TwiMLResult(expectedTwimlResponse);

            // Assert
            Assert.AreEqual(expectedTwimlResult.Data.ToString(), result.Data.ToString());
        }
    }
}
