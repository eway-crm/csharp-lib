using System;
using System.Runtime.Serialization;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the API service does not respond correctly (return code was not "rcSuccess").
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ResponseException : Exception
    {
        /// <summary>
        /// Gets the return code.
        /// </summary>
        /// <value>
        /// The response return code.
        /// </value>
        public string ReturnCode
        {
            get
            {
                return (string)Data[nameof(ReturnCode)];
            }
        }

        /// <summary>
        /// Gets the method name.
        /// </summary>
        /// <value>
        /// Name of the method that responded incorrectly.
        /// </value>
        public string MethodName
        {
            get
            {
                return (string)Data[nameof(MethodName)];
            }
        }

        internal ResponseException(string methodName, string returnCode, string message)
            : base(message)
        {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException(nameof(methodName));

            if (string.IsNullOrEmpty(returnCode))
                throw new ArgumentNullException(nameof(returnCode));

            Data[nameof(ReturnCode)] = returnCode;
            Data[nameof(MethodName)] = methodName;
        }

        protected ResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }   // Data is restored by the base class
    }
}