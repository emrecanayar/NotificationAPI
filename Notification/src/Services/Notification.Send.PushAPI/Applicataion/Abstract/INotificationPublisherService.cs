using Notification.Shared.CommandMessages;
using System.Threading.Tasks;

namespace Notification.Send.PushAPI.Applicataion.Abstract
{
    public interface INotificationPublisherService
    {
        Task<bool> SendNotification(SendPushMessageCommand message);
    }
}
