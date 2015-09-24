// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileAdminModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin
{
    using System;
    using System.ComponentModel;

    /// <summary>The profile admin model.</summary>
    public class ProfileAdminModel
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

        /// <summary>Gets or sets the id.</summary>
        public string Id { get; set; }

        /// <summary>Gets or sets a value indicating whether is enabled.</summary>
        [DisplayName("Enabled?")]
        public bool IsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>Gets or sets the picture raw photo.</summary>
        public byte[] PictureRawPhoto { get; set; }

        /// <summary>Gets or sets the roles.</summary>
        public string[] Roles { get; set; }

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