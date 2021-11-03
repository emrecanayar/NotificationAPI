using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Send.PushAPI.PushNotification
{
    public class PushNotificationAppService : IPushNotificationAppService
    {
        public IConfiguration Configuration { get; }
        private ILogger<PushNotificationAppService> _logger;
        public PushNotificationAppService(IConfiguration configuration, ILogger<PushNotificationAppService> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }


        public static async Task<bool> NotifyAsync(string to, string title, string body)
        {
            var serverKey = string.Format("key={0}", "AAAAtFDkqU8:APA91bHnT1_jqT_uTT67vcT0wWylRYJ0oDyKYY8IOJ247hI69tzEQa6IW32hTJTaPCs_RBomL_gjxykG580CRsGVQMeJ0YA644uiUgRjUgAZ5hJe4iFgFPxmhwz1AyDgibCdCiMqBNf3");
            var senderId = string.Format("id={0}", "774451276111");

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


        public async Task<bool> SendNotification(string to, string title, string body)
        {
            var content = new
            {
                notification = new
                {
                    title = "IK Norm Bildirim",
                    body = "Admin Panel Üzerinden Bildirim Gönderildi"
                },
                data = new
                {
                    msgType = "NormInsert",
                    normId = 23
                },
                android = new
                {
                    notification = new
                    {
                        sound = "default"
                    }
                },
                apns = new
                {
                    payload = new
                    {
                        aps = new
                        {
                            sound = "default"
                        }
                    }
                },
            };


            var result = await NotifyAsync("fdloyZpAQbmObB7MZI3oaw:APA91bGn_ZIXo0lHuIw2JmgzXGKCh_ZcxAZliTvNyrRIDkwT9uFioiFQ6ofrNI3pvl2uVupZyUVl9YbEB2cZ7qSSEl9Csx1x1jbjarn_njaiI-NC2FSW22JTMDQrPmqveWE2HzRgkwPy",
                  "Norm Ekleme Bildirimi", JsonConvert.SerializeObject(content));

            return result;
        }
    }

}
