using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobBot.Platform.Messenger.Model
{
    public class TaskChatBot
    {
        public long Id { get; set; }
        public short PortalId { get; set; }
        public string SenderId { get; set; }
        public short Scope { get; set; }
        public short Group { get; set; }
        public short Step { get; set; }
        public short Retry { get; set; }
        public int Analytic { get; set; }
        public short StatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsRetry { get; set; }

        public TaskChatBot Reset()
        {
            Retry = 0;
            Scope = (int)0;
            Group = 0;
            Step = 0;
            StatusId = (int)0;

            return this;
        }

    }
}
