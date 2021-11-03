using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Notification.Send.PushAPI.Applicataion.Abstract;
using Notification.Shared.CommandMessages;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Send.PushAPI.Applicataion.Concrete
{
    public class NotificationPublisherService : INotificationPublisherService
    {
        private IConfiguration Configuration { get; }
        private ILogger<NotificationPublisherService> _logger;
        public NotificationPublisherService(IConfiguration configuration, ILogger<NotificationPublisherService> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> NotifyAsync(string to, string title, string body)
        {
            var fireCnf = Configuration.GetSection("FireBase");


            var serverKey = string.Format("key={0}", fireCnf["ServerKey"]);
            var senderId = string.Format("id={0}", fireCnf["SenderId"]);

            var data = new
            {
                to,
                notification = new { title, body }
            };

            var jsonBody = JsonConvert.SerializeObject(data);

            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
            {
                httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.SendAsync(httpRequest);

                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
         

        public async Task<bool> SendNotification(SendPushMessageCommand message)
        { 
            if (string.IsNullOrWhiteSpace(message.notification.token))
            {
                return false;
            } 

            var result = await NotifyAsync(message.notification.token, "Norm Bildirimi", JsonConvert.SerializeObject(message));

            return result;
        }
    }
}
