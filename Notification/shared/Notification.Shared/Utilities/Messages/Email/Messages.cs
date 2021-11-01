using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Shared.Utilities.Messages.Email
{
    public static class Messages
    {
        public static string Success()
        {
            return "E-Postanız başarıyla gönderilmiştir";
        }

        public static string Error()
        {
            return "E-Postanız gönderilirken bir hata meydana gelmiştir.";
        }
    }
}
