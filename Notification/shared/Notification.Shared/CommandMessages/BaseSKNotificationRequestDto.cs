using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Shared.CommandMessages
{
    public class BaseSKNotificationRequestDto
    {

        public List<string> To { get; set; }
        public List<SKMessageRequestDto> Messages { get; set; }



        public Application Application { get; set; }



        public string Url { get; set; }



        public DateTime SendDate { get; set; }

    }
}
