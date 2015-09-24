// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileMvcService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile mvc service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Transactions;
    using System.Web.Security;

    using Microsoft.Web.WebPages.OAuth;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;
    using Phoenix.PhoenixApp.Presentation.MVC.Common.Helpers;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Mappers;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Resources;
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    using WebMatrix.WebData;

    /// <summary>The profile mvc service.</summary>
    public class ProfileMvcService : IProfileMvcService
    {
        #region Fields

        /// <summary>The profile client.</summary>
        private readonly ProfileModuleServiceClient profileClient;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfileMvcService" /> class.
        /// </summary>
        public ProfileMvcService()
        {
            this.profileClient = new ProfileModuleServiceClient();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The add new media.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="MediaModel"/>.</returns>
        public MediaModel AddNewMedia(MediaModel model)
        {
            var dto = model.ProjectedAs<MediaDTO>();
            dto = this.profileClient.AddNewMedia(dto);
            return dto.ConvertToModel();
        }

        /// <summary>The add new post.</summary>
        /// <param name="model">The adminModel.</param>
        /// <returns>The <see cref="PostModel"/>.</returns>
        public PostModel AddNewPost(PostModel model)
        {
            var dto = model.ProjectedAs<PostDTO>();
            dto = this.profileClient.AddNewPost(dto);
            return dto.ConvertToModel();
        }

        /// <summary>The delete media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeleteMedia(Guid id)
        {
            return this.profileClient.DeleteMedia(id);
        }

        /// <summary>The delete post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeletePost(Guid id)
        {
            return this.profileClient.DeletePost(id);
        }

        /// <summary>The delete profile.</summary>
        /// <param name="username">The username.</param>
        public void DeleteProfile(string username)
        {
            this.DeleteProfileAndAccount(username);
        }

        /// <summary>The delete profile admin.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentUsername">The current username.</param>
        /// <exception cref="Exception"></exception>
        public void DeleteProfileAdmin(string username, string currentUsername)
        {
            if (username.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(Messages.error_Cannot_delete_current_profile);
            }

            this.DeleteProfileAndAccount(username);
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

        /// <summary>The find profiles.</summary>
        /// <param name="text">The text.</param>
        /// <param name="excludeRequester">The exclude requester.</param>
        /// <returns>The <see cref="ProfileSearchResultModel[]"/>.</returns>
        public ProfileSearchResultModel FindProfiles(string text, bool excludeRequester = true)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    // Empty result
                    return new ProfileSearchResultModel { SearchResults = new ProfileSearchResult[0] };
                }

                var request = new FindProfilesRequest
                                  {
                                      SearchText = text, 
                                      ExcludeRequester = excludeRequester, 
                                      Requester = RequesterFactory.CreateRequest()
                                  };
                ProfileSearchResultDTO[] dto = this.profileClient.SearchProfiles(request);
                return new ProfileSearchResultModel
                           {
                               SearchResults =
                                   dto != null
                                       ? dto.ConvertToModel()
                                       : new ProfileSearchResult[0]
                           };
            }
            catch (FaultException<ServiceError> e)
            {
                // TODO: handle ErrorMessage list in a proper way
                throw new ServiceAgentException(e.Detail.ErrorMessage[0]);
            }
        }

        /// <summary>The get about adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="AboutModel"/>.</returns>
        public AboutModel GetAboutModel(string username)
        {
            AboutDTO dto = this.profileClient.FindAbout(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get achievements adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="AchievementsModel"/>.</returns>
        public AchievementsModel GetAchievementsModel(string username)
        {
            AchievementsDTO dto = this.profileClient.FindAchievements(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get basic info adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="BasicInfoModel"/>.</returns>
        public BasicInfoModel GetBasicInfoModel(string username)
        {
            BasicInfoDTO dto = this.profileClient.FindBasicInfo(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get contact adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ContactModel"/>.</returns>
        public ContactModel GetContactModel(string username)
        {
            ContactDTO dto = this.profileClient.FindContact(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get living adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="LivingModel"/>.</returns>
        public LivingModel GetLivingModel(string username)
        {
            LivingDTO dto = this.profileClient.FindLiving(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="MediasModel"/>.</returns>
        public MediasModel GetMedias(string username)
        {
            MediaDTO[] medias = this.profileClient.FindMedias(username);
            return new MediasModel { Medias = medias.ConvertToModel(), UserName = username };
        }

        /// <summary>The get posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="PostsModel"/>.</returns>
        public PostsModel GetPosts(string username)
        {
            PostDTO[] posts = this.profileClient.FindPosts(username);
            return new PostsModel { Posts = posts.ConvertToModel(), UserName = username };
        }

        /// <summary>The get profile admin.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ProfileAdminModel"/>.</returns>
        public ProfileAdminModel GetProfileAdmin(string id)
        {
            Guid profileId;
            Guid.TryParse(id, out profileId);
            ProfileDTO dto = this.profileClient.FindProfile(profileId);

            return dto.ConvertToAdminModel();
        }

        /// <summary>The get profile counter adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileCounterModel"/>.</returns>
        public ProfileCounterModel GetProfileCounterModel(string username)
        {
            ProfileCounterDTO dto = this.profileClient.GetProfileViewCounter(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get profile list admin.</summary>
        /// <returns>
        ///     The <see cref="ProfileListAdminModel" />.
        /// </returns>
        public ProfileListAdminModel GetProfileListAdmin()
        {
            ProfileListDTO[] dtos = this.profileClient.FindProfiles();
            return new ProfileListAdminModel { Profiles = dtos.ConvertToAdminModel() };
        }

        /// <summary>The get profile adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <param name="touch">The touch.</param>
        /// <returns>The <see cref="ProfilePageModel"/>.</returns>
        public ProfilePageModel GetProfileModel(string username, bool touch = false)
        {
            var request = new FindProfileRequest
                              {
                                  Username = username, 
                                  Id = Guid.Empty, 
                                  Requester = RequesterFactory.CreateRequest(), 
                                  Touch = touch
                              };
            ProfileDTO dto = this.profileClient.FindProfileByUserName(request);

            // adds the profile picture to the cache
            if (dto != null)
            {
                this.SetProfilePictureCache(username, dto.PictureRawPhoto);
            }

            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get profile picture.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="byte[]"/>.</returns>
        public byte[] GetProfilePicture(string username)
        {
            var picture = CacheHelper.Get<byte[]>(username);
            if (picture == null || picture.Length == 0)
            {
                ProfilePictureDTO dto = this.profileClient.FindProfilePicture(username);
                if (dto != null)
                {
                    picture = dto.RawPhoto;
                    this.SetProfilePictureCache(username, picture);
                }
            }

            if (picture == null || picture.Length == 0)
            {
                picture = PictureHelper.GetDefaultNoImage();
            }

            return picture;
        }

        /// <summary>The get profile picture adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfilePictureModel"/>.</returns>
        public ProfilePictureModel GetProfilePictureModel(string username)
        {
            ProfilePictureDTO dto = this.profileClient.FindProfilePicture(username);

            // adds the profile picture to the cache
            if (dto != null)
            {
                this.SetProfilePictureCache(username, dto.RawPhoto);
            }

            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get profile principal.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfilePrincipal"/>.</returns>
        public ProfilePrincipal GetProfilePrincipal(string username)
        {
            var request = new FindProfileRequest
                              {
                                  Requester = RequesterFactory.CreateRequest(), 
                                  Touch = false, 
                                  Username = username
                              };
            ProfileDTO dto = this.profileClient.FindProfileByUserName(request);
            ProfilePrincipal profilePrincipal = dto != null ? dto.ConvertToPrincipal() : null;
            return profilePrincipal;
        }

        /// <summary>The get profile stats adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileStatsModel[]"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ProfileStatsModel[] GetProfileStatsModel(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return new ProfileStatsModel[0];
            }

            var request = new FindProfileStatsRequest
                              {
                                  Username = username, 
                                  PageIndex = 0, 
                                  PageSize = 10, 
                                  Requester = RequesterFactory.CreateRequest()
                              };
            ProfileStatsDTO[] profileStats = this.profileClient.FindProfileStats(request);
            if (profileStats == null)
            {
                return new ProfileStatsModel[0];
            }

            return profileStats.ConvertToModel();
        }

        /// <summary>The get profile summary adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileSummaryModel"/>.</returns>
        public ProfileSummaryModel GetProfileSummaryModel(string username)
        {
            ProfileSummaryDTO dto = this.profileClient.FindProfileSummary(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get results adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ResultsModel"/>.</returns>
        public ResultsModel GetResultsModel(string username)
        {
            ResultsDTO dto = this.profileClient.FindResults(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get resume adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ResumeModel"/>.</returns>
        public ResumeModel GetResumeModel(string username)
        {
            ResumeDTO dto = this.profileClient.FindResume(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get sport adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="SportModel"/>.</returns>
        public SportModel GetSportModel(string username)
        {
            SportDTO dto = this.profileClient.FindSport(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The get work edu adminModel.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="WorkEduModel"/>.</returns>
        public WorkEduModel GetWorkEduModel(string username)
        {
            WorkEduDTO dto = this.profileClient.FindWorkEdu(username);
            return dto != null ? dto.ConvertToModel() : null;
        }

        /// <summary>The suggest friends.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileModel[]"/>.</returns>
        public ProfileModel[] SuggestFriends(string username)
        {
            ProfileListDTO[] dto = this.profileClient.SuggestFriends(username);
            return dto.ConvertToModel();
        }

        /// <summary>The update about.</summary>
        /// <param name="model">The about adminModel.</param>
        public void UpdateAbout(AboutModel model)
        {
            var dto = model.ProjectedAs<AboutDTO>();
            this.profileClient.UpdateAbout(dto);
        }

        /// <summary>The update achievements.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateAchievements(AchievementsModel model)
        {
            var dto = model.ProjectedAs<AchievementsDTO>();
            this.profileClient.UpdateAchievements(dto);
        }

        /// <summary>The update basic info.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateBasicInfo(BasicInfoModel model)
        {
            var dto = model.ProjectedAs<BasicInfoDTO>();
            this.profileClient.UpdateBasicInfo(dto);
        }

        /// <summary>The update contact.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateContact(ContactModel model)
        {
            var dto = model.ProjectedAs<ContactDTO>();
            this.profileClient.UpdateContact(dto);
        }

        /// <summary>The update living.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateLiving(LivingModel model)
        {
            var dto = model.ProjectedAs<LivingDTO>();
            this.profileClient.UpdateLiving(dto);
        }

        /// <summary>The update profile admin.</summary>
        /// <param name="adminModel">The admin model.</param>
        public void UpdateProfileAdmin(ProfileAdminModel adminModel)
        {
            Guid profileId;
            Guid.TryParse(adminModel.Id, out profileId);
            using (var scope = new TransactionScope())
            {
                this.profileClient.EnableProfile(profileId, adminModel.IsEnabled);
                this.UpdateUser(adminModel.UserName, adminModel.IsEnabled);
                scope.Complete();
            }
        }

        /// <summary>The update profile picture.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateProfilePicture(ProfilePictureModel model)
        {
            var dto = model.ProjectedAs<ProfilePictureDTO>();
            this.profileClient.UpdateProfilePicture(dto);
        }

        /// <summary>The update profile summary.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateProfileSummary(ProfileSummaryModel model)
        {
            var dto = model.ProjectedAs<ProfileSummaryDTO>();
            this.profileClient.UpdateProfileSummary(dto);
        }

        /// <summary>The update results.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateResults(ResultsModel model)
        {
            var dto = model.ProjectedAs<ResultsDTO>();
            this.profileClient.UpdateResults(dto);
        }

        /// <summary>The update resume.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateResume(ResumeModel model)
        {
            var dto = model.ProjectedAs<ResumeDTO>();
            this.profileClient.UpdateResume(dto);
        }

        /// <summary>The update sport.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateSport(SportModel model)
        {
            var dto = model.ProjectedAs<SportDTO>();
            this.profileClient.UpdateSport(dto);
        }

        /// <summary>The update work edu.</summary>
        /// <param name="model">The adminModel.</param>
        public void UpdateWorkEdu(WorkEduModel model)
        {
            var dto = model.ProjectedAs<WorkEduDTO>();
            this.profileClient.UpdateWorkEdu(dto);
        }

        #endregion

        #region Methods

        /// <summary>The delete profile and account.</summary>
        /// <param name="username">The username.</param>
        private void DeleteProfileAndAccount(string username)
        {
            using (var scope = new TransactionScope())
            {
                this.profileClient.DeleteProfile(username);
                string[] roles = Roles.GetRolesForUser(username);
                if (roles != null && roles.Any())
                {
                    Roles.RemoveUserFromRoles(username, roles);
                }

                // removing oauth account if any
                ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(username);
                if (accounts != null && accounts.Any())
                {
                    foreach (OAuthAccount account in accounts)
                    {
                        OAuthWebSecurity.DeleteAccount(account.Provider, account.ProviderUserId);
                    }
                }

                // removing user & account
                ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(username);
                Membership.Provider.DeleteUser(username, true);
                scope.Complete();
            }
        }

        /// <summary>The set profile picture cache.</summary>
        /// <param name="key">The key.</param>
        /// <param name="picture">The picture.</param>
        private void SetProfilePictureCache(string key, byte[] picture)
        {
            CacheHelper.Add(picture, key, 30);
        }

        /// <summary>The update user.</summary>
        /// <param name="username">The username.</param>
        /// <param name="enabled">The enabled.</param>
        private void UpdateUser(string username, bool enabled)
        {
            using (var db = new UsersContext())
            {
                UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == username);
                if (user == null)
                {
                    return;
                }

                user.IsEnabled = enabled;
                db.SaveChanges();
            }
        }

        #endregion
    }
}