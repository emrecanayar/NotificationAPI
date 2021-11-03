using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Notification.Shared.CommandMessages;
using SKNotify.Models;
using System;
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
        public async Task<IActionResult> Send(SendPushMessageCommandDto root)
        {
            var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:send-push-service"));
            var pushCommandMessage = _mapper.Map<SendPushMessageCommand>(root);
            await sendEndPoint.Send<SendPushMessageCommand>(pushCommandMessage);

            return Ok();
        }
    }
}


