using MyJobBot.Platform.Messenger.Components.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobBot.Platform.Messenger.Components
{
    public interface IMessages
    {
        List<IHanlde> Get(object client, object taskChatBot);
    }
    public class Messages : IMessages
    {
        public IHanlde Get(object client, object taskChatBot)
        {
            throw new NotImplementedException();
        }

        List<IHanlde> IMessages.Get(object client, object taskChatBot)
        {
            throw new NotImplementedException();
        }
    }
}
