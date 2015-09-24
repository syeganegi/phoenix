// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>
    ///     The home controller.
    /// </summary>
    [Authorize]
    public partial class HomeController : BaseController
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        public HomeController()
            : this(new ProfileMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="HomeController"/> class.</summary>
        /// <param name="profileService">The profile service.</param>
        public HomeController(IProfileMvcService profileService)
            : base(profileService)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The index.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult Index()
        {
            ProfilePageModel pageModel = this.ProfileService.GetProfileModel(this.User.Identity.Name);
            return View(pageModel);
        }

        #endregion
    }
}