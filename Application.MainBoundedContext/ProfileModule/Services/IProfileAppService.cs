// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   This is the contract that the profile will interact to perform various operations.
//   The responsability of this contract is to orchestrate operations, check security, cache,
//   adapt entities to DTO etc
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging;

    /// <summary>
    ///     This is the contract that the profile will interact to perform various operations.
    ///     The responsability of this contract is to orchestrate operations, check security, cache,
    ///     adapt entities to DTO etc
    /// </summary>
    public interface IProfileAppService : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>Add new profile </summary>
        /// <param name="profileDTO">The profile information</param>
        /// <returns>Added profile representation</returns>
        ProfileDTO AddNewProfile(ProfileDTO profileDTO);

        /// <summary>The delete profile.</summary>
        /// <param name="username"></param>
        void DeleteProfile(string username);

        /// <summary>The enable profile.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="enabled">The enabled.</param>
        void EnableProfile(Guid profileId, bool enabled);

        /// <summary>Find profile</summary>
        /// <param name="profileId">The profile identifier</param>
        /// <returns>Selected profile representation if exist or null if not exist</returns>
        ProfileDTO FindProfile(Guid profileId);

        /// <summary>Finds the profile.</summary>
        /// <param name="request">The request.</param>
        /// <returns>Selected profile representation if exist or null if not exist</returns>
        ProfileDTO FindProfile(FindProfileRequest request);

        /// <summary>The find profile picture.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfilePictureDTO"/>.</returns>
        ProfilePictureDTO FindProfilePicture(string username);

        /// <summary>The find profile stats.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FindProfileStatsResponse"/>.</returns>
        List<ProfileStatsDTO> FindProfileStats(FindProfileStatsRequest request);

        /// <summary>The find profiles.</summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        List<ProfileListDTO> FindProfiles();

        /// <summary>Find profiles with contain specific sport in
        ///     firstname or lastname</summary>
        /// <param name="request">The request.</param>
        /// <returns>A collection of profile representation</returns>
        List<ProfileSearchResultDTO> FindProfiles(FindProfilesRequest request);

        /// <summary>The get dto.</summary>
        /// <param name="userName">The user name.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        T GetDTO<T>(string userName) where T : ProfileDTOBase, new();

        /// <summary>The get profile view counter.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileCounterDTO"/>.</returns>
        ProfileCounterDTO GetProfileViewCounter(string username);

        /// <summary>Remove existing profile</summary>
        /// <param name="profileId">The profile identifier</param>
        void RemoveProfile(Guid profileId);

        /// <summary>The suggest friends.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        List<ProfileListDTO> SuggestFriends(string username);

        /// <summary>The update dto.</summary>
        /// <param name="dto">The dto.</param>
        /// <typeparam name="T"></typeparam>
        void UpdateDTO<T>(T dto) where T : ProfileDTOBase;

        /// <summary>Update existing profile</summary>
        /// <param name="profileDTO">The profile dto with changes</param>
        void UpdateProfile(ProfileDTO profileDTO);

        #endregion
    }
}