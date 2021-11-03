using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Shared.CommandMessages
{
    public class SKNotificationRequestDto
    {
        public string NotificationTypes { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }


    }
}
