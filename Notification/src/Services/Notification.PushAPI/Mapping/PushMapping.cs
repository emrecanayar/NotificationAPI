using AutoMapper;
using Notification.Shared.CommandMessages;
using SKNotify.Models;

namespace Notification.PushAPI.Mapping
{
    public class PushMapping :Profile
    {


       public PushMapping()
        {


            CreateMap<SendPushMessageCommandDto, SendPushMessageCommand>().ReverseMap();

        }



    }
}
