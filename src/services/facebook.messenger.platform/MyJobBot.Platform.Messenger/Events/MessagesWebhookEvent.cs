using System;
using System.Collections.Generic;
using System.Text;
using MyJobBot.Platform.Messenger.Components;
using MyJobBot.Platform.Messenger.Model;
using MyJobBot.Platform.Messenger.Repository.TasckChatBot;

namespace MyJobBot.Platform.Messenger.Events
{
    public class MessagesWebhookEvent : IEvent
    {
        private readonly IMessages _messages;
        private readonly ITasckChatBotRepository _tasckChatBotRepository;

        public bool Check(Messaging messagin)
        {
            return messagin.message != null;
        }

        public void Execute(Messaging messagin, string idPage)
        {
            try
            {
                var facebookClient = new FacebookClient()
                {
                    SenderId = messagin.sender,
                    AccessToken = ""
                };

                if (!string.IsNullOrEmpty(facebookClient.AccessToken))
                {
                    var totalcycles = 2;
                    while (Work(facebookClient, messagin))
                    {
                        if (totalcycles <= 0) break;
                        totalcycles--;
                    }

                }
            }
            catch (Exception e)
            {
            }
        }

        private bool Work(FacebookClient facebookClient, Messaging messagin)
        {
            var continueProcess = false;
            var taskChatBot = _tasckChatBotRepository.GetLastBySenderId(facebookClient);
            var strategies = _messages.Get(facebookClient, taskChatBot);
            foreach (var strategy in strategies)
            {
                if (strategy.Check(messagin))
                {
                    continueProcess = strategy.Run(facebookClient, taskChatBot);
                    break;
                }
            }
            return continueProcess;
        }
    }
}
