using System;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Services.Enums;

namespace WebAPI.Services.ExternalServices
{
    public class SmsService : ISmsService
    {
        private readonly string AccountSid;
        private readonly string AuthToken;

        public string From { get; set; }
        public string To { get; set; }

        public SmsService()
        {
            this.AccountSid = ConfigurationManager.AppSettings.Get(ConfigSection.AccountSidTwillio.ToString());
            this.AuthToken = ConfigurationManager.AppSettings.Get(ConfigSection.AuthTokenTwillio.ToString());
            this.From = ConfigurationManager.AppSettings.Get(ConfigSection.PhoneNumberFrom.ToString());
            this.To = ConfigurationManager.AppSettings.Get(ConfigSection.PhoneNumberTo.ToString());
        }

        public void Send(string message)
        {
            if (!Active()) return;

            try
            {
                TwilioClient.Init(this.AccountSid, this.AuthToken);

                var messageResource = MessageResource.Create(from: new PhoneNumber(this.From),
                    to: new PhoneNumber(this.To),
                    body: message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool Active()
        {
            bool active;
            
            return bool.TryParse(ConfigurationManager.AppSettings.Get(ConfigSection.ActiveSms.ToString()), out active) 
                && active;
        }
    }
}
