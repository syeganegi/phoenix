// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFriendMvcService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The FriendMvcService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services
{
    using System;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;

    /// <summary>The FriendMvcService interface.</summary>
    public interface IFriendMvcService : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>The accept by username.</summary>
        /// <param name="username">The username.</param>
        void AcceptByUsername(string username);

        /// <summary>The accept friend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        void AcceptFriend(string friendshipId);

        /// <summary>The add friend.</summary>
        /// <param name="initiator">The initiator.</param>
        /// <param name="acceptor">The acceptor.</param>
        void AddFriend(string initiator, string acceptor);

        /// <summary>The cancel friend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        void CancelFriend(string friendshipId);

        /// <summary>The find friend requests.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="FriendsModel"/>.</returns>
        FriendsModel FindFriendRequests(string username);

        /// <summary>The find friend requests count.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="int"/>.</returns>
        int FindFriendRequestsCount(string username);

        /// <summary>The find friends.</summary>
        /// <param name="username">The username.</param>
        /// <param name="text">The text.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The <see cref="FriendsModel"/>.</returns>
        FriendsModel FindFriends(string username, string text, int pageIndex, int pageSize);

        /// <summary>The reject by username.</summary>
        /// <param name="username">The username.</param>
        void RejectByUsername(string username);

        /// <summary>The reject friend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        void RejectFriend(string friendshipId);

        /// <summary>The unfriend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        void Unfriend(string friendshipId);

        /// <summary>The unfriend by username.</summary>
        /// <param name="username">The username.</param>
        void UnfriendByUsername(string username);

        #endregion
    }
}