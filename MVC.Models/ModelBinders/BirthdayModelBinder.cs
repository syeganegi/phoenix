// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BirthdayModelBinder.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;

    /// <summary>
    /// The birthday model binder.
    /// </summary>
    public class BirthdayModelBinder : DefaultModelBinder
    {
        #region Public Methods and Operators

        /// <summary>
        /// The bind model.
        /// </summary>
        /// <param name="controllerContext">
        /// The controller context.
        /// </param>
        /// <param name="bindingContext">
        /// The binding context.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int day = ModelBinderHelper.GetValue<int>(bindingContext, "Day").Value;
            int month = ModelBinderHelper.GetValue<int>(bindingContext, "Month").Value;
            int year = ModelBinderHelper.GetValue<int>(bindingContext, "Year").Value;

            Birthday birthday = null;
            try
            {
                birthday = new Birthday(year, month, day);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (birthday == null)
            {
                return new Birthday { Day = day, Month = month, Year = year };
            }

            var validationContext = new ValidationContext(birthday, null, null);
            var validationResults = birthday.Validate(validationContext);
            foreach (var validationResult in validationResults)
            {
                bindingContext.ModelState.AddModelError(
                    validationResult.GetHashCode().ToString(), validationResult.ErrorMessage);
            }

            return birthday;
        }

        #endregion
    }
}