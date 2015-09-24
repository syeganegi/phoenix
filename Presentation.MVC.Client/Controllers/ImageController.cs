// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The image controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>
    ///     The image controller.
    /// </summary>
    [Authorize]
    public partial class ImageController : BaseController
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImageController" /> class.
        /// </summary>
        public ImageController()
            : this(new ProfileMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ImageController"/> class. Initializes a new instance of the<see cref="AccountController"/>
        ///     class.</summary>
        /// <param name="profileMvcService">The account service.</param>
        public ImageController(IProfileMvcService profileMvcService)
            : base(profileMvcService)
        {
        }

        #endregion

        // GET: /Image/
        #region Public Methods and Operators

        /// <summary>The render.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Render(string username)
        {
            byte[] imageData = this.ProfileService.GetProfilePicture(username);
            return this.File(imageData, "image/jpg");
        }

        #endregion
    }
}