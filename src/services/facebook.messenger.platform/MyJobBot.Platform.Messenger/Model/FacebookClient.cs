using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobBot.Platform.Messenger.Model
{
    public class FacebookClient
    {
        public string AccessToken { get; internal set; }
        public Sender SenderId { get; internal set; }
    }
}
