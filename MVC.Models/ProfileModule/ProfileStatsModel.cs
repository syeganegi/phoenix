// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileStatsModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile stats model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System;

    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>The profile stats model.</summary>
    public class ProfileStatsModel : ModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the date viewed.</summary>
        public DateTime DateViewed { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>Gets or sets the picture raw photo.</summary>
        public byte[] PictureRawPhoto { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        public string Sex { get; set; }

        /// <summary>Gets or sets the sport.</summary>
        public string Sport { get; set; }

        /// <summary>Gets or sets the user name.</summary>
        public string UserName { get; set; }

        #endregion
    }
}