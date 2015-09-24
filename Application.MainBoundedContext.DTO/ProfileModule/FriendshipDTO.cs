// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;

    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The friend request dto.</summary>
    public class FriendshipDTO : DTOBase
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

        /// <summary>
        ///     Gets or sets the initiator id.
        /// </summary>
        public Guid InitiatorId { get; set; }

        /// <summary>Gets or sets the state.</summary>
        public string Status { get; set; }

        #endregion
    }
}