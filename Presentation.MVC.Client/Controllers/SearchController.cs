// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>The profile controller.</summary>
    [Authorize]
    public partial class SearchController : BaseController
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchController" /> class.
        ///     Initializes a new instance of the <see cref="ProfileController" /> class.
        /// </summary>
        public SearchController()
            : this(new ProfileMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SearchController"/> class. Initializes a new instance of the<see cref="ProfileController"/>
        ///     class.</summary>
        /// <param name="profileService">The profile service.</param>
        public SearchController(IProfileMvcService profileService)
            : base(profileService)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The index.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [HttpPost]
        public virtual ActionResult Index()
        {
            ProfileSearchResultModel model = null;
            try
            {
                string searchinput = this.Request.Form["searchinput"];
                model = this.ProfileService.FindProfiles(searchinput);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, e.Message);
            }

            return this.View(model);
        }

        /// <summary>The lookup.</summary>
        /// <param name="term">The term.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Lookup(string term)
        {
            ProfileSearchResultModel list = this.ProfileService.FindProfiles(term);
            var data = from s in list.SearchResults
                       select
                           new
                               {
                                   label = s.ProfileFullName, 
                                   value = s.ProfileFullName, 
                                   profile = this.Url.Action(MVCT.Profile.Index(s.ProfileUserName)), 
                                   picture = this.Url.Action(MVCT.Profile.Picture(s.ProfileUserName)), 
                                   sport = s.ProfileSport
                               };
            return this.Json(data);
        }

        #endregion
    }
}