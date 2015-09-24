// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilePictureModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The about model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The profile picture model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class ProfilePictureModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the profile picture.</summary>
        public byte[] RawPhoto { get; set; }

        #endregion
    }
}