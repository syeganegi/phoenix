// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileMvcService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The ProfileMvcService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services
{
    using System;
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin;

    /// <summary>The ProfileMvcService interface.</summary>
    public interface IProfileMvcService : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>The add new media.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="MediaModel"/>.</returns>
        MediaModel AddNewMedia(MediaModel model);

        /// <summary>The add new post.</summary>
        /// <param name="model">The adminModel.</param>
        /// <returns>The <see cref="PostModel"/>.</returns>
        PostModel AddNewPost(PostModel model);

        /// <summary>The delete media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool DeleteMedia(Guid id);

        /// <summary>The delete post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool DeletePost(Guid id);

        /// <summary>The delete profile.</summary>
        /// <param name="username">The username.</param>
        void DeleteProfile(string username);

        /// <summary>The delete profile admin.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentUsername">The current username.</param>
        void DeleteProfileAdmin(string username, string currentUsername);

        /// <summary>The find profiles.</summary>
        /// <param name="text">The text.</param>
        /// <param name="excludeRequester">The exclude Requester.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        ProfileSearchResultModel FindProfiles(string text, bool excludeRequester = true);

        /// <summary>The get about adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="AboutModel"/>.</returns>
        AboutModel GetAboutModel(string username);

        /// <summary>The get achievements adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="AchievementsModel"/>.</returns>
        AchievementsModel GetAchievementsModel(string username);

        /// <summary>The get basic info adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="BasicInfoModel"/>.</returns>
        BasicInfoModel GetBasicInfoModel(string username);

        /// <summary>The get contact adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ContactModel"/>.</returns>
        ContactModel GetContactModel(string username);

        /// <summary>The get living adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="LivingModel"/>.</returns>
        LivingModel GetLivingModel(string username);

        /// <summary>The get medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="MediasModel"/>.</returns>
        MediasModel GetMedias(string username);

        /// <summary>The get posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="PostModel[]"/>.</returns>
        PostsModel GetPosts(string username);

        /// <summary>The get profile admin.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ProfileAdminModel"/>.</returns>
        ProfileAdminModel GetProfileAdmin(string id);

        /// <summary>The get profile counter adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileCounterModel"/>.</returns>
        ProfileCounterModel GetProfileCounterModel(string username);

        /// <summary>The get profile list admin.</summary>
        /// <returns>
        ///     The <see cref="ProfileListAdminModel" />.
        /// </returns>
        ProfileListAdminModel GetProfileListAdmin();

        /// <summary>The get profile adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <param name="touch">The touch.</param>
        /// <returns>The <see cref="ProfilePageModel"/>.</returns>
        ProfilePageModel GetProfileModel(string username, bool touch = false);

        /// <summary>The get profile picture.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="byte[]"/>.</returns>
        byte[] GetProfilePicture(string username);

        /// <summary>The get profile picture adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfilePictureModel"/>.</returns>
        ProfilePictureModel GetProfilePictureModel(string username);

        /// <summary>The get profile principal.</summary>
        /// <param name="name">The name.</param>
        /// <returns>The <see cref="ProfilePrincipal"/>.</returns>
        ProfilePrincipal GetProfilePrincipal(string name);

        /// <summary>The get profile stats adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileStatsModel[]"/>.</returns>
        ProfileStatsModel[] GetProfileStatsModel(string username);

        /// <summary>The get profile summary adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileSummaryModel"/>.</returns>
        ProfileSummaryModel GetProfileSummaryModel(string username);

        /// <summary>The get results adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ResultsModel"/>.</returns>
        ResultsModel GetResultsModel(string username);

        /// <summary>The get resume adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ResumeModel"/>.</returns>
        ResumeModel GetResumeModel(string username);

        /// <summary>The get sport adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="SportModel"/>.</returns>
        SportModel GetSportModel(string username);

        /// <summary>The get work education adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="WorkEduModel"/>.</returns>
        WorkEduModel GetWorkEduModel(string username);

        /// <summary>The suggest friends.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileModel[]"/>.</returns>
        ProfileModel[] SuggestFriends(string username);

        /// <summary>The update about.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateAbout(AboutModel model);

        /// <summary>The update achievements.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateAchievements(AchievementsModel model);

        /// <summary>The update basic info.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateBasicInfo(BasicInfoModel model);

        /// <summary>The update contact.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateContact(ContactModel model);

        /// <summary>The update living.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateLiving(LivingModel model);

        /// <summary>The update profile admin.</summary>
        /// <param name="adminModel">The admin model.</param>
        void UpdateProfileAdmin(ProfileAdminModel adminModel);

        /// <summary>The update profile picture.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateProfilePicture(ProfilePictureModel model);

        /// <summary>The update profile summary.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateProfileSummary(ProfileSummaryModel model);

        /// <summary>The update results.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateResults(ResultsModel model);

        /// <summary>The update resume.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateResume(ResumeModel model);

        /// <summary>The update sport.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateSport(SportModel model);

        /// <summary>The update work education.</summary>
        /// <param name="model">The adminModel.</param>
        void UpdateWorkEdu(WorkEduModel model);

        #endregion
    }
}