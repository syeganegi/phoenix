// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensionMethods.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.Seedwork
{
    using System.Collections.Generic;

    /// <summary>The string extension methods.</summary>
    public static class StringExtensionMethods
    {
        #region Public Methods and Operators

        /// <summary>The to enumerable.</summary>
        /// <param name="str">The str.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public static IEnumerable<string> ToEnumerable(this string str)
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(str))
            {
                return list;
            }

            list.Add(str);
            return list;
        }

        #endregion
    }
}