using System;
using System.Collections.Generic;
using System.Text;
using MyJobBot.Platform.Messenger.Model;
using Newtonsoft.Json.Linq;

namespace MyJobBot.Platform.Messenger.Service.Template
{
    public interface ITemplateBuilder
    {
        JObject Get(FacebookClient client, string preSuccessTemplate);
    }
}
