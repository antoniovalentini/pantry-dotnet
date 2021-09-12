using System;

namespace Pantry.Core
{
    /// <summary>
    /// Class that wraps generic extensions.
    /// </summary>
    public static class GeneralExtensions
    {
        /// <summary>
        ///  Shorthand extension to check whether a string is null or whitespace/empty.
        /// </summary>
        /// <param name="str">The string that needs to be checked.</param>
        /// <exception cref="ArgumentNullException">Raised when the checked argument is null or whitespace/empty.</exception>
        public static void ThrowIfNullOrWhiteSpace(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(nameof(str));
        }
    }
}
