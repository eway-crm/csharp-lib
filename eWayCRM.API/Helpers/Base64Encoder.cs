using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWay.Core.Helpers
{
    public static class Base64Encoder
    {
        /// <summary>
        /// Encodes text using Base64.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="unicode">If set to <c>true</c> UTF-8 otherwise ASCII encoding is used.</param>
        /// <returns></returns>
        public static string Encode(string text, bool unicode = false)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            byte[] data = unicode ? UTF8Encoding.UTF8.GetBytes(text) : ASCIIEncoding.ASCII.GetBytes(text);

            // Encode using Base64
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Decodes text encoded by Base64.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="unicode">If set to <c>true</c> UTF-8 otherwise ASCII encoding is used.</param>
        /// <returns></returns>
        public static string Decode(string text, bool unicode = false)
        {
            byte[] data = Convert.FromBase64String(text);

            // Decode Base64 string
            return unicode ? UTF8Encoding.UTF8.GetString(data) : ASCIIEncoding.ASCII.GetString(data);
        }
    }
}
