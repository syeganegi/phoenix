// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelStateExtensions.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Extensions
{
    using System.Web.Mvc;

    /// <summary>The model state extensions.</summary>
    public static class ModelStateExtensions
    {
        #region Public Methods and Operators

        /// <summary>The add range model error.</summary>
        /// <param name="modelState">The model state.</param>
        /// <param name="errors">The errors.</param>
        public static void AddRangeModelError(this ModelStateDictionary modelState, string[] errors)
        {
            if (errors == null)
            {
                return;
            }

            foreach (var error in errors)
            {
                modelState.AddModelError(string.Empty, error);
            }
        }

        #endregion
    }
}