// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Extensions
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;

    /// <summary>
    ///     The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        #region Public Methods and Operators

        /// <summary>The clean input.</summary>
        /// <param name="strIn">The str in.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CleanInput(this string strIn)
        {
            if (string.IsNullOrEmpty(strIn))
            {
                return string.Empty;
            }

            // Replace invalid characters with empty strings. 
            try
            {
                return Regex.Replace(strIn, @"[^\w]", string.Empty, RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters,  
            // we should return Empty. 
            catch (RegexMatchTimeoutException)
            {
                return string.Empty;
            }
        }

        /// <summary>To the birthday.</summary>
        /// <param name="str">The STR.</param>
        /// <returns>The <see cref="Birthday"/>.</returns>
        public static Birthday ToBirthday(this string str)
        {
            DateTime dateTime;
            var cultureInfo = new CultureInfo("en-US");
            if (!DateTime.TryParseExact(str, "MM/dd/yyyy", cultureInfo, DateTimeStyles.None, out dateTime))
            {
                dateTime = DateTime.MinValue;
            }

            return new Birthday(dateTime);
        }

        /// <summary>To the sex.</summary>
        /// <param name="str">The STR.</param>
        /// <returns>The <see cref="Sex"/>.</returns>
        public static Sex ToSex(this string str)
        {
            Sex sex;

            if (!Enum.TryParse(str, true, out sex))
            {
                sex = Sex.Unknown;
            }

            return sex;
        }

        #endregion
    }
}