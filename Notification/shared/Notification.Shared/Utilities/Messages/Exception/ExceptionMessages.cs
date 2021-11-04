using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Shared.Utilities.Messages.Exception
{
    public class ExceptionMessages
    {
        public static string SqlNullValueExceptionMessage()
        {
            return "Üzgünüz, işleminiz sırasında beklenmedik bir veri tabanaı hatası oluştu. Sorunu en kısa sürede çözeceğiz.";
        }

        public static string NullReferenceExceptionMessage()
        {
            return "Üzgünüz, işleminiz sırasında beklenmedik bir null veriye rastlandı. Sorunu en kısa sürede çözeceğiz.";
        }

        public static string DefaultExceptionMessage()
        {
            return "Üzgünüz, işleminiz sırasında beklenmedik bir hata oluştu. Sorunu en kısa sürede çözeceğiz.";
        }
    }
}
