// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendMvcService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The friend mvc service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services
{
    using System;
    using System.ServiceModel;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Mappers;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;

    /// <summary>The friend mvc service.</summary>
    public class FriendMvcService : IFriendMvcService
    {
        #region Fields

        /// <summary>The profile client.</summary>
        private readonly ProfileModuleServiceClient profileClient;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FriendMvcService" /> class.
        /// </summary>
        public FriendMvcService()
        {
            this.profileClient = new ProfileModuleServiceClient();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The accept by username.</summary>
        /// <param name="username">The username.</param>
        public void AcceptByUsername(string username)
        {
            this.ManageFriendshipByUsername(username, ManageFriendshipRequestType.AcceptByUsername);
        }

        /// <summary>The accept friend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        public void AcceptFriend(string friendshipId)
        {
            Guid id;
            if (Guid.TryParse(friendshipId, out id) == false)
            {
                Guard.ArgumentIsEmpty(id, "friendshipId");
            }

            var request = new ManageFriendshipRequest
                              {
                                  FriendshipId = id, 
                                  RequestType = ManageFriendshipRequestType.Accept, 
                                  Requester = RequesterFactory.CreateRequest()
                              };
            this.profileClient.ManageFriendship(request);
        }

        /// <summary>The add friend.</summary>
        /// <param name="initiator">The initiator.</param>
        /// <param name="acceptor">The acceptor.</param>
        public void AddFriend(string initiator, string acceptor)
        {
            var request = new AddFriendRequest { Acceptor = acceptor, Requester = RequesterFactory.CreateRequest() };
            this.profileClient.AddFriend(request);
        }

        /// <summary>The cancel friend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        public void CancelFriend(string friendshipId)
        {
            Guid id;
            if (Guid.TryParse(friendshipId, out id) == false)
            {
                Guard.ArgumentIsEmpty(id, "friendshipId");
            }

            var request = new ManageFriendshipRequest
                              {
                                  FriendshipId = id, 
                                  RequestType = ManageFriendshipRequestType.Cancel, 
                                  Requester = RequesterFactory.CreateRequest()
                              };
            this.profileClient.ManageFriendship(request);
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            try
            {
                if (this.profileClient.State != CommunicationState.Faulted)
                {
                    this.profileClient.Close();
                }
            }
            catch (Exception)
            {
                this.profileClient.Abort();
            }
        }

        /// <summary>The find friend requests.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="FriendsModel"/>.</returns>
        public FriendsModel FindFriendRequests(string username)
        {
            ProfileListDTO[] profiles = this.profileClient.FindFriendRequests(username);
            ProfileModel[] friends = profiles != null ? profiles.ConvertToModel() : new ProfileModel[0];

            return new FriendsModel { Friends = friends, UserName = username };
        }

        /// <summary>The find friend requests count.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int FindFriendRequestsCount(string username)
        {
            return this.profileClient.FindFriendRequestsCount(username);
        }

        /// <summary>The find friends.</summary>
        /// <param name="username">The username.</param>
        /// <param name="text">The text.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The <see cref="FriendsModel"/>.</returns>
        public FriendsModel FindFriends(string username, string text, int pageIndex, int pageSize)
        {
            var request = new FindFriendsRequest
                              {
                                  UserName = username, 
                                  SearchText = text, 
                                  PageIndex = pageIndex, 
                                  PageSize = pageSize, 
                                  Requester = RequesterFactory.CreateRequest()
                              };
            ProfileListDTO[] profiles = this.profileClient.FindFriends(request);
            ProfileModel[] friends = profiles != null ? profiles.ConvertToModel() : new ProfileModel[0];

            return new FriendsModel { Friends = friends, UserName = username };
        }

        /// <summary>The unfriend by username.</summary>
        /// <param name="username">The username.</param>
        public void RejectByUsername(string username)
        {
            this.ManageFriendshipByUsername(username, ManageFriendshipRequestType.RejectByUsername);
        }

        /// <summary>The reject friend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        public void RejectFriend(string friendshipId)
        {
            Guid id;
            if (Guid.TryParse(friendshipId, out id) == false)
            {
                Guard.ArgumentIsEmpty(id, "friendshipId");
            }

            var request = new ManageFriendshipRequest
                              {
                                  FriendshipId = id, 
                                  RequestType = ManageFriendshipRequestType.Reject, 
                                  Requester = RequesterFactory.CreateRequest()
                              };
            this.profileClient.ManageFriendship(request);
        }

        /// <summary>The unfriend.</summary>
        /// <param name="friendshipId">The friendshipId.</param>
        public void Unfriend(string friendshipId)
        {
            Guid id;
            if (Guid.TryParse(friendshipId, out id) == false)
            {
                Guard.ArgumentIsEmpty(id, "friendshipId");
            }

            var request = new ManageFriendshipRequest
                              {
                                  FriendshipId = id, 
                                  RequestType = ManageFriendshipRequestType.Unfriend, 
                                  Requester = RequesterFactory.CreateRequest()
                              };
            this.profileClient.ManageFriendship(request);
        }

        /// <summary>The unfriend by username.</summary>
        /// <param name="username">The username.</param>
        public void UnfriendByUsername(string username)
        {
            this.ManageFriendshipByUsername(username, ManageFriendshipRequestType.UnfriendByUsername);
        }

        #endregion

        #region Methods

        /// <summary>The manage friendship by username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="actionType">The action type.</param>
        private void ManageFriendshipByUsername(string username, ManageFriendshipRequestType actionType)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            var request = new ManageFriendshipRequest
                              {
                                  UserName = username, 
                                  RequestType = actionType, 
                                  Requester = RequesterFactory.CreateRequest()
                              };
            this.profileClient.ManageFriendship(request);
        }

        #endregion
    }
}