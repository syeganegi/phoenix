// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The post controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>The post controller.</summary>
    public partial class PostController : BaseController
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="PostController"/> class.</summary>
        public PostController()
            : this(new ProfileMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PostController"/> class. Initializes a new instance of the <see cref="ProfileController"/> class.</summary>
        /// <param name="profileService">The profile service.</param>
        public PostController(IProfileMvcService profileService)
            : base(profileService)
        {
        }

        #endregion

        // POST: /Post/Create
        #region Public Methods and Operators

        /// <summary>The create.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        /// <exception cref="ModelStateException"></exception>
        [HttpPost]
        [HandleModelStateException]
        public virtual ActionResult Create(PostModel model)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ModelStateException(this.ModelState);
            }

            model.ProfileId = this.CurrentProfile.Id;
            model = this.ProfileService.AddNewPost(model);

            return this.PartialView(MVCT.Post.Views._Post, model);
        }

        // POST: /Post/Delete/5

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Delete(Guid id)
        {
            this.ProfileService.DeletePost(id);
            return this.RedirectToAction(MVCT.Post.Posts(this.CurrentProfile.UserName));
        }

        /// <summary>The posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Posts(string username)
        {
            PostsModel model = this.ProfileService.GetPosts(username);
            return this.PartialView(MVCT.Post.Views._PostsList, model.Posts);
        }

        #endregion
    }
}