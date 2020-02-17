using System;
using System.Collections.Generic;
using System.Text;
using MyJobBot.Platform.Messenger.Model;

namespace MyJobBot.Platform.Messenger.Repository.TasckChatBot
{
    public class TasckChatBotRepository : ITasckChatBotRepository
    {
        public TaskChatBot GetLastBySenderId(FacebookClient facebookClient)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskChatBot taskChatBot)
        {
            throw new NotImplementedException();
        }
    }
}
