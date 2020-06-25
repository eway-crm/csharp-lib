using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the login method is not successful.
    /// </summary>
    /// <seealso cref="eWayCRM.API.Exceptions.ResponseException" />
    public class LoginException : ResponseException
    {
        internal LoginException(string returnCode, string message)
            : base("LogIn", returnCode, message) { }
    }
}
