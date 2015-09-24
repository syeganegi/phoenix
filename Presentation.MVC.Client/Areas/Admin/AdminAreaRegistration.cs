// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminAreaRegistration.cs" company="">
//   
// </copyright>
// <summary>
//   The admin area registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Areas.Admin
{
    using System.Web.Mvc;

    /// <summary>
    /// The admin area registration.
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration
    {
        #region Public Properties

        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The register area.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default", 
                "Admin/{controller}/{action}/{id}", 
                new { action = "Index", id = UrlParameter.Optional }, 
                new[] { "Phoenix.PhoenixApp.Presentation.MVC.Client.Areas.Admin.Controllers" });
        }

        #endregion
    }
}