// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicInfoDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The basic info dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;

    /// <summary>The basic info dto.</summary>
    public class BasicInfoDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

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
        ///     Gets or sets the interested in.
        /// </summary>
        public string InterestedIn { get; set; }

        /// <summary>
        ///     Gets or sets the languages.
        /// </summary>
        public string Languages { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the political views.
        /// </summary>
        public string PoliticalViews { get; set; }

        /// <summary>
        ///     Gets or sets the relationship status.
        /// </summary>
        public string RelationshipStatus { get; set; }

        /// <summary>
        ///     Gets or sets the religion.
        /// </summary>
        public string Religion { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        ///     Gets or sets the weight.
        /// </summary>
        public string Weight { get; set; }

        #endregion
    }
}