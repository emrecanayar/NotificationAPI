using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.PushAPI.CommandMessage
{
    public class PushCommandMessage
    {

        public string NotificationTypes { get; set; }
        public string Message { get; set; }

        public string UserId { get; set; }

    }
}
