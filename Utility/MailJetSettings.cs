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
    public class MailJetSettings
    { public string ApiKey { get; set; }
    public string SecretKey { get; set; }
 
        }
    }
