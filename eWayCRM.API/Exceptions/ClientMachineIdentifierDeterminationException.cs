using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Thrown when the library was unable to determine the client machine unique identifier automatically.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ClientMachineIdentifierDeterminationException : Exception
    {
        public ClientMachineIdentifierDeterminationException(string message)
            : base(message)
        { }

        protected ClientMachineIdentifierDeterminationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
