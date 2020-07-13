using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API.EventArgs
{
    /// <summary>
    /// Access token EventArgs.
    /// </summary>
    public class AccessTokenEventArgs : System.EventArgs
    {
        /// <summary>
        /// Gets or sets the AccessToken.
        /// </summary>
        public string AccessToken { get; set; }
    }
}
