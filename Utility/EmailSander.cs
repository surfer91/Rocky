using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace Rocky.Utility
{
    public class EmailSender:IEmailSender
    {
    
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email,subject,htmlMessage);
        }
        public async Task Execute(string email, string subject, string body){
               MailjetClient client = new MailjetClient("d843abb490c647c166f95827ae9455f0", "3fe8d2e20c8a0326a1fc996df49bc3f2") {
    Version = ApiVersion.V3_1,
   };
   MailjetRequest request = new MailjetRequest {
     Resource = Send.Resource,
    }
    .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "l2eu@wp.pl"}, 
        {"Name", "Chris"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
          "krzysiekkli@wp.pl"
         }, {
          "Name",
          "Chris"
         }
        }
       }
      }, {
       "Subject",
      subject
      }, {
       "TextPart",
       "My first Mailjet email"
      }, {
       "HTMLPart",
      body
      }
     }
    });
await client.PostAsync(request);
        }
    }
}