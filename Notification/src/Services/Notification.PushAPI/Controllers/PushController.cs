using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notification.PushAPI.CommandMessage;
using Notification.PushAPI.Dtos;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.PushAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PushController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public PushController(IMapper mapper, ISendEndpointProvider sendEndpointProvider)
        {
            _mapper = mapper;
            _sendEndpointProvider = sendEndpointProvider;

        }

        [HttpPost]
        [Route("/api/v1/[controller]/[action]")]
        public  async Task<IActionResult> PushNotification(PushDto pushDto)
        {

            var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:send-push-service"));
            var pushCommandMessage = _mapper.Map<PushCommandMessage>(pushDto);
            await sendEndPoint.Send<PushCommandMessage>(pushCommandMessage);
            return Ok();

        }





    }
}
