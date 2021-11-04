using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using NLog;
using Notification.Shared.Models;
using Notification.Shared.Utilities.Messages.Exception;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Shared.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;

        public ApiExceptionFilter(IHostEnvironment environment)
        {
            _environment = environment;
        }
        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
            {
                var logger = LogManager.GetCurrentClassLogger();
                context.ExceptionHandled = true;
                var apiErrorModel = new ApiErrorModel();
                HttpResponse response = context.HttpContext.Response;
                switch (context.Exception)
                {
                    case SqlNullValueException:
                        apiErrorModel.Message = ExceptionMessages.SqlNullValueExceptionMessage();
                        apiErrorModel.Detail = context.Exception.Message;
                        response.ContentType = "application/json";
                        response.StatusCode = 500;
                        logger.Error(context.Exception, context.Exception.Message);
                        break;
                    case NullReferenceException:
                        apiErrorModel.Message = ExceptionMessages.NullReferenceExceptionMessage();
                        apiErrorModel.Detail = context.Exception.Message;
                        response.ContentType = "application/json";
                        response.StatusCode = 403;
                        logger.Error(context.Exception, context.Exception.Message);
                        break;
                    default:
                        apiErrorModel.Message = ExceptionMessages.DefaultExceptionMessage();
                        response.ContentType = "application/json";
                        response.StatusCode = 500;
                        logger.Error(context.Exception, context.Exception.Message);
                        break;
                }

                context.Result = new ObjectResult(new ApiErrorModel { Message = apiErrorModel.Message, Detail = apiErrorModel.Detail });
            }
        }
    }
}
