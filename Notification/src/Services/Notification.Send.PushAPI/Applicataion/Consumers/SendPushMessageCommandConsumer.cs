using MassTransit;
using Microsoft.Extensions.Configuration;
using Notification.Send.PushAPI.Applicataion.Abstract;
using Notification.Shared.CommandMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Notification.Send.PushAPI.Applicataion.Consumers
{
    public class SendPushMessageCommandConsumer : IConsumer<SendPushMessageCommand>
    {

        private readonly INotificationPublisherService _notificationPublisherService;

        public SendPushMessageCommandConsumer(INotificationPublisherService notificationPublisherService)
        {
            _notificationPublisherService = notificationPublisherService;
        }



        public  async Task Consume(ConsumeContext<SendPushMessageCommand> context)
        {

            SKNotificationRequestDto notifi = new SKNotificationRequestDto();
            notifi.Notifications = context.Message.Notifications;
            notifi.TenantId = context.Message.TenantId;
            notifi.UserId = context.Message.UserId;


            await _notificationPublisherService.SendNotificationAsync(notifi);


        }
    }



}
