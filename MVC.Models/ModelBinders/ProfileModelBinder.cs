// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserNameModelBinder.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;

    /// <summary>The user name model binder.</summary>
    public class ProfileModelBinder : DefaultModelBinder
    {
        #region Methods

        /// <summary>The on model updated.</summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var userProfileBase = bindingContext.Model as ProfileModelBase;
            if (userProfileBase != null)
            {
                userProfileBase.UserName = controllerContext.HttpContext.User.Identity.Name;
            }

            base.OnModelUpdated(controllerContext, bindingContext);
        }

        #endregion
    }
}