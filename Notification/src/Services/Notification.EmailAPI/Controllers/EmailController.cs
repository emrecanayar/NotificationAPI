using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Notification.Shared.CommandMessages;
using Notification.Shared.ControllerBases;
using Notification.Shared.Dtos;
using RabbitMQ.Client;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Notification.EmailAPI.Controllers
{
    [ApiController]
    public class EmailController : CustomBaseController
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IMapper _mapper;
        public EmailController(ISendEndpointProvider sendEndpointProvider, IMapper mapper)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/[controller]/[action]")]
        [ProducesResponseType(typeof(EmailSendDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Send(EmailSendDto emailSendDto)
        {
            var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:send-email-service"));
            var sendSMSMessageCommand = _mapper.Map<SendEmailMessageCommand>(emailSendDto);
            await sendEndPoint.Send<SendEmailMessageCommand>(sendSMSMessageCommand);
            return Ok();
        }
    }
}
