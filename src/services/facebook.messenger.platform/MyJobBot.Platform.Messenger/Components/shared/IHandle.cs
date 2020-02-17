using MyJobBot.Platform.Messenger.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobBot.Platform.Messenger.Components.shared
{
    public interface IHanlde
    {
        bool Check(Messaging request);
        bool Check();
        bool Run(FacebookClient client, TaskChatBot taskChatBot);
        bool Execute(FacebookClient client, TaskChatBot taskChatBot);
        BaseHanlde TypingOn();
        BaseHanlde Navigation(short gotogroup, short gotostep);
        BaseHanlde NavigationSlave(short gotogroup, short gotostep);

        BaseHanlde PreSuccess(string name);
        BaseHanlde Gif(string name);
        BaseHanlde Success(string name);
    }
}
