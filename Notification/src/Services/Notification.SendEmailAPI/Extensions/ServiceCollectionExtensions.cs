using Microsoft.Extensions.DependencyInjection;
using Notification.SendEmailAPI.Applicaiton.Abstract;
using Notification.SendEmailAPI.Applicaiton.Concrete;

namespace Notification.SendEmailAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {

            serviceCollection.AddSingleton<IMailService, MailManager>();

            return serviceCollection;
        }
    }
}
