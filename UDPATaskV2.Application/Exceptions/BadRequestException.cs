using System;
using System.Collections.Generic;
using System.Text;

namespace UDPATaskV2.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
