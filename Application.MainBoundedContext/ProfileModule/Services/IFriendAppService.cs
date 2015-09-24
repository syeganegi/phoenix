// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFriendAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The FriendAppService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging;

    /// <summary>The FriendAppService interface.</summary>
    public interface IFriendAppService : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>The add friend.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FriendshipDTO"/>.</returns>
        FriendshipDTO AddFriend(AddFriendRequest request);

        /// <summary>The find friend requests.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        List<ProfileListDTO> FindFriendRequests(string username);

        /// <summary>The find friend requests count.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="int"/>.</returns>
        int FindFriendRequestsCount(string username);

        /// <summary>The find friends.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FindProfilesResponse"/>.</returns>
        List<ProfileListDTO> FindFriends(FindFriendsRequest request);

        /// <summary>The manage friendship.</summary>
        /// <param name="request">The request.</param>
        void ManageFriendship(ManageFriendshipRequest request);

        #endregion
    }
}