using Microsoft.AspNetCore.Http;

namespace Notification.PushAPI.Dtos
{
    public class PushDto
    {
        public string NotificationTypes { get; set; }
        public string Message { get; set; }

        public string UserId { get; set; } 
        public IFormCollection Cls { get; set; } 
         
    }
}
