using Notification.Shared.Utilities.Results.Abstract;
using Notification.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus, int statusCode)
        {
            ResultStatus = resultStatus;
            StatusCode = statusCode;
        }
        public Result(ResultStatus resultStatus, int statusCode, string message)
        {
            ResultStatus = resultStatus;
            StatusCode = statusCode;
            Message = message;
        }
        public Result(ResultStatus resultStatus, int statusCode, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            StatusCode = statusCode;
            Message = message;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public int StatusCode { get; }

        public Exception Exception { get; }
    }
}
