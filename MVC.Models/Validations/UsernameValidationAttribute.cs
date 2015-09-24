// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckUsernameAttribute.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.Validations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    /// <summary>The check username attribute.</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UsernameValidationAttribute : ValidationAttribute
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="UsernameValidationAttribute"/> class.</summary>
        public UsernameValidationAttribute()
            : base("Usernames can only contain alphanumeric characters (A-Z, 0-9) or underscore (\"_\").")
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The is valid.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool IsValid(object value)
        {
            var strIn = (string)value;
            if (strIn.Equals("administrator", StringComparison.OrdinalIgnoreCase))
            {
                this.ErrorMessage = "Invalid username. Usernames cannot be a reserved word.";
                return false;
            }

            return !Regex.IsMatch(strIn, @"[\W]");
        }

        #endregion
    }
}