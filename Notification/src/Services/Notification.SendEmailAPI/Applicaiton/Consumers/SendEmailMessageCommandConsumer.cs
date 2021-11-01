using MassTransit;
using Notification.SendEmailAPI.Applicaiton.Abstract;
using Notification.Shared.CommandMessages;
using Notification.Shared.Dtos;
using System.Threading.Tasks;

namespace Notification.SendEmailAPI.Applicaiton.Consumers
{
    public class SendEmailMessageCommandConsumer : IConsumer<SendEmailMessageCommand>
    {
        private readonly IMailService _mailService;

        public SendEmailMessageCommandConsumer(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task Consume(ConsumeContext<SendEmailMessageCommand> context)
        {
            EmailSendDto emailSendDto = new EmailSendDto();
            emailSendDto.Name = context.Message.Name;
            emailSendDto.Subject = context.Message.Subject;
            emailSendDto.Email = context.Message.Email;
            emailSendDto.Message = context.Message.Message;
            await Task.Run(() => { _mailService.Send(emailSendDto); });
        }
    }
}
