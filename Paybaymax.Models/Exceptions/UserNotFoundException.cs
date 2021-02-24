using System;
using System.Collections.Generic;
using System.Text;

namespace Paybaymax.Models.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException(string message = "") : base(message)
        {
            this.ExceptionCode = ExceptionCode.UserNotFound;
        }
    }
}
