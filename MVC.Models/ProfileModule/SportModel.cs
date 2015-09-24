// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SportModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The about model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System;
    using System.ComponentModel;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The about model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class SportModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the current contract dates.</summary>
        [DisplayName("Contract From")]
        public DateTime? ContractDateFrom { get; set; }

        /// <summary>Gets or sets the contract date to.</summary>
        [DisplayName("Contract To")]
        public DateTime? ContractDateTo { get; set; }

        /// <summary>Gets or sets the current club team.</summary>
        [DisplayName("Current Club Team")]
        public string CurrentClubTeam { get; set; }

        /// <summary>Gets or sets the favorite other sport.</summary>
        [DisplayName("Favorite Other Sport")]
        public string FavoriteOtherSport { get; set; }

        /// <summary>Gets or sets the favorite sporting idol.</summary>
        [DisplayName("Favorite Sporting Idol")]
        public string FavoriteSportingIdol { get; set; }

        /// <summary>Gets or sets the current management company.</summary>
        [DisplayName("Management Company")]
        public string ManagementCompany { get; set; }

        /// <summary>Gets or sets the overseas opportunities.</summary>
        [DisplayName("Overseas Opportunities")]
        public string OverseasOpportunities { get; set; }

        /// <summary>Gets or sets the current playing position.</summary>
        [DisplayName("Current Playing Position")]
        public string PlayingPosition { get; set; }

        /// <summary>Gets or sets the school achievements.</summary>
        [DisplayName("School Achievements")]
        public string SchoolAchievements { get; set; }

        /// <summary>Gets or sets the signed by.</summary>
        [DisplayName("Signed By")]
        public string SignedBy { get; set; }

        /// <summary>Gets or sets the sport.</summary>
        [DisplayName("Sport")]
        public string Sport { get; set; }

        /// <summary>Gets or sets the sport achievements.</summary>
        [DisplayName("Sport Achievements")]
        public string SportAchievements { get; set; }

        #endregion
    }
}