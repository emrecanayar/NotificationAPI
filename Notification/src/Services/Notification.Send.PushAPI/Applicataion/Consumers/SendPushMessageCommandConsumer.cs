using MassTransit;
using Notification.Send.PushAPI.Applicataion.Abstract;
using Notification.Shared.CommandMessages;
using System.Threading.Tasks;

namespace Notification.Send.PushAPI.Applicataion.Consumers
{
    public class SendPushMessageCommandConsumer : IConsumer<SendPushMessageCommand>
    {
        private readonly INotificationPublisherService _pushNotificationAppService;

        public SendPushMessageCommandConsumer(INotificationPublisherService pushNotificationAppService = null)
        {
            _pushNotificationAppService = pushNotificationAppService;
        }

        public async Task Consume(ConsumeContext<SendPushMessageCommand> context)
        { 
            await _pushNotificationAppService.SendNotification(context.Message);
        }
    }
}
