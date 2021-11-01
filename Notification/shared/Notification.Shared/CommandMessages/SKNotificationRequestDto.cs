using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Shared.CommandMessages
{
    public class SKNotificationRequestDto
    {

        public List<BaseSKNotificationRequestDto> Notifications { get; set; }

        public string TenantId { get; set; }

        public string UserId { get; set; }


    }
}
