// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbEntityValidationExceptionExtensionMethods.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.Seedwork
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    /// <summary>The db entity validation exception extension methods.</summary>
    public static class DbEntityValidationExceptionExtensionMethods
    {
        #region Public Methods and Operators

        /// <summary>The get validation errors.</summary>
        /// <param name="exception">The exception.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static IEnumerable<string> GetValidationErrors(this DbEntityValidationException exception)
        {
            var list = new List<string>();
            if (exception == null)
            {
                return list;
            }

            if (exception.EntityValidationErrors == null)
            {
                return list;
            }

            foreach (
                DbValidationError validationError in
                    exception.EntityValidationErrors.Where(error => error.ValidationErrors != null)
                             .SelectMany(error => error.ValidationErrors))
            {
                list.Add(validationError.ErrorMessage);
            }

            return list;
        }

        #endregion
    }
}