using Notification.Shared.Utilities.Results.Abstract;
using Notification.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data, int statusCode)
        {
            ResultStatus = resultStatus;
            Data = data;
            StatusCode = statusCode;
        }
        public DataResult(ResultStatus resultStatus, T data, int statusCode, string message)
        {
            ResultStatus = resultStatus;
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }

        public DataResult(ResultStatus resultStatus, T data, int statusCode, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            StatusCode = statusCode;
            Message = message;
            Exception = exception;
        }

        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public int StatusCode { get; }

        public Exception Exception { get; }
    }
}
