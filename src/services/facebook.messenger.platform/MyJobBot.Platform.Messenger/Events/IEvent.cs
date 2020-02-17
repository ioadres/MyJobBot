using MyJobBot.Platform.Messenger.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobBot.Platform.Messenger.Events
{
    public interface IEvent
    {
        bool Check(Messaging messagin);
        void Execute(Messaging messagin, string idPage);
    }
}
