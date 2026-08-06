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
        [NonSerialized]
        private ExceptionState state;

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
                return state.ReturnCode;
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
                return state.MethodName;
            }
        }

        internal ResponseException(string methodName, string returnCode, string message)
            : base(message)
        {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException(nameof(methodName));

            if (string.IsNullOrEmpty(returnCode))
                throw new ArgumentNullException(nameof(returnCode));

            state.MethodName = methodName;
            state.ReturnCode = returnCode;
            SerializeObjectState += (sender, e) => e.AddSerializedState(state);
        }

        // No (SerializationInfo, StreamingContext) constructor — the SafeSerialization
        // mechanism restores state via ExceptionState.CompleteDeserialization. Adding one
        // introduces the "Stack empty" InvalidOperationException.

        [Serializable]
        private struct ExceptionState : ISafeSerializationData
        {
            public string ReturnCode;
            public string MethodName;

            public void CompleteDeserialization(object obj)
            {
                var ex = (ResponseException)obj;
                ex.state = this;
                ex.SerializeObjectState += (sender, e) => e.AddSerializedState(ex.state);
            }
        }
    }
}
