using Notification.Shared.CommandMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Send.PushAPI.Applicataion.Abstract
{
    public interface INotificationPublisherService
    {

        Task SendNotificationAsync(SKNotificationRequestDto notification);



    }
}
