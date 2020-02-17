using MyJobBot.Platform.Messenger.Model;
using MyJobBot.Platform.Messenger.Repository.TasckChatBot;
using MyJobBot.Platform.Messenger.Service;
using MyJobBot.Platform.Messenger.Service.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobBot.Platform.Messenger.Components.shared
{
    public class BaseHanlde : IHanlde
    {
        protected short GotoGroup = -1;
        protected short GotoStep = -1;
        protected short GotoSlaveGroup = -1;
        protected short GotoSlaveStep = -1;

        protected string PreSuccessTemplate;
        protected string GifTemplate;
        protected string SuccessTemplate;


        protected bool CONTINUE = false;

        protected bool Typing = false;

        private readonly IMessengerApi _messengerApi;
        private readonly ITasckChatBotRepository _tasckChatBotRepository;
        private readonly Service.Template.ITemplateBuilder _templateBuilder;

        public BaseHanlde(IMessengerApi messengerApi, ITasckChatBotRepository tasckChatBotRepository, ITemplateBuilder templateBuilder)
        {
            _messengerApi = messengerApi;
            _tasckChatBotRepository = tasckChatBotRepository;
            _templateBuilder = templateBuilder;
        }

        public void Navigate(TaskChatBot taskChatBot)
        {
            if (GotoGroup != -1 && GotoStep != -1)
            {
                taskChatBot.Group = GotoGroup;
                taskChatBot.Step = GotoStep;
                _messengerApi.Update(taskChatBot);
            }
        }

        public void NavigateSlave(TaskChatBot taskChatBot)
        {
            if (GotoSlaveGroup != -1 && GotoSlaveStep != -1)
            {
                taskChatBot.Group = GotoSlaveGroup;
                taskChatBot.Step = GotoSlaveStep;
                _tasckChatBotRepository.Update(taskChatBot);
            }
        }

        public virtual bool Check()
        {
            return false;
        }

        public virtual bool Check(Messaging request)
        {
            return true;
        }

        public virtual bool Run(FacebookClient client, TaskChatBot taskChatBot)
        {
            if (Typing)
            {
                _messengerApi.SendWithResponse(client, true);
            }

            var result = Execute(client, taskChatBot);

            if (CheckNavigateSlave(taskChatBot))
            {
                NavigateSlave(taskChatBot);
                return result;
            }
            if (!string.IsNullOrEmpty(this.PreSuccessTemplate))
            {
                 var template = _templateBuilder.Get(client, PreSuccessTemplate);
                _messengerApi.SendWithResponse(client, template);
            }
            if (!string.IsNullOrEmpty(this.GifTemplate))
            {
                var template = _templateBuilder.Get(client, GifTemplate);
                _messengerApi.SendWithResponse(client, template);
            }
            if (!string.IsNullOrEmpty(this.SuccessTemplate))
            {
                var template = _templateBuilder.Get(client, SuccessTemplate);
                _messengerApi.SendWithResponse(client, template);
            }
            Navigate(taskChatBot);
            return result;
        }

        public virtual bool CheckNavigateSlave(TaskChatBot taskChatBot)
        {
            return false;
        }

        public virtual bool Execute(FacebookClient facebookClient,TaskChatBot taskChatBot)
        {
            return false;
        }

        public BaseHanlde TypingOn()
        {
            Typing = true;
            return this;
        }


        public BaseHanlde Navigation(short gotogroup, short gotostep)
        {
            GotoGroup = gotogroup;
            GotoStep = gotostep;
            return this;
        }

        public BaseHanlde NavigationSlave(short gotogroup, short gotostep)
        {
            GotoSlaveGroup = gotogroup;
            GotoSlaveStep = gotostep;
            return this;
        }

        public BaseHanlde PreSuccess(string name)
        {
            this.PreSuccessTemplate = name;
            return this;
        }

        public BaseHanlde Gif(string name)
        {
            this.GifTemplate = name;
            return this;
        }

        public BaseHanlde Success(string name)
        {
            this.SuccessTemplate = name;
            return this;
        }
    }
}
