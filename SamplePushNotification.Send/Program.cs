using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace SamplePushNotification.Send
{
    class Program
    {
        static void Main(string[] args)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json")
            });

            // This registration token comes from the client FCM SDKs.
            //var registrationToken = "daXtZG1uSAumLCrXQuNl8C:APA91bHbpmUCaw-YzboLc5fsNdcLji29P5L3uSN2YZc-bC3IDbU-y0EkNU80D-x1JyimGqO7a1SUlZ9QescKQ_1RQxZhHQCMYX-hBxk7S-zV2JX5BEEvKJrppS9TJKfDBxMFe2A1pRsQ";

            
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
    {
        { "myData", "1337" },
    },
                //Token = registrationToken,
                Topic = "all",
                Notification = new Notification()
                {
                    Title = "Hi, teacher",
                    Body = "Update now your class plan, please!"
                }
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }
    }
}