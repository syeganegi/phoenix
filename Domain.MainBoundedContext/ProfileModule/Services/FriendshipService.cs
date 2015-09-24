// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;

    /// <summary>
    ///     The friendship service.
    /// </summary>
    public class FriendshipService : IFriendshipService
    {
        #region Fields

        /// <summary>
        ///     The friendship repository.
        /// </summary>
        private readonly IFriendshipRepository friendshipRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="FriendshipService"/> class.</summary>
        /// <param name="friendshipRepository">The friendship repository.</param>
        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            Guard.ArgumentIsNotNull(friendshipRepository, "friendshipRepository");

            this.friendshipRepository = friendshipRepository;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Accepts the request.</summary>
        /// <param name="friendship">The friend request.</param>
        /// <param name="profile">The profile.</param>
        /// <exception cref="System.ArgumentException">Null or Transient friend request. Status is <see cref="FriendshipStatus.Requested"/></exception>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AcceptRequest(Friendship friendship, Profile profile)
        {
            CheckForValidFriendship(friendship);
            if (friendship.Status != FriendshipStatus.Requested)
            {
                throw new ArgumentException(Messages.exception_CannotAcceptNonRequestedFriendship);
            }

            if (friendship.AcceptorId != profile.Id)
            {
                throw new ArgumentException(Messages.exception_InvalidFriendshipAction);
            }

            friendship.SetStatus(FriendshipStatus.Accepted);
            return true;
        }

        /// <summary>The add friend request.</summary>
        /// <param name="initiator">The initiator.</param>
        /// <param name="acceptor">The acceptor.</param>
        /// <returns>The <see cref="Friendship"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Friendship AddFriendRequest(Profile initiator, Profile acceptor)
        {
            if (initiator == null || initiator.IsTransient())
            {
                throw new ArgumentException(Messages.exception_FriendshipInitiatorCannotBeNullOrEmpty);
            }

            if (acceptor == null || acceptor.IsTransient())
            {
                throw new ArgumentException(Messages.exception_FriendshipAcceptorCannotBeNullOrEmpty);
            }

            if (initiator.Id == acceptor.Id || initiator.UserName == acceptor.UserName)
            {
                throw new ArgumentException(Messages.exception_CannotSendFriendshipWhenInitiatorIsTheSameAsAcceptor);
            }

            // check if they are already friends
            Specification<Friendship> friendSpec = FriendshipSpecifications.ExistingFriendship(
                initiator.Id, acceptor.Id);
            IEnumerable<Friendship> friendships = this.friendshipRepository.GetFiltered(friendSpec.SatisfiedBy());
            if (friendships.Any())
            {
                throw new InvalidOperationException(Messages.exception_FriendshipAlreadyExists);
            }

            return FriendFactory.CreateFriendRequest(initiator, acceptor);
        }

        /// <summary>The cancel.</summary>
        /// <param name="friendship">The friendship.</param>
        /// <param name="profile">The profile.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool CancelRequest(Friendship friendship, Profile profile)
        {
            CheckForValidFriendship(friendship);
            if (friendship.Status != FriendshipStatus.Requested)
            {
                throw new ArgumentException(Messages.exception_CannotCancelNonRequestedFriendship);
            }

            if (friendship.InitiatorId != profile.Id)
            {
                throw new ArgumentException(Messages.exception_InvalidFriendshipAction);
            }

            this.friendshipRepository.Remove(friendship);
            return true;
        }

        /// <summary>The reject request.</summary>
        /// <param name="friendship">The friend request.</param>
        /// <param name="profile">The profile.</param>
        /// <exception cref="NotImplementedException">Null or Transient friend request.</exception>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool RejectRequest(Friendship friendship, Profile profile)
        {
            CheckForValidFriendship(friendship);
            if (friendship.Status != FriendshipStatus.Requested)
            {
                throw new ArgumentException(Messages.exception_CannotRejectNonRequestedFriendship);
            }

            if (friendship.AcceptorId != profile.Id)
            {
                throw new ArgumentException(Messages.exception_InvalidFriendshipAction);
            }

            this.friendshipRepository.Remove(friendship);
            return true;
        }

        /// <summary>The unfriend.</summary>
        /// <param name="friendship">The friendship.</param>
        /// <param name="profile">The profile.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Unfriend(Friendship friendship, Profile profile)
        {
            CheckForValidFriendship(friendship);
            if (friendship.InitiatorId != profile.Id && friendship.AcceptorId != profile.Id)
            {
                throw new ArgumentException(Messages.exception_InvalidFriendshipAction);
            }

            this.friendshipRepository.Remove(friendship);
            return true;
        }

        #endregion

        #region Methods

        /// <summary>Checks for valid friend request.</summary>
        /// <param name="friendship">The friend request.</param>
        /// <exception cref="System.ArgumentException">Null or Transient friend request.</exception>
        private static void CheckForValidFriendship(Friendship friendship)
        {
            if (friendship == null || friendship.IsTransient())
            {
                throw new ArgumentException(Messages.exception_FriendshipCannotBeNullOrEmpty);
            }
        }

        #endregion
    }
}