using System;
using System.Collections.Generic;
using System.Text;

namespace strivolabs_Assessment.Exceptions
{
    public class ApiGenericException : Exception
    { 
        public string ErrorCode { get; set; }

        public ApiGenericException(string message) : base(message)
        { 
        //logExcp
        }

        public ApiGenericException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
