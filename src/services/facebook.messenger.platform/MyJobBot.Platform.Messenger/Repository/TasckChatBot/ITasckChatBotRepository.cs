using System;
using System.Collections.Generic;
using System.Text;
using MyJobBot.Platform.Messenger.Model;

namespace MyJobBot.Platform.Messenger.Repository.TasckChatBot
{
    public interface ITasckChatBotRepository
    {
        TaskChatBot GetLastBySenderId(FacebookClient facebookClient);
        void Update(TaskChatBot taskChatBot);
    }
}
