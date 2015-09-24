// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilePageModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The profile model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class ProfilePageModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the about.</summary>
        public AboutModel About { get; set; }

        /// <summary>Gets or sets the achievements.</summary>
        public AchievementsModel Achievements { get; set; }

        /// <summary>Gets or sets the friendship.</summary>
        public FriendshipModel Friendship { get; set; }

        /// <summary>Gets or sets the profile picture.</summary>
        public ProfilePictureModel ProfilePicture { get; set; }

        /// <summary>Gets or sets the profile summary.</summary>
        public ProfileSummaryModel ProfileSummary { get; set; }

        /// <summary>Gets or sets the results.</summary>
        public ResultsModel Results { get; set; }

        /// <summary>Gets or sets the resume.</summary>
        public ResumeModel Resume { get; set; }

        #endregion
    }
}