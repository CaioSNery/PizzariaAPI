using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Pizzaria.Interface;
using Pizzaria.Settings;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Pizzaria.Services
{
    public class SMSService:ISMSService

    {
        private readonly TwilioSettings _settings;
        public SMSService(IOptions<TwilioSettings> options)
        {
            _settings = options.Value;
            TwilioClient.Init(_settings.AccountSID, _settings.AuthToken);
        }
        public async Task EnviasSMSAsync(string numero, string mensagem)
        {
            await MessageResource.CreateAsync(
                body: mensagem,
                from: new PhoneNumber(_settings.From),
                to: new PhoneNumber(numero)

            );
        }

         
    }
}