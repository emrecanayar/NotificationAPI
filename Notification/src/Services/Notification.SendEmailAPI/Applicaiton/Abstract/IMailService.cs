using Notification.Shared.Dtos;
using Notification.Shared.Utilities.Results.Abstract;

namespace Notification.SendEmailAPI.Applicaiton.Abstract
{
    public interface IMailService
    {
        IResult Send(EmailSendDto emailSendDto);
    }
}
