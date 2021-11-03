using SKNotify.Models;

namespace Notification.Shared.CommandMessages
{ 
    public class SendPushMessageCommand
    {
        public SKNotify.Models.Notification notification { get; set; }
        public Data data { get; set; }
        public Android android { get; set; }
        public Apns apns { get; set; }

    }
}
