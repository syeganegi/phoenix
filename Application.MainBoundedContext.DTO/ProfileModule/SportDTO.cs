// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SportDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The sport dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;

    /// <summary>The sport dto.</summary>
    public class SportDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>Gets or sets the current club team.</summary>
        public string ClubTeam { get; set; }

        /// <summary>Gets or sets the current contract dates.</summary>
        public DateTime? ContractDateFrom { get; set; }

        /// <summary>Gets or sets the contract date to.</summary>
        public DateTime? ContractDateTo { get; set; }

        /// <summary>Gets or sets the favorite other sport.</summary>
        public string FavoriteOtherSport { get; set; }

        /// <summary>Gets or sets the favorite sporting idol.</summary>
        public string FavoriteSportingIdol { get; set; }

        /// <summary>Gets or sets the current management company.</summary>
        public string ManagementCompany { get; set; }

        /// <summary>Gets or sets the overseas opportunities.</summary>
        public string OverseasOpportunities { get; set; }

        /// <summary>Gets or sets the current playing position.</summary>
        public string PlayingPosition { get; set; }

        /// <summary>Gets or sets the school achievements.</summary>
        public string SchoolAchievements { get; set; }

        /// <summary>Gets or sets the signed by.</summary>
        public string SignedBy { get; set; }

        /// <summary>Gets or sets the sport.</summary>
        public string Sport { get; set; }

        /// <summary>Gets or sets the sport achievements.</summary>
        public string SportAchievements { get; set; }

        #endregion
    }
}