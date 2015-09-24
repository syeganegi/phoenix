// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The friend app service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Application.Seedwork;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Services;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;

    /// <summary>The friend app service.</summary>
    public class FriendAppService : IFriendAppService
    {
        #region Fields

        /// <summary>The friendship repository.</summary>
        private readonly IFriendshipRepository friendshipRepository;

        /// <summary>The friendship service.</summary>
        private readonly IFriendshipService friendshipService;

        /// <summary>The profile repository.</summary>
        private readonly IProfileRepository profileRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="FriendAppService"/> class.</summary>
        /// <param name="friendshipService">The friendship service.</param>
        /// <param name="friendshipRepository">The friendship repository.</param>
        /// <param name="profileRepository">The profile repository.</param>
        public FriendAppService(
            IFriendshipService friendshipService, 
            IFriendshipRepository friendshipRepository, 
            IProfileRepository profileRepository)
        {
            Guard.ArgumentIsNotNull(friendshipService, "friendshipService");
            Guard.ArgumentIsNotNull(friendshipRepository, "friendshipRepository");
            Guard.ArgumentIsNotNull(profileRepository, "profileRepository");

            this.friendshipService = friendshipService;
            this.friendshipRepository = friendshipRepository;
            this.profileRepository = profileRepository;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The add friend.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FriendshipDTO"/>.</returns>
        public FriendshipDTO AddFriend(AddFriendRequest request)
        {
            Guard.ArgumentIsNotNull(request, "request");
            Guard.ArgumentIsNotNull(request.Requester, "request.Requester");
            Guard.ArgumentIsNotNullOrEmpty(request.Requester.UserName, "request.Requester.UserName");

            Profile initiator = this.profileRepository.Get(request.Requester.UserName);
            Profile acceptor = this.profileRepository.Get(request.Acceptor);
            Friendship friendRequest = this.friendshipService.AddFriendRequest(initiator, acceptor);
            this.SaveFriendRequest(friendRequest);

            return friendRequest.ProjectedAs<FriendshipDTO>();
        }

        /// <summary>
        ///     <see cref="M:System.IDisposable.Dispose" />
        /// </summary>
        public void Dispose()
        {
            // dispose all resources
            this.profileRepository.Dispose();
        }

        /// <summary>The find friend requests.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<ProfileListDTO> FindFriendRequests(string username)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");
            IEnumerable<Profile> profiles = this.GetFriendRequesters(username);

            IList<Profile> enumerable = profiles as IList<Profile> ?? profiles.ToList();
            List<ProfileListDTO> profileDtos = enumerable.Any()
                                                   ? enumerable.ProjectedAsCollection<Profile, ProfileListDTO>()
                                                   : null;

            return profileDtos;
        }

        /// <summary>The find friend requests count.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int FindFriendRequestsCount(string username)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");
            IEnumerable<Profile> profiles = this.GetFriendRequesters(username);

            return profiles.Count();
        }

        /// <summary>The find friends.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FindProfilesResponse"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public List<ProfileListDTO> FindFriends(FindFriendsRequest request)
        {
            Guard.ArgumentIsNotNull(request, "request");
            Guard.ArgumentIsNotNullOrEmpty(request.UserName, "request.UserName");
            Guard.ArgumentIsNotNull(request.Requester, "request.Requester");

            Profile profile = this.profileRepository.Get(request.UserName);
            if (profile == null)
            {
                throw new InvalidOperationException(Messages.exception_ProfileWasNotFound);
            }

            // get the specification
            Specification<Profile> enabledProfiles = ProfileSpecifications.EnabledProfiles();
            Specification<Profile> filter = ProfileSpecifications.ProfileFullText(request.SearchText);
            ISpecification<Profile> spec = enabledProfiles & filter;

            // Query this criteria
            List<Profile> profiles = this.friendshipRepository.GetFriends(profile.Id, spec.SatisfiedBy()).ToList();

            List<ProfileListDTO> profileDtos = profiles.Any()
                                                   ? profiles.ProjectedAsCollection<Profile, ProfileListDTO>()
                                                   : null;

            return profileDtos;
        }

        /// <summary>The manage friendship.</summary>
        /// <param name="request">The request.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ManageFriendship(ManageFriendshipRequest request)
        {
            Guard.ArgumentIsNotNull(request, "request");

            Profile profile = this.profileRepository.Get(request.Requester.UserName);
            if (profile == null)
            {
                throw new InvalidOperationException(Messages.exception_ProfileWasNotFound);
            }

            Friendship friendship = request.RequestType == ManageFriendshipRequestType.UnfriendByUsername
                                    || request.RequestType == ManageFriendshipRequestType.AcceptByUsername
                                    || request.RequestType == ManageFriendshipRequestType.RejectByUsername
                                        ? this.friendshipRepository.Get(request.UserName, profile.UserName)
                                        : this.friendshipRepository.Get(request.FriendshipId);

            if (friendship == null)
            {
                throw new InvalidOperationException(Messages.exception_FriendshipWasNotFound);
            }

            bool success = false;
            switch (request.RequestType)
            {
                case ManageFriendshipRequestType.Accept:
                case ManageFriendshipRequestType.AcceptByUsername:
                    success = this.friendshipService.AcceptRequest(friendship, profile);
                    break;
                case ManageFriendshipRequestType.Cancel:
                    success = this.friendshipService.CancelRequest(friendship, profile);
                    break;
                case ManageFriendshipRequestType.Reject:
                case ManageFriendshipRequestType.RejectByUsername:
                    success = this.friendshipService.RejectRequest(friendship, profile);
                    break;
                case ManageFriendshipRequestType.Unfriend:
                case ManageFriendshipRequestType.UnfriendByUsername:
                    success = this.friendshipService.Unfriend(friendship, profile);
                    break;
            }

            if (success)
            {
                this.friendshipRepository.UnitOfWork.Commit();
            }
        }

        #endregion

        #region Methods

        /// <summary>The get friend requesters.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private IEnumerable<Profile> GetFriendRequesters(string username)
        {
            Profile profile = this.profileRepository.Get(username);
            if (profile == null)
            {
                throw new InvalidOperationException(Messages.exception_ProfileWasNotFound);
            }

            // get the specification
            Specification<Friendship> filter = FriendshipSpecifications.FriendRequests(profile.Id);
            IEnumerable<Profile> profiles = this.friendshipRepository.GetInitiators(filter.SatisfiedBy());

            return profiles;
        }

        /// <summary>The save friend request.</summary>
        /// <param name="request">The request.</param>
        /// <exception cref="ApplicationValidationErrorsException"></exception>
        private void SaveFriendRequest(Friendship request)
        {
            // recover validator
            IEntityValidator validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(request))
            {
                // if request is valid
                // add the request into the repository
                this.friendshipRepository.Add(request);

                // commit the unit of work
                this.friendshipRepository.UnitOfWork.Commit();
            }
            else
            {
                // request is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(request));
            }
        }

        #endregion
    }
}