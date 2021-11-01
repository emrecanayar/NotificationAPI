using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Shared.CommandMessages
{
    public class SKMessageRequestDto
    {


        public Channel Channel { get; set; }



        //public List<FowLocalizedField> Title { get; set; }

        //public List<FowLocalizedField> Body { get; set; }
        //public List<FowLocalizedField> Attachment { get; set; }




    }

    public enum Channel
    {
        /// <summary>
        /// Push Notification
        /// </summary>
        Push = 1,
        /// <summary>
        /// Email
        /// </summary>
        Email,
        /// <summary>
        /// Sms
        /// </summary>
        Sms,
        /// <summary>
        /// Web Push (Notification)
        /// </summary>
        Web
    }
}
