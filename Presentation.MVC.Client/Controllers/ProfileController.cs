// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>The profile controller.</summary>
    [Authorize]
    public partial class ProfileController : BaseController
    {
        #region Fields

        /// <summary>The friend service.</summary>
        private readonly IFriendMvcService friendService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfileController" /> class.
        /// </summary>
        public ProfileController()
            : this(new ProfileMvcService(), new FriendMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ProfileController"/> class.</summary>
        /// <param name="profileService">The profile service.</param>
        /// <param name="friendService">The friend Service.</param>
        public ProfileController(IProfileMvcService profileService, IFriendMvcService friendService)
            : base(profileService)
        {
            this.friendService = friendService;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The counter.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Counter(string id)
        {
            ProfileCounterModel model = this.ProfileService.GetProfileCounterModel(this.User.Identity.Name);
            return this.PartialView(MVCT.Profile.Views._Counter, model);
        }

        /// <summary>The friends.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Friends(string username)
        {
            FriendsModel model = this.friendService.FindFriends(username, string.Empty, 0, 100);
            return this.PartialView(MVCT.Friend.Views._Friends, model);
        }

        /// <summary>The friends.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Friends()
        {
            string text = this.Request.Form["text"];
            string username = this.Request.Form["UserName"];
            FriendsModel model = this.friendService.FindFriends(username, text, 0, 100);
            return this.PartialView(MVCT.Friend.Views._Friends, model);
        }

        /// <summary>The index.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Index(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = this.User.Identity.Name;
            }

            bool touch = !username.Equals(this.User.Identity.Name);
            ProfilePageModel pageModel = this.ProfileService.GetProfileModel(username, touch);
            return View(pageModel);
        }

        /// <summary>The medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Medias(string username)
        {
            MediasModel model = this.ProfileService.GetMedias(username);
            return this.PartialView(MVCT.Media.Views._Medias, model);
        }

        /// <summary>The picture.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Picture(string username)
        {
            byte[] imageData = this.ProfileService.GetProfilePicture(username);
            return this.File(imageData, "image/jpg");
        }

        /// <summary>The posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Posts(string username)
        {
            PostsModel model = this.ProfileService.GetPosts(username);
            return this.PartialView(MVCT.Post.Views._Posts, model);
        }

        /// <summary>The stats.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Stats(string username)
        {
            ProfileStatsModel[] model = this.ProfileService.GetProfileStatsModel(this.User.Identity.Name);
            return View(model);
        }

        /// <summary>The suggest.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Suggest(string username)
        {
            var model = this.ProfileService.SuggestFriends(this.User.Identity.Name);
            return this.View(MVCT.Profile.Views.Suggest, model);
        }

        #endregion
    }
}