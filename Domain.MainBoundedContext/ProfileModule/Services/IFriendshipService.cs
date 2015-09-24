// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFriendshipService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Services
{
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;

    /// <summary>
    ///     The FriendshipService interface.
    /// </summary>
    public interface IFriendshipService
    {
        #region Public Methods and Operators

        /// <summary>The accept request.</summary>
        /// <param name="friendRequest">The friend request.</param>
        /// <param name="profile">The profile.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool AcceptRequest(Friendship friendRequest, Profile profile);

        /// <summary>The add friend request.</summary>
        /// <param name="initiator">The initiator.</param>
        /// <param name="acceptor">The acceptor.</param>
        /// <returns>The <see cref="Friendship"/>.</returns>
        Friendship AddFriendRequest(Profile initiator, Profile acceptor);

        /// <summary>The cancel.</summary>
        /// <param name="friendship">The friendship.</param>
        /// <param name="profile">The profile.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool CancelRequest(Friendship friendship, Profile profile);

        /// <summary>The reject request.</summary>
        /// <param name="friendRequest">The friend request.</param>
        /// <param name="profile">The profile.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool RejectRequest(Friendship friendRequest, Profile profile);

        /// <summary>The unfriend.</summary>
        /// <param name="friendship">The friendship.</param>
        /// <param name="profile">The profile.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool Unfriend(Friendship friendship, Profile profile);

        #endregion
    }
}