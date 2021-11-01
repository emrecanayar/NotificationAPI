using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Shared.CommandMessages
{
    public class SKUserRequestDto
    {
        public string Language { get; set; }



        public Application Application { get; set; }



     
    }
    public enum Application
    {
        Operasyon,
        IK
    }
}
