using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Banking.CurrentAccount.Application.Exceptions
{
    public class CustomApiException : Exception
    {
        public CustomApiException() : base() { }

        public CustomApiException(string message) : base(message) { }

        public CustomApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
