namespace SKNotify.Models
{
    public class SendPushMessageCommandDto
    {
        public Notification notification { get; set; }
        public Data data { get; set; }
        public Android android { get; set; }
        public Apns apns { get; set; }
    }

}
