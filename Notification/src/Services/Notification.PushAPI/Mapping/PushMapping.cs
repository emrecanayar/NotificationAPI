using AutoMapper;
using Notification.PushAPI.CommandMessage;
using Notification.PushAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.PushAPI.Mapping
{
    public class PushMapping :Profile
    {


       public PushMapping()
        {


            CreateMap<PushDto, PushCommandMessage>().ReverseMap();

        }



    }
}
