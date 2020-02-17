using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJobBot.Platform.Messenger.Model
{
    public class Sender
    {
        public string id { get; set; }
    }

    public class Recipient
    {
        public string id { get; set; }
    }

    public class Referral
    {
        public string @ref { get; set; }
        public string source { get; set; }
        public string type { get; set; }
        public string referer_uri { get; set; }
    }

    public class Postback
    {
        public string title { get; set; }
        public string payload { get; set; }
        public Referral referral { get; set; }
    }

    public class Messaging
    {
        public Sender sender { get; set; }
        public Recipient recipient { get; set; }
        public long timestamp { get; set; }
        public Postback postback { get; set; }
        public Referral referral { get; set; }
        public Message message { get; set; }
        public take_thread_control take_thread_control { get; set; }
        public pass_thread_control pass_thread_control { get; set; }

    }


    public class take_thread_control
    {
        public string previous_owner_app_id { get; set; }
        public string metadata { get; set; }
    }

    public class pass_thread_control
    {
        public string new_owner_app_id { get; set; }
        public string metadata { get; set; }
    }


    public class QuickReply
    {
        public string payload { get; set; }
    }

    public class Message
    {
        public QuickReply quick_reply { get; set; }
        public string mid { get; set; }
        public string text { get; set; }
       // public Nlp nlp { get; set; }
    }

    public class Entry
    {
        public string id { get; set; }
        public long time { get; set; }
        public List<Messaging> messaging { get; set; }
        public List<Standby> standby { get; set; }
    }

    public class Standby
    {
        public Sender sender { get; set; }
        public Recipient recipient { get; set; }
    }

    public class FacebookWebHook
    {
        public string @object { get; set; }
        public List<Entry> entry { get; set; }
    }


    public class BroadCastMessage
    {
        public int Type { get; set; }
        public bool All { get; set; }
        public List<string> SendersId { get; set; }
        public short PortalId { get; set; }
    }

    public class WebHookMessage
    {
        public int UserId { get; set; }
        public string SenderId { get; set; }
        public short PortalId { get; set; }
        public int CandidateId { get; set; }
    }
}
