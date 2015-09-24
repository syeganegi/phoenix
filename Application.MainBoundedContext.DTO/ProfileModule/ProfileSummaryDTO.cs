// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileSummaryDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile summary dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;

    /// <summary>The profile summary dto.</summary>
    public class ProfileSummaryDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>Gets or sets the current club team.</summary>
        public string ClubTeam { get; set; }

        /// <summary>Gets or sets the current contract dates.</summary>
        public DateTime? ContractDateFrom { get; set; }

        /// <summary>Gets or sets the contract date to.</summary>
        public DateTime? ContractDateTo { get; set; }

        // public string Email { get; set; }
        /// <summary>
        ///     Gets or sets the emails.
        /// </summary>
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the current management company.</summary>
        public string ManagementCompany { get; set; }

        /// <summary>Gets or sets the nationality.</summary>
        public string Nationality { get; set; }

        /// <summary>Gets or sets the current playing position.</summary>
        public string PlayingPosition { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        public string Sex { get; set; }

        /// <summary>Gets or sets the signed by.</summary>
        public string SignedBy { get; set; }

        /// <summary>Gets or sets the sport.</summary>
        public string Sport { get; set; }

        /// <summary>
        ///     Gets or sets the weight.
        /// </summary>
        public string Weight { get; set; }

        #endregion
    }
}