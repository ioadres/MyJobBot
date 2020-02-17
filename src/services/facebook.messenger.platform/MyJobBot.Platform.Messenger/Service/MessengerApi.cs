using System;
using System.Collections.Generic;
using System.Text;
using MyJobBot.Platform.Messenger.Model;
using Newtonsoft.Json.Linq;

namespace MyJobBot.Platform.Messenger.Service
{
    public interface IMessengerApi
    {
        void Update(TaskChatBot taskChatBot);
        void SendWithResponse(FacebookClient client, bool v);
        void SendWithResponse(FacebookClient client, JObject v);
    }
    public class MessengerApi : IMessengerApi
    {
        public void SendWithResponse(FacebookClient client, bool v)
        {
            throw new NotImplementedException();
        }

        public void SendWithResponse(FacebookClient client, JObject v)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskChatBot taskChatBot)
        {
            throw new NotImplementedException();
        }
    }
}
