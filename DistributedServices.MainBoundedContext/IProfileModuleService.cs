// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileModuleService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.DistributedServices.MainBoundedContext
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging;
    using Phoenix.PhoenixApp.DistributedServices.Seedwork.ErrorHandlers;

    /// <summary>
    ///     WCF SERVICE FACADE FOR Profile MODULE
    /// </summary>
    [ServiceContract]
    public interface IProfileModuleService : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>The add friend.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FriendshipDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        FriendshipDTO AddFriend(AddFriendRequest request);

        /// <summary>The add new media.</summary>
        /// <param name="mediaDTO">The media dto.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        MediaDTO AddNewMedia(MediaDTO mediaDTO);

        /// <summary>The add new post.</summary>
        /// <param name="postDTO">The post dto.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        PostDTO AddNewPost(PostDTO postDTO);

        /// <summary>The add new profile.</summary>
        /// <param name="profile">The profile.</param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ProfileDTO AddNewProfile(ProfileDTO profile);

        /// <summary>The delete media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        bool DeleteMedia(Guid id);

        /// <summary>The delete post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        bool DeletePost(Guid id);

        /// <summary>The delete profile.</summary>
        /// <param name="username"></param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void DeleteProfile(string username);

        /// <summary>The enable profile.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="enabled">The enabled.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void EnableProfile(Guid profileId, bool enabled);

        /// <summary>Finds the profileSummary.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The <see cref="AboutDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        AboutDTO FindAbout(string userName);

        /// <summary>The find achievements.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="AchievementsDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        AchievementsDTO FindAchievements(string userName);

        /// <summary>The find basic info.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="BasicInfoDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        BasicInfoDTO FindBasicInfo(string userName);

        /// <summary>The find contact.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ContactDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ContactDTO FindContact(string userName);

        /// <summary>The find friend requests.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<ProfileListDTO> FindFriendRequests(string username);

        /// <summary>The find friend requests count.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        int FindFriendRequestsCount(string username);

        /// <summary>The find friends.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="List"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<ProfileListDTO> FindFriends(FindFriendsRequest request);

        /// <summary>The find living.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="LivingDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        LivingDTO FindLiving(string userName);

        /// <summary>The find media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        MediaDTO FindMedia(Guid id);

        /// <summary>The find Medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<MediaDTO> FindMedias(string username);

        /// <summary>The find post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        PostDTO FindPost(Guid id);

        /// <summary>The find posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<PostDTO> FindPosts(string username);

        /// <summary>The find profile.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ProfileDTO FindProfile(Guid profileId);

        /// <summary>Finds the profile.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        [OperationContract(Name = "FindProfileByUserName")]
        [FaultContract(typeof(ApplicationServiceError))]
        ProfileDTO FindProfile(FindProfileRequest request);

        /// <summary>The find profile picture.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfilePictureDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ProfilePictureDTO FindProfilePicture(string username);

        /// <summary>The find profile stats.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FindProfileStatsResponse"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<ProfileStatsDTO> FindProfileStats(FindProfileStatsRequest request);

        /// <summary>The find profile summary.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ProfileSummaryDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ProfileSummaryDTO FindProfileSummary(string userName);

        /// <summary>The find profiles.</summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<ProfileListDTO> FindProfiles();

        /// <summary>The find results.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ResultsDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ResultsDTO FindResults(string userName);

        /// <summary>The find resume.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="ResumeDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ResumeDTO FindResume(string userName);

        /// <summary>The find sport.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="SportDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        SportDTO FindSport(string userName);

        /// <summary>The find work edu.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="WorkEduDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        WorkEduDTO FindWorkEdu(string userName);

        /// <summary>The get profile view counter.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileCounterDTO"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        ProfileCounterDTO GetProfileViewCounter(string username);

        /// <summary>The manage friendship.</summary>
        /// <param name="request">The request.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void ManageFriendship(ManageFriendshipRequest request);

        /// <summary>The remove profile.</summary>
        /// <param name="profile">The profile.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void RemoveProfile(Guid profile);

        /// <summary>The find profiles.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="List"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<ProfileSearchResultDTO> SearchProfiles(FindProfilesRequest request);

        /// <summary>The suggest friends.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<ProfileListDTO> SuggestFriends(string username);

        /// <summary>Updates the profileSummary.</summary>
        /// <param name="about">The profileSummary.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateAbout(AboutDTO about);

        /// <summary>The update achievements.</summary>
        /// <param name="achievements">The achievements.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateAchievements(AchievementsDTO achievements);

        /// <summary>The update basic info.</summary>
        /// <param name="basicInfo">The basic info.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateBasicInfo(BasicInfoDTO basicInfo);

        /// <summary>The update contact.</summary>
        /// <param name="contact">The contact.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateContact(ContactDTO contact);

        /// <summary>The update living.</summary>
        /// <param name="living">The living.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateLiving(LivingDTO living);

        /// <summary>The update profile.</summary>
        /// <param name="profile">The profile.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateProfile(ProfileDTO profile);

        /// <summary>The update profile picture.</summary>
        /// <param name="about">The profileSummary.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateProfilePicture(ProfilePictureDTO about);

        /// <summary>The update profile summary.</summary>
        /// <param name="profileSummary">The profile summary.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateProfileSummary(ProfileSummaryDTO profileSummary);

        /// <summary>The update results.</summary>
        /// <param name="results">The results.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateResults(ResultsDTO results);

        /// <summary>The update resume.</summary>
        /// <param name="resume">The resume.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateResume(ResumeDTO resume);

        /// <summary>The update sport.</summary>
        /// <param name="sport">The sport.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateSport(SportDTO sport);

        /// <summary>The update work edu.</summary>
        /// <param name="workEdu">The work edu.</param>
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        void UpdateWorkEdu(WorkEduDTO workEdu);

        #endregion
    }
}