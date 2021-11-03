
using System.Threading.Tasks;

namespace Notification.Send.PushAPI.PushNotification
{
    public interface IPushNotificationAppService
    {
        Task<bool> SendNotification(string to, string title, string body);
    }

}
