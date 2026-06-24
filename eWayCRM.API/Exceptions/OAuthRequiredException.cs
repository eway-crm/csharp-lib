using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Exception raised when rcOAuthRequired is returned during Login.
    /// </summary>
    [Serializable]
    public class OAuthRequiredException : LoginException
    {
        internal OAuthRequiredException(string returnCode, string message)
            : base(returnCode, message) { }

        protected OAuthRequiredException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
