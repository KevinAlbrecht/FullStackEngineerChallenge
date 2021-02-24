using System;
using System.Collections.Generic;
using System.Text;

namespace Paybaymax.Models.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message = "") : base(message) { }
        public ExceptionCode ExceptionCode { get; set; }
    }
}
