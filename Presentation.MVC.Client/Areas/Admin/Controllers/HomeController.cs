// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Areas.Admin.Controllers
{
    using System;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers;
    using Phoenix.PhoenixApp.Presentation.MVC.Client.Filters;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>
    ///     The home controller.
    /// </summary>
    [Authorize(Roles = "Administrator")]
    public partial class HomeController : BaseController
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="HomeController"/> class.</summary>
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

        // GET: /Admin/Home/
        #region Public Methods and Operators

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Delete(string id)
        {
            ProfileAdminModel model = this.ProfileService.GetProfileAdmin(id);
            return View(model);
        }

        /// <summary>The delete confirmed.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(string id)
        {
            var resultOk = false;
            try
            {
                var username = Request.Form["UserName"];
                this.ProfileService.DeleteProfileAdmin(username, User.Identity.Name);
                resultOk = true;
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }

            if (resultOk)
            {
                return this.RedirectToAction(MVCT.Admin.Home.Index());
            }

            var model = this.ProfileService.GetProfileAdmin(id);
            return this.View(model);
        }

        /// <summary>The edit.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Edit(string id)
        {
            ProfileAdminModel model = this.ProfileService.GetProfileAdmin(id);
            return View(model);
        }

        /// <summary>The edit.</summary>
        /// <param name="adminModel">The admin model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Edit(ProfileAdminModel model)
        {
            var resultOk = false;

            if (ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateProfileAdmin(model);
                    resultOk = true;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }

                if (resultOk)
                {
                    return this.RedirectToAction(MVCT.Admin.Home.Index());
                }
            }

            return this.View(model);
        }

        /// <summary>
        ///     The index.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult Index()
        {
            ProfileListAdminModel model = this.ProfileService.GetProfileListAdmin();
            return this.View(model);
        }

        #endregion
    }
}