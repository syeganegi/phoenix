// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The base controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;
    using Phoenix.PhoenixApp.Presentation.MVC.Client.Filters;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>The base controller.</summary>
    /// 

    [InitializeSimpleMembership]
    [HandleError]
    public abstract partial class BaseController : Controller
    {
        #region Fields

        /// <summary>The profile service.</summary>
        private readonly IProfileMvcService profileService;

        /// <summary>The current profile.</summary>
        private ProfilePrincipal currentProfile;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        protected BaseController()
            : this(new ProfileMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BaseController"/> class.</summary>
        /// <param name="profileService">The profile service.</param>
        protected BaseController(IProfileMvcService profileService)
        {
            this.profileService = profileService;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the current profile.</summary>
        public ProfilePrincipal CurrentProfile
        {
            get
            {
                return Cache.Run(
                    () => this.ProfileService.GetProfilePrincipal(this.User.Identity.Name), 60, this.User.Identity.Name);
            }
        }

        /// <summary>The profile service.</summary>
        public IProfileMvcService ProfileService
        {
            get
            {
                return this.profileService;
            }
        }

        #endregion
    }
}