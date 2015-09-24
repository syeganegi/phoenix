// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common
{
    using System;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Resources;

    /// <summary>The guard.</summary>
    public static class Guard
    {
        #region Public Methods and Operators

        /// <summary>The argument is not null.</summary>
        /// <param name="value">The value.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ArgumentIsNotNull(object value, string argument)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argument);
            }
        }

        /// <summary>The argument is not null or empty.</summary>
        /// <param name="value">The value.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ArgumentIsNotNullOrEmpty(string value, string argument)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(argument);
            }
        }

        #endregion

        public static void ArgumentIsEmpty(Guid value, string argument)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException(Messages.exception_Guard_ArgumentIsEmpty_Invalid_or_empty_argument, argument);
            }
        }
    }
}