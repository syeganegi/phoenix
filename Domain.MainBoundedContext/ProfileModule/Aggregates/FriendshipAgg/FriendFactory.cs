// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendFactory.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;

    /// <summary>
    ///     The friendship factory
    /// </summary>
    public static class FriendFactory
    {
        #region Public Methods and Operators

        /// <summary>The create friend request.</summary>
        /// <param name="initiator">The initiator.</param>
        /// <param name="acceptor">The acceptor.</param>
        /// <returns>The <see cref="Friendship"/>.</returns>
        public static Friendship CreateFriendRequest(Profile initiator, Profile acceptor)
        {
            var friendship = new Friendship(FriendshipStatus.Requested)
                                 {
                                     InitiatorId = initiator.Id, 
                                     AcceptorId = acceptor.Id
                                 };
            friendship.GenerateNewIdentity();

            return friendship;
        }

        /// <summary>The create friendship.</summary>
        /// <param name="initiatorId">The initiator id.</param>
        /// <param name="acceptorId">The acceptor id.</param>
        /// <returns>The <see cref="Friendship"/>.</returns>
        public static Friendship CreateFriendship(Guid initiatorId, Guid acceptorId)
        {
            var friendship = new Friendship { InitiatorId = initiatorId, AcceptorId = acceptorId };
            friendship.GenerateNewIdentity();

            return friendship;
        }

        #endregion
    }
}