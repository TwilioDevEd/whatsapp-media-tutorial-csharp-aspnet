<a href="https://www.twilio.com">
  <img src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg" alt="Twilio" width="250" />
</a>

# Receive, Download, and Reply with media in WhatsApp Messages. Powered by Twilio - C#/Asp.NET

Use Twilio to receive WhatsApp media messages. For a step-by-step tutorial see
the [Twilio docs](https://www.twilio.com/docs/sms/whatsapp/tutorial/send-and-receive-media-messages-whatsapp-csharp-aspnet).

## Local development

To run the app locally:

1. Clone this repository and open the solution in Visual Studio 2019.

   ```bash
   git clone git@github.com:TwilioDevEd/whatsapp-media-tutorial-csharp-aspnet.git
   cd whatsapp-media-tutorial-csharp-aspnet
   ```

1. In the `Package-Manager Console` run:

   ```bash
   nuget restore
   ```

1. Run the application with `f5`.

1. Expose your application to the wider internet using
   [ngrok](http://ngrok.com/). This step is important because the
   application won't work as expected if you run it through localhost.

   ```bash
   ngrok http -host-header=localhost 8081
   ```

   **Note:** You can read
   [this blog post](https://www.twilio.com/blog/2015/09/6-awesome-reasons-to-use-ngrok-when-testing-webhooks.html)
   for more details on how to use ngrok.

1. Configure Twilio's Sandbox for WhatsApp to call your webhook URL

   You will need to configure your [Twilio Sandbox for WhatsApp](https://www.twilio.com/console/sms/whatsapp/sandbox) to call your application (exposed via ngrok) when your Sandbox number receives an incoming message. Your URL will look something like this:

   ```
   http://6b5f6b6d.ngrok.io/WhatsAppMedia/Create
   ```

   Here are detailed instructions for [Twilio Sandbox for WhatsApp](https://www.twilio.com/docs/sms/whatsapp/api#twilio-sandbox-for-whatsapp)


## How to Demo

1. Send a message with a media attachment to your WhatsApp Sandbox phone number

1. Your ASP.NET application should handle the incoming request from Twilio and download the images to the `App_Data` directory. In a few moments, you should get back a WhatsApp reply.


## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
