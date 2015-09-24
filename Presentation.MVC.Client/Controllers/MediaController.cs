// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The media controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Mvc;

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>The media controller.</summary>
  
    public partial class MediaController : BaseController
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MediaController"/> class.</summary>
        public MediaController()
            : this(new ProfileMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MediaController"/> class. Initializes a new instance of the <see cref="ProfileController"/> class.</summary>
        /// <param name="profileService">The profile service.</param>
        public MediaController(IProfileMvcService profileService)
            : base(profileService)
        {
        }

        #endregion

        // POST: /Media/Create
        #region Public Methods and Operators

        /// <summary>The create.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        /// <exception cref="ModelStateException"></exception>
        [HttpPost]
        [HandleModelStateException]
        public virtual ActionResult Create(MediaModel model)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ModelStateException(this.ModelState);
            }

            if (model.Type == "Video")
            {
                model.MediaUrl = model.MediaUrl.Replace("youtu.be", "www.youtube.com/v");
            }

            model.ProfileId = this.CurrentProfile.Id;
            model = this.ProfileService.AddNewMedia(model);

            return this.PartialView(MVCT.Media.Views._Media, model);
        }

        // POST: /Media/Delete/5

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Delete(Guid id)
        {
            this.ProfileService.DeleteMedia(id);
            return this.RedirectToAction(MVCT.Media.Medias(this.CurrentProfile.UserName));
        }

        /// <summary>The medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
    
        public virtual ActionResult Medias(string username)
        {
            MediasModel model = this.ProfileService.GetMedias(username);
            return PartialView(MVCT.Media.Views._MediasList, model.Medias);
        }

        #endregion
    }


}
