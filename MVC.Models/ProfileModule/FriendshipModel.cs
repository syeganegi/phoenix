// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System;

    /// <summary>The friendship model.</summary>
    public class FriendshipModel
    {
        #region Public Properties

        /// <summary>Gets or sets the acceptor id.</summary>
        public Guid AcceptorId { get; set; }

        /// <summary>
        ///     Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; protected set; }

        /// <summary>Gets or sets the date status changed.</summary>
        public DateTime DateStatusChanged { get; protected set; }

        /// <summary>Gets or sets the id.</summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the initiator id.
        /// </summary>
        public Guid InitiatorId { get; set; }

        /// <summary>Gets or sets the state.</summary>
        public string Status { get; set; }

        #endregion
    }
}