using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int NewID { get; set; }

        public static OperationResult Ok(string message = "تمت العملية بنجاح", int newID = 0) => new OperationResult
        {
            Success = true,
            Message = message,
            NewID = newID
        };

        public static OperationResult Fail(string message) => new OperationResult { Success = false, Message = message };

    }

    public class OperationResult<T> : OperationResult { 
        public T Data { get; set; }

        public static OperationResult<T> Ok ( T data, string message = "تمت العملية بنجاح") 
            => new OperationResult<T> { Success = true, Message = message, Data = data};

        public static OperationResult<T> Fail(string message)
            => new OperationResult<T> { Success = false, Message = message };
    }
}
