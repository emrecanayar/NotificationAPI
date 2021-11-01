using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Notification.Send.PushAPI.Applicataion.Abstract;
using Notification.Shared.CommandMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Send.PushAPI.Applicataion.Concrete
{
    public class NotificationPublisherService : INotificationPublisherService
    {
        private readonly IConfiguration _configuration;


        public NotificationPublisherService(IConfiguration configuration)
        {

            _configuration = configuration;


        }

        public async Task SendNotificationAsync(SKNotificationRequestDto notification)
        {

            var baseUrl = _configuration.GetValue<string>("FowNotificationServiceBaseUrl");

            string serverKey = _configuration.GetValue<string>("ServerKey");

            using (var client = new HttpClient())

            {

                client.DefaultRequestHeaders.Add("ServerKey", serverKey);

                using (var sContent = new StringContent(JsonConvert.SerializeObject(notification), Encoding.UTF8, "application/json"))

                {

                    using (var response = await client.PostAsync(baseUrl + "/v1/notifications/server", sContent))

                    {

                        var content = await response.Content.ReadAsStringAsync();

                    }

                }

            }

        }
    }
}
