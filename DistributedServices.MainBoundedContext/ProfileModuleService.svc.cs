// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileModuleService.svc.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.DistributedServices.MainBoundedContext
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.ServiceModel;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services;
    using Phoenix.PhoenixApp.Application.Seedwork;
    using Phoenix.PhoenixApp.DistributedServices.MainBoundedContext.InstanceProviders;
    using Phoenix.PhoenixApp.DistributedServices.Seedwork.ErrorHandlers;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;

    /// <summary>
    ///     The profile module service.
    /// </summary>
    [ApplicationErrorHandler] // manage all unhandled exceptions
    [UnityInstanceProviderServiceBehavior] // create instance and inject dependencies using unity container
    public class ProfileModuleService : IProfileModuleService
    {
        #region Fields

        /// <summary>The friend app service.</summary>
        private readonly IFriendAppService friendAppService;

        /// <summary>The media app service.</summary>
        private readonly IMediaAppService mediaAppService;

        /// <summary>The post app service.</summary>
        private readonly IPostAppService postAppService;

        /// <summary>
        ///     The profile app service.
        /// </summary>
        private readonly IProfileAppService profileAppService;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ProfileModuleService"/> class.
        ///     Create a new instance Profile Module Service</summary>
        /// <param name="profileAppService">The profile app service dependency</param>
        /// <param name="friendAppService">The friend App Service.</param>
        /// <param name="postAppService">The post App Service.</param>
        /// <param name="mediaAppService">The media App Service.</param>
        public ProfileModuleService(
            IProfileAppService profileAppService, 
            IFriendAppService friendAppService, 
            IPostAppService postAppService, 
            IMediaAppService mediaAppService)
        {
            Guard.ArgumentIsNotNull(profileAppService, "profileAppService");
            Guard.ArgumentIsNotNull(friendAppService, "friendAppService");
            Guard.ArgumentIsNotNull(postAppService, "postAppService");
            Guard.ArgumentIsNotNull(mediaAppService, "mediaAppService");

            this.profileAppService = profileAppService;
            this.friendAppService = friendAppService;
            this.postAppService = postAppService;
            this.mediaAppService = mediaAppService;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The add friend.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FriendshipDTO"/>.</returns>
        /// <exception cref="FaultException{TDetail}"></exception>
        public FriendshipDTO AddFriend(AddFriendRequest request)
        {
            FriendshipDTO friendshipDTO = null;

            try
            {
                friendshipDTO = this.friendAppService.AddFriend(request);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }

            return friendshipDTO;
        }

        /// <summary>The add new media.</summary>
        /// <param name="mediaDTO">The media dto.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public MediaDTO AddNewMedia(MediaDTO mediaDTO)
        {
            try
            {
                return this.mediaAppService.AddNewMedia(mediaDTO);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The add new post.</summary>
        /// <param name="post">The post.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public PostDTO AddNewPost(PostDTO post)
        {
            PostDTO postDTO = null;
            try
            {
                postDTO = this.postAppService.AddNewPost(post);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }

            return postDTO;
        }

        /// <summary><see cref="Phoenix.PhoenixApp.Application.MainBoundedContext.BankingModule.Services.IMainBoundedContextService"/></summary>
        /// <param name="profile"><see cref="Phoenix.PhoenixApp.Application.MainBoundedContext.BankingModule.Services.IMainBoundedContextService"/></param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        public ProfileDTO AddNewProfile(ProfileDTO profile)
        {
            try
            {
                return this.profileAppService.AddNewProfile(profile);
            }
            catch (ApplicationValidationErrorsException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.ValidationErrors };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The delete media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public bool DeleteMedia(Guid id)
        {
            try
            {
                return this.mediaAppService.DeleteMedia(id);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The delete post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public bool DeletePost(Guid id)
        {
            try
            {
                return this.postAppService.DeletePost(id);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The delete profile.</summary>
        /// <param name="username">The username.</param>
        /// <exception cref="FaultException{T}"></exception>
        public void DeleteProfile(string username)
        {
            try
            {
                this.profileAppService.DeleteProfile(username);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>
        ///     <see cref="M:System.IDisposable.Dispose" />
        /// </summary>
        public void Dispose()
        {
            // dispose all resources
            this.profileAppService.Dispose();
        }

        /// <summary>The enable profile.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="enabled">The enabled.</param>
        /// <exception cref="FaultException{T}"></exception>
        public void EnableProfile(Guid profileId, bool enabled)
        {
            try
            {
                this.profileAppService.EnableProfile(profileId, enabled);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>Finds the profileSummary.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The <see cref="AboutDTO"/>.</returns>
        public AboutDTO FindAbout(string userName)
        {
            return this.profileAppService.GetDTO<AboutDTO>(userName);
        }

        /// <summary>The find achievements.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="AchievementsDTO"/>.</returns>
        public AchievementsDTO FindAchievements(string userName)
        {
            return this.profileAppService.GetDTO<AchievementsDTO>(userName);
        }

        /// <summary>The find basic info.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="BasicInfoDTO"/>.</returns>
        public BasicInfoDTO FindBasicInfo(string userName)
        {
            return this.profileAppService.GetDTO<BasicInfoDTO>(userName);
        }

        /// <summary>The find contact.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ContactDTO"/>.</returns>
        public ContactDTO FindContact(string userName)
        {
            return this.profileAppService.GetDTO<ContactDTO>(userName);
        }

        /// <summary>The find friend requests.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public List<ProfileListDTO> FindFriendRequests(string username)
        {
            try
            {
                return this.friendAppService.FindFriendRequests(username);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The find friend requests count.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="int"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public int FindFriendRequestsCount(string username)
        {
            try
            {
                return this.friendAppService.FindFriendRequestsCount(username);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The find friends.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FindProfilesResponse"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public List<ProfileListDTO> FindFriends(FindFriendsRequest request)
        {
            try
            {
                return this.friendAppService.FindFriends(request);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The find living.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="LivingDTO"/>.</returns>
        public LivingDTO FindLiving(string userName)
        {
            return this.profileAppService.GetDTO<LivingDTO>(userName);
        }

        /// <summary>The find media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        public MediaDTO FindMedia(Guid id)
        {
            return this.mediaAppService.GetMedia(id);
        }

        /// <summary>The find medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<MediaDTO> FindMedias(string username)
        {
            return this.mediaAppService.GetMedias(username);
        }

        /// <summary>The find post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        public PostDTO FindPost(Guid id)
        {
            return this.postAppService.GetPost(id);
        }

        /// <summary>The find posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<PostDTO> FindPosts(string username)
        {
            return this.postAppService.GetPosts(username);
        }

        /// <summary><see cref="Phoenix.PhoenixApp.Application.MainBoundedContext.BankingModule.Services.IMainBoundedContextService"/></summary>
        /// <param name="profileId"><see cref="Phoenix.PhoenixApp.Application.MainBoundedContext.BankingModule.Services.IMainBoundedContextService"/></param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        public ProfileDTO FindProfile(Guid profileId)
        {
            return this.profileAppService.FindProfile(profileId);
        }

        /// <summary>Finds the profile.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        public ProfileDTO FindProfile(FindProfileRequest request)
        {
            return this.profileAppService.FindProfile(request);
        }

        /// <summary>The find profile picture.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfilePictureDTO"/>.</returns>
        public ProfilePictureDTO FindProfilePicture(string username)
        {
            return this.profileAppService.FindProfilePicture(username);
        }

        /// <summary>The find profile stats.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FindProfileStatsResponse"/>.</returns>
        public List<ProfileStatsDTO> FindProfileStats(FindProfileStatsRequest request)
        {
            return this.profileAppService.FindProfileStats(request);
        }

        /// <summary>The find profile summary.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ProfileSummaryDTO"/>.</returns>
        public ProfileSummaryDTO FindProfileSummary(string userName)
        {
            return this.profileAppService.GetDTO<ProfileSummaryDTO>(userName);
        }

        /// <summary>The find profiles.</summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<ProfileListDTO> FindProfiles()
        {
            return this.profileAppService.FindProfiles();
        }

        /// <summary>The find results.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ResultsDTO"/>.</returns>
        public ResultsDTO FindResults(string userName)
        {
            return this.profileAppService.GetDTO<ResultsDTO>(userName);
        }

        /// <summary>The find resume.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ResumeDTO"/>.</returns>
        public ResumeDTO FindResume(string userName)
        {
            return this.profileAppService.GetDTO<ResumeDTO>(userName);
        }

        /// <summary>The find sport.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="SportDTO"/>.</returns>
        public SportDTO FindSport(string userName)
        {
            return this.profileAppService.GetDTO<SportDTO>(userName);
        }

        /// <summary>The find work edu.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="WorkEduDTO"/>.</returns>
        public WorkEduDTO FindWorkEdu(string userName)
        {
            return this.profileAppService.GetDTO<WorkEduDTO>(userName);
        }

        /// <summary>The get profile view counter.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileCounterDTO"/>.</returns>
        public ProfileCounterDTO GetProfileViewCounter(string username)
        {
            return this.profileAppService.GetProfileViewCounter(username);
        }

        /// <summary>The manage friendship.</summary>
        /// <param name="request">The request.</param>
        /// <exception cref="FaultException{T}"></exception>
        public void ManageFriendship(ManageFriendshipRequest request)
        {
            try
            {
                this.friendAppService.ManageFriendship(request);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary><see cref="Phoenix.PhoenixApp.Application.MainBoundedContext.BankingModule.Services.IMainBoundedContextService"/></summary>
        /// <param name="profileId">The profile Id.</param>
        public void RemoveProfile(Guid profileId)
        {
            this.profileAppService.RemoveProfile(profileId);
        }

        /// <summary>The find profiles.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<ProfileSearchResultDTO> SearchProfiles(FindProfilesRequest request)
        {
            return this.profileAppService.FindProfiles(request);
        }

        /// <summary>The suggest friends.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        /// <exception cref="FaultException{T}"></exception>
        public List<ProfileListDTO> SuggestFriends(string username)
        {
            List<ProfileListDTO> profiles;
            try
            {
                profiles = this.profileAppService.SuggestFriends(username);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }

            return profiles;
        }

        /// <summary>Updates the profileSummary.</summary>
        /// <param name="about">The profileSummary.</param>
        public void UpdateAbout(AboutDTO about)
        {
            this.UpdateDTO(about);
        }

        /// <summary>The update achievements.</summary>
        /// <param name="dto">The dto.</param>
        public void UpdateAchievements(AchievementsDTO dto)
        {
            this.UpdateDTO(dto);
        }

        /// <summary>The update basic info.</summary>
        /// <param name="basicInfo">The basic info.</param>
        public void UpdateBasicInfo(BasicInfoDTO basicInfo)
        {
            this.UpdateDTO(basicInfo);
        }

        /// <summary>The update contact.</summary>
        /// <param name="contact">The contact.</param>
        public void UpdateContact(ContactDTO contact)
        {
            this.UpdateDTO(contact);
        }

        /// <summary>The update living.</summary>
        /// <param name="living">The living.</param>
        public void UpdateLiving(LivingDTO living)
        {
            this.UpdateDTO(living);
        }

        /// <summary><see cref="Phoenix.PhoenixApp.Application.MainBoundedContext.BankingModule.Services.IMainBoundedContextService"/></summary>
        /// <param name="profile"><see cref="Phoenix.PhoenixApp.Application.MainBoundedContext.BankingModule.Services.IMainBoundedContextService"/></param>
        public void UpdateProfile(ProfileDTO profile)
        {
            try
            {
                this.profileAppService.UpdateProfile(profile);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        /// <summary>The update profile picture.</summary>
        /// <param name="profilePicture">The profile picture.</param>
        /// <exception cref="FaultException{TDetail}"></exception>
        public void UpdateProfilePicture(ProfilePictureDTO profilePicture)
        {
            this.UpdateDTO(profilePicture);
        }

        /// <summary>The update profile summary.</summary>
        /// <param name="profileSummary">The profile summary.</param>
        public void UpdateProfileSummary(ProfileSummaryDTO profileSummary)
        {
            this.UpdateDTO(profileSummary);
        }

        /// <summary>The update results.</summary>
        /// <param name="results">The results.</param>
        public void UpdateResults(ResultsDTO results)
        {
            this.UpdateDTO(results);
        }

        /// <summary>The update resume.</summary>
        /// <param name="dto">The dto.</param>
        public void UpdateResume(ResumeDTO dto)
        {
            this.UpdateDTO(dto);
        }

        /// <summary>The update sport.</summary>
        /// <param name="sport">The sport.</param>
        public void UpdateSport(SportDTO sport)
        {
            this.UpdateDTO(sport);
        }

        /// <summary>The update work edu.</summary>
        /// <param name="workEdu">The work edu.</param>
        public void UpdateWorkEdu(WorkEduDTO workEdu)
        {
            this.UpdateDTO(workEdu);
        }

        #endregion

        #region Methods

        /// <summary>The update dto.</summary>
        /// <param name="dto">The dto.</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="FaultException{T}"></exception>
        private void UpdateDTO<T>(T dto) where T : ProfileDTOBase
        {
            try
            {
                this.profileAppService.UpdateDTO(dto);
            }
            catch (DbEntityValidationException e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.GetValidationErrors() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
            catch (Exception e)
            {
                var applicationServiceError = new ApplicationServiceError { ErrorMessages = e.Message.ToEnumerable() };
                throw new FaultException<ApplicationServiceError>(applicationServiceError, e.Message);
            }
        }

        #endregion
    }
}