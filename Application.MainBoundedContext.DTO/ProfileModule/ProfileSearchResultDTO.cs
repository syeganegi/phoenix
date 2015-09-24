// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileSearchResultDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile search result dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;

    /// <summary>The profile search result dto.</summary>
    public class ProfileSearchResultDTO
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the acceptor id.
        /// </summary>
        public Guid FriendshipAcceptorId { get; set; }

        /// <summary>
        ///     Gets or sets the date created.
        /// </summary>
        public DateTime FriendshipDateCreated { get; set; }

        /// <summary>
        ///     Gets the state change date.
        /// </summary>
        /// <value>
        ///     The state change date.
        /// </value>
        public DateTime FriendshipDateStatusChanged { get; set; }

        /// <summary>Gets or sets the friendship id.</summary>
        public Guid FriendshipId { get; set; }

        /// <summary>
        ///     Gets or sets the initiator id.
        /// </summary>
        public Guid FriendshipInitiatorId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the status.
        /// </summary>
        public string FriendshipStatus { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        public DateTime ProfileBirthday { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string ProfileEmail { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string ProfileFirstName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string ProfileFullName { get; set; }

        /// <summary>Gets or sets the profile id.</summary>
        public Guid ProfileId { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string ProfileLastName { get; set; }

        /// <summary>Gets or sets the picture raw photo.</summary>
        public byte[] ProfilePictureRawPhoto { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        public string ProfileSex { get; set; }

        /// <summary>Gets or sets the sport.</summary>
        public string ProfileSport { get; set; }

        /// <summary>Gets or sets the profile user name.</summary>
        public string ProfileUserName { get; set; }

        #endregion
    }
}