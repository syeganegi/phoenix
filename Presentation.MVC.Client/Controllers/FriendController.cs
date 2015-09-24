// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The friend controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>The friend controller.</summary>
    [Authorize]
    public partial class FriendController : BaseController
    {
        #region Fields

        /// <summary>The friend service.</summary>
        private readonly IFriendMvcService friendService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FriendController" /> class.
        /// </summary>
        public FriendController()
            : this(new ProfileMvcService(), new FriendMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FriendController"/> class.</summary>
        /// <param name="profileService">The profile service.</param>
        /// <param name="friendService">The friend Service.</param>
        public FriendController(IProfileMvcService profileService, IFriendMvcService friendService)
            : base(profileService)
        {
            this.friendService = friendService;
        }

        #endregion

        // GET: /Friend/

        // [HttpPost]
        #region Public Methods and Operators

        /// <summary>The accept.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Accept(string id)
        {
            this.friendService.AcceptFriend(id);
            return this.View();
        }

        /// <summary>The accept user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult AcceptUser(string id)
        {
            this.friendService.AcceptByUsername(id);
            return this.View(MVCT.Friend.Views.Accept);
        }

        /// <summary>The add friend.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Add(string id)
        {
            this.friendService.AddFriend(this.User.Identity.Name, id);
            return this.View();
        }

        /// <summary>The cancel.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Cancel(string id)
        {
            this.friendService.CancelFriend(id);
            return this.View();
        }

        /// <summary>The reject.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Reject(string id)
        {
            this.friendService.RejectFriend(id);
            return this.View();
        }

        /// <summary>The reject user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult RejectUser(string id)
        {
            this.friendService.RejectByUsername(id);
            return this.View(MVCT.Friend.Views.Reject);
        }

        /// <summary>The count.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult RequestCount()
        {
            this.ViewBag.Count = this.friendService.FindFriendRequestsCount(this.User.Identity.Name);
            return this.PartialView(MVCT.Friend.Views._RequestCount);
        }

        /// <summary>The requests.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult Requests()
        {
            FriendsModel model = this.friendService.FindFriendRequests(this.User.Identity.Name);
            return this.PartialView(MVCT.Friend.Views.Requests, model);
        }

        /// <summary>The unfriend.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Unfriend(string id)
        {
            this.friendService.Unfriend(id);
            return this.View();
        }

        /// <summary>The unfriend user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult UnfriendUser(string id)
        {
            this.friendService.UnfriendByUsername(id);
            return this.View(MVCT.Friend.Views.Unfriend);
        }

        #endregion
    }
}