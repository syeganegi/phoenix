// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System;

    /// <summary>The about model.</summary>
    public class ProfileModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

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

        /// <summary>Gets or sets a value indicating whether is enabled.</summary>
        public bool IsEnabled { get; set; }

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

        #endregion
    }
}