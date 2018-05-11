using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API.Exceptions
{
    /// <summary>
    /// Thrown when the library was unable to determine th client machine unique identifier automatically.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ClientMachineIdentifierDeterminationException : Exception
    {
        public ClientMachineIdentifierDeterminationException(string message)
            : base(message)
        { }
    }
}
