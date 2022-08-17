using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs.Base
{
    public class ResultMessage
    {
        public int ResultCode { get; set; }
        public bool IsSuccess { get; set; }
        public string MessageKey { get; set; }
        public Exception Exception { get; set; }
    }

    public class ResultMessage<T> where T : class
    {
        public int ResultCode { get; set; }
        public bool IsSuccess { get; set; }
        public string MessageKey { get; set; }
        public T Data { get; set; }
        public Exception Exception { get; set; }
    }
}
