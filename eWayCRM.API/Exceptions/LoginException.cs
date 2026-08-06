using System;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the login method is not successful.
    /// </summary>
    /// <seealso cref="eWayCRM.API.Exceptions.ResponseException" />
    [Serializable]
    public class LoginException : ResponseException
    {
        internal LoginException(string returnCode, string message)
            : base("LogIn", returnCode, message) { }
    }
}
