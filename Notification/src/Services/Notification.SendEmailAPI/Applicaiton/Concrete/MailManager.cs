using Microsoft.Extensions.Options;
using Notification.SendEmailAPI.Applicaiton.Abstract;
using Notification.Shared.Dtos;
using Notification.SendEmailAPI.Models;
using Notification.Shared.Utilities.Messages.Email;
using Notification.Shared.Utilities.Results.Abstract;
using Notification.Shared.Utilities.Results.ComplexTypes;
using Notification.Shared.Utilities.Results.Concrete;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Notification.SendEmailAPI.Applicaiton.Concrete
{
    public class MailManager : IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress(emailSendDto.Email) },
                Subject = emailSendDto.Subject,
                IsBodyHtml = true,
                Body = emailSendDto.Message
            };

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;

            };

            try
            {
                smtpClient.Send(message);
                return new Result(ResultStatus.Success, 200, Messages.Success());
            }
            catch (Exception exception)
            {
                return new Result(ResultStatus.Success, 500, Messages.Error(), exception);

            }



        }


    }
}
