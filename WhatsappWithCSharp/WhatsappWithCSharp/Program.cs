using System;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Linq;

namespace WhatsappWithCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TwilioClient.Init("ACd3eb51da322fa67f1411def54eef4502", "97382ef2cc8afb6c551128b024f770e1");

            var message = MessageResource.Create(
                           from: new PhoneNumber("whatsapp:+14155238886"),
                           to: new PhoneNumber("whatsapp:+918870862782"),
                           body: "Hi Selva, I am Selva."
                       );

            Console.WriteLine("Message SID: " + message.Sid);
        }
    }
}
