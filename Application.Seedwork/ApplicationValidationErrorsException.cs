// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationValidationErrorsException.cs" company="">
//   
// </copyright>
// <summary>
//   The custom exception for validation errors
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.Seedwork
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using Phoenix.PhoenixApp.Application.Seedwork.Resources;

    /// <summary>
    /// The custom exception for validation errors
    /// </summary>
    public class ApplicationValidationErrorsException : Exception
    {
        #region Fields

        /// <summary>
        /// The _validation errors.
        /// </summary>
        private readonly IEnumerable<string> _validationErrors;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationValidationErrorsException"/> class. 
        /// Create new instance of Application validation errors exception
        /// </summary>
        /// <param name="validationErrors">
        /// The collection of validation errors
        /// </param>
        public ApplicationValidationErrorsException(IEnumerable<string> validationErrors)
            : base(Messages.exception_ApplicationValidationExceptionDefaultMessage)
        {
            this._validationErrors = validationErrors;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get or set the validation errors messages
        /// </summary>
        public IEnumerable<string> ValidationErrors
        {
            get
            {
                return this._validationErrors;
            }
        }

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <returns>The errors.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string GetValidationErrors()
        {
            if (this._validationErrors == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            foreach (var validationError in _validationErrors)
            {
                sb.Append(validationError);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        #endregion
    }
}