using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Exception raised when rcOAuthRequired is returned during Login.
    /// </summary>
    public class OAuthRequiredException : LoginException
    {
        internal OAuthRequiredException(string returnCode, string message)
            : base(returnCode, message) { }
    }
}
