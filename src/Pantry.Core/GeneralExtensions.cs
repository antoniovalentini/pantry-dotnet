using System;

namespace Pantry.Core
{
    public static class GeneralExtensions
    {
        public static void ThrowIfNullOrWhiteSpace(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(nameof(str));
        }
    }
}
