using AutoMapper;
using Notification.Shared.CommandMessages;
using Notification.Shared.Dtos;

namespace Notification.SendEmailAPI.Mapping
{
    public class EmailMapping : Profile
    {
        public EmailMapping()
        {
            CreateMap<EmailSendDto, SendEmailMessageCommand>().ReverseMap();
        }
    }
}
