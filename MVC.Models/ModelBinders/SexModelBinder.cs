// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BirthdayModelBinder.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Resources;

    /// <summary>
    /// The birthday model binder.
    /// </summary>
    public class SexModelBinder : DefaultModelBinder
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
            var sexVal = ModelBinderHelper.GetValue(bindingContext, "Sex").AttemptedValue;
            Sex sex;
            if (!Enum.TryParse(sexVal, out sex))
            {
                bindingContext.ModelState.AddModelError("Sex", Messages.SexModelBinder_BindModel_The_sex_is_invalid_);
            }

            return sex;
        }

        #endregion
    }
}