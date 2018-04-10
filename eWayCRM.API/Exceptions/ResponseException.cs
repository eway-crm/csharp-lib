using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the API service does not respond correctly (return code was not "rcSuccess").
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ResponseException : Exception
    {
        private readonly string returnCode;
        private readonly string methodName;

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
                return returnCode;
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
                return methodName;
            }
        }

        internal ResponseException(string methodName, string returnCode, string message)
            : base(message)
        {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException(nameof(methodName));

            if (string.IsNullOrEmpty(returnCode))
                throw new ArgumentNullException(nameof(returnCode));

            this.returnCode = returnCode;
            this.methodName = methodName;
        }
    }
}
