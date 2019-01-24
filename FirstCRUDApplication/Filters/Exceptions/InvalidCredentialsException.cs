using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Filters.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string message)
        : base(message)
        {
        }

        public InvalidCredentialsException(string message,Exception inner)
        : base(message, inner)
        {
        }
    }
}
