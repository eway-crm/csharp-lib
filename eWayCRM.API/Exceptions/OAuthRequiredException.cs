using System;

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
    }
}
