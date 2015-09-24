// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile management service implementation.
//   <see cref="IProfileAppService" />
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Application.Seedwork;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;

    /// <summary>
    ///     The profile management service implementation.
    ///     <see cref="IProfileAppService" />
    /// </summary>
    public class ProfileAppService : IProfileAppService
    {
        #region Fields

        /// <summary>The deleted profile repository.</summary>
        private readonly IDeletedProfileRepository deletedProfileRepository;

        /// <summary>The friendship repository.</summary>
        private readonly IFriendshipRepository friendshipRepository;

        /// <summary>
        ///     The _profile repository.
        /// </summary>
        private readonly IProfileRepository profileRepository;

        /// <summary>The profile view repository.</summary>
        private readonly IProfileViewRepository profileViewRepository;

        /// <summary>The this lock.</summary>
        private readonly object thisLock = new Object();

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ProfileAppService"/> class.
        ///     Create a new instance of Profile Management Service</summary>
        /// <param name="profileRepository">Associated ProfileRepository, intented to be resolved with DI</param>
        /// <param name="profileViewRepository">The profile View Repository.</param>
        /// <param name="friendshipRepository">The friendship Repository.</param>
        /// <param name="deletedProfileRepository">The deleted Profile Repository.</param>
        public ProfileAppService(
            IProfileRepository profileRepository, 
            IProfileViewRepository profileViewRepository, 
            IFriendshipRepository friendshipRepository, 
            IDeletedProfileRepository deletedProfileRepository)
        {
            Guard.ArgumentIsNotNull(profileRepository, "profileRepository");
            Guard.ArgumentIsNotNull(profileViewRepository, "profileViewRepository");
            Guard.ArgumentIsNotNull(friendshipRepository, "friendshipRepository");
            Guard.ArgumentIsNotNull(deletedProfileRepository, "deletedProfileRepository");

            this.profileRepository = profileRepository;
            this.profileViewRepository = profileViewRepository;
            this.friendshipRepository = friendshipRepository;
            this.deletedProfileRepository = deletedProfileRepository;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.AddNewProfile"/></summary>
        /// <param name="profileDTO"><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.AddNewProfile"/></param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        public ProfileDTO AddNewProfile(ProfileDTO profileDTO)
        {
            // check preconditions
            if (profileDTO == null)
            {
                throw new ArgumentException(Messages.warning_CannotAddProfileWithEmptyInformation);
            }

            // Create the entity and the required associated data
            var address = new ProfileAddress(
                profileDTO.AddressCity, 
                profileDTO.AddressZipCode, 
                profileDTO.AddressAddressLine1, 
                profileDTO.AddressAddressLine2);

            var sex = Gender.Unknown;
            Enum.TryParse(profileDTO.Sex, out sex);
            Profile profile = ProfileFactory.CreateProfile(
                profileDTO.UserName, 
                profileDTO.FirstName, 
                profileDTO.LastName, 
                profileDTO.Email, 
                sex, 
                profileDTO.Birthday, 
                address, 
                profileDTO.PictureRawPhoto);

            // save entity
            this.SaveProfile(profile);

            // return the data with id and assigned default values
            return profile.ProjectedAs<ProfileDTO>();
        }

        /// <summary>The delete profile.</summary>
        /// <param name="username"></param>
        public void DeleteProfile(string username)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");
            using (var scope = new TransactionScope())
            {
                Profile profile = this.profileRepository.Get(username);
                if (profile == null)
                {
                    return;
                }

                // we store a copy of deleted profile
                var deletedProfile = profile.ProjectedAs<DeletedProfile>();
                this.deletedProfileRepository.Add(deletedProfile);

                // deleting relations
                this.DeleteFriendships(profile.Id);
                this.DeleteProfileViews(profile.Id);

                // removing the profile
                this.profileRepository.Remove(profile);
                this.profileRepository.UnitOfWork.Commit();
                scope.Complete();
            }
        }

        /// <summary>
        ///     <see cref="M:System.IDisposable.Dispose" />
        /// </summary>
        public void Dispose()
        {
            // dispose all resources
            this.profileRepository.Dispose();
        }

        /// <summary>The enable profile.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="enabled">The enabled.</param>
        public void EnableProfile(Guid profileId, bool enabled)
        {
            // get persisted item
            Profile profile = this.profileRepository.Get(profileId);

            if (profile != null)
            {
                if (enabled)
                {
                    profile.Enable();
                }
                else
                {
                    profile.Disable();
                }

                // commit unit of work
                this.profileRepository.UnitOfWork.Commit();
            }
            else
            {
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingProfile);
            }
        }

        /// <summary>The find about.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="AboutDTO"/>.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public AboutDTO FindAbout(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.FindCountries"/></summary>
        /// <param name="profileId"><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.FindCountries"/></param>
        /// <returns>The <see cref="ProfileDTO"/>.</returns>
        public ProfileDTO FindProfile(Guid profileId)
        {
            // recover existing profile and map
            Profile profile = this.profileRepository.Get(profileId);

            if (profile != null)
            {
                // adapt
                return profile.ProjectedAs<ProfileDTO>();
            }

            return null;
        }

        /// <summary>Finds the profile.</summary>
        /// <param name="request">The request.</param>
        /// <returns>Selected profile representation if exist or null if not exist</returns>
        public ProfileDTO FindProfile(FindProfileRequest request)
        {
            Guard.ArgumentIsNotNull(request, "request");
            Guard.ArgumentIsNotNull(request.Requester, "request.Requester");

            if (string.IsNullOrEmpty(request.Username))
            {
                return null;
            }

            ProfileDTO dto = null;
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                Profile viewer = this.profileRepository.Get(request.Requester.UserName);
                if (viewer == null)
                {
                    // handle viewer is null
                    throw new Exception(Messages.exception_ProfileViewerWasNotFound);
                }

                // recover existing profile and map
                Profile profile = this.profileRepository.Get(request.Username);

                if (profile == null)
                {
                    throw new Exception(Messages.exception_ProfileWasNotFound);
                }

                if (request.Touch)
                {
                    ProfileView view = ProfileViewFactory.CreateProfileView(viewer, profile);
                    this.profileViewRepository.Add(view);
                    lock (this.thisLock)
                    {
                        profile.ViewCounter++;
                    }

                    this.profileViewRepository.UnitOfWork.Commit();
                }

                // get the friendship relation with the requester
                Specification<Friendship> friendSpec = FriendshipSpecifications.ExistingFriendship(
                    viewer.Id, profile.Id);
                Friendship friendship = this.friendshipRepository.GetFiltered(friendSpec.SatisfiedBy()).FirstOrDefault()
                                        ?? FriendFactory.CreateFriendship(viewer.Id, profile.Id);

                // adapt
                dto = profile.ProjectedAs<ProfileDTO>();
                dto.Friendship = friendship.ProjectedAs<FriendshipDTO>();

                transactionScope.Complete();
            }

            return dto;
        }

        /// <summary>The find profile picture.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfilePictureDTO"/>.</returns>
        public ProfilePictureDTO FindProfilePicture(string username)
        {
            // recover existing profile and map
            Profile profile = this.profileRepository.Get(username);
            if (profile != null && profile.Picture != null)
            {
                return profile.Picture.ProjectedAs<ProfilePictureDTO>();
            }

            return null;
        }

        /// <summary>The find profile stats.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="FindProfileStatsResponse"/>.</returns>
        /// <exception cref="Exception"></exception>
        public List<ProfileStatsDTO> FindProfileStats(FindProfileStatsRequest request)
        {
            Guard.ArgumentIsNotNull(request, "request");
            Guard.ArgumentIsNotNullOrEmpty(request.Username, "request.Username");

            Profile profile = this.profileRepository.Get(request.Username);
            if (profile == null)
            {
                throw new Exception(Messages.exception_ProfileWasNotFound);
            }

            Specification<ProfileView> spec = ProfileViewSpecifications.ProfileViewWithViewedId(profile.Id);

            List<ProfileView> profiles =
                this.profileViewRepository.GetFiltered(spec.SatisfiedBy())
                    .OrderByDescending(pv => pv.DateViewed)
                    .ToList();

            return profiles.Any() ? profiles.ProjectedAsCollection<ProfileStatsDTO>() : null;
        }

        /// <summary>The find profiles.</summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<ProfileListDTO> FindProfiles()
        {
            // get profiles
            IEnumerable<Profile> profiles = this.profileRepository.GetAll();

            return profiles.Any() ? profiles.ProjectedAsCollection<ProfileListDTO>() : null;
        }

        /// <summary><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.FindProfiles"/></summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<ProfileSearchResultDTO> FindProfiles(FindProfilesRequest request)
        {
            Guard.ArgumentIsNotNull(request, "request");
            Guard.ArgumentIsNotNull(request.Requester, "request.Requester");

            Profile profile = this.profileRepository.Get(request.Requester.UserName);
            if (profile == null)
            {
                throw new InvalidOperationException(Messages.exception_ProfileWasNotFound);
            }

            // get the specification
            Specification<Profile> enabledProfiles = ProfileSpecifications.EnabledProfiles();
            Specification<Profile> filter = ProfileSpecifications.ProfileFullText(request.SearchText);
            Specification<Profile> exclude = request.ExcludeRequester
                                                 ? ProfileSpecifications.ProfileNotEqual(request.Requester.UserName)
                                                 : new TrueSpecification<Profile>();

            ISpecification<Profile> spec = enabledProfiles & filter & exclude;

            // Query this criteria
            List<ProfileSearchResult> profiles = this.profileRepository.Search(profile.Id, spec.SatisfiedBy()).ToList();

            // creates empty (Unknown) friendship for those profiles which are not in the friendship relation
            profiles.ForEach(
                p =>
                    {
                        if (p.Friendship == null)
                        {
                            p.Friendship = FriendFactory.CreateFriendship(profile.Id, p.Profile.Id);
                        }
                    });
            return profiles.Any() ? profiles.ProjectedAsCollection<ProfileSearchResult, ProfileSearchResultDTO>() : null;
        }

        /// <summary>The get about.</summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="AboutDTO"/>.</returns>
        public T GetDTO<T>(string userName) where T : ProfileDTOBase, new()
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            // recover existing profile and map
            Profile profile = this.profileRepository.Get(userName);

            if (profile != null)
            {
                // adapt
                return profile.ProjectedAs<T>();
            }

            return null;
        }

        /// <summary>The get profile view counter.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="ProfileCounterDTO"/>.</returns>
        /// <exception cref="Exception"></exception>
        public ProfileCounterDTO GetProfileViewCounter(string username)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            Profile profile = this.profileRepository.Get(username);
            if (profile == null)
            {
                throw new Exception(Messages.exception_ProfileWasNotFound);
            }

            return new ProfileCounterDTO { UserName = username, Id = profile.Id, ViewCounter = profile.ViewCounter };
        }

        /// <summary><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.RemoveProfile"/></summary>
        /// <param name="profileId"><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.Seedwork.Services.IProfileManagement.RemoveProfile"/></param>
        public void RemoveProfile(Guid profileId)
        {
            Profile profile = this.profileRepository.Get(profileId);

            if (profile != null)
            {
                // if profile exist
                // disable profile ( "logical delete" ) 
                profile.Disable();

                // commit changes
                this.profileRepository.UnitOfWork.Commit();
            }
            else
            {
                // the profile not exist, cannot remove
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingProfile);
            }
        }

        /// <summary>The suggest friends.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        /// <exception cref="Exception"></exception>
        public List<ProfileListDTO> SuggestFriends(string username)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            Profile profile = this.profileRepository.Get(username);
            if (profile == null)
            {
                throw new Exception(Messages.exception_ProfileWasNotFound);
            }

            // get the specification
            Specification<Profile> filter = ProfileSpecifications.NonFriendSameSport(profile);
            Specification<Profile> exclude = ProfileSpecifications.ProfileNotEqual(profile.UserName);
            ISpecification<Profile> spec = filter & exclude;

            // Query this criteria
            List<Profile> profiles = this.profileRepository.GetFiltered(spec.SatisfiedBy()).ToList();
            List<ProfileListDTO> dto = profiles.Any() ? profiles.ProjectedAsCollection<ProfileListDTO>() : null;

            return dto;
        }

        ///// <summary>The update basic info.</summary>
        ///// <param name="dto">The dto.</param>
        ///// <exception cref="ArgumentException"></exception>
        /// <summary>The update dto.</summary>
        /// <param name="dto">The dto.</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        public void UpdateDTO<T>(T dto) where T : ProfileDTOBase
        {
            if (dto == null || string.IsNullOrEmpty(dto.UserName))
            {
                throw new ArgumentException(Messages.warning_CannotUpdateProfileWithEmptyInformation);
            }

            // get persisted item
            Profile persisted = this.profileRepository.Get(dto.UserName);

            if (persisted != null)
            {
                // Merge changes
                dto.MergeWith(persisted);

                // commit unit of work
                this.profileRepository.UnitOfWork.Commit();
            }
            else
            {
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingProfile);
            }
        }

        /// <summary><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.UpdateProfile"/></summary>
        /// <param name="profileDTO"><see cref="M:Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services.IProfileManagement.UpdateProfile"/></param>
        public void UpdateProfile(ProfileDTO profileDTO)
        {
            if (profileDTO == null || profileDTO.Id == Guid.Empty)
            {
                throw new ArgumentException(Messages.warning_CannotUpdateProfileWithEmptyInformation);
            }

            // get persisted item
            Profile persisted = this.profileRepository.Get(profileDTO.Id);

            if (persisted != null)
            {
                // if profile exist
                // materialize from profile dto
                Profile current = this.MaterializeProfileFromDto(profileDTO);

                // Merge changes
                this.profileRepository.Merge(persisted, current);

                // commit unit of work
                this.profileRepository.UnitOfWork.Commit();
            }
            else
            {
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingProfile);
            }
        }

        #endregion

        #region Methods

        /// <summary>The delete friendships.</summary>
        /// <param name="profileId">The profile id.</param>
        private void DeleteFriendships(Guid profileId)
        {
            // here we only delete friendships connected to profile via AcceptorId 
            // because there is no DELETE cascade for AcceptorId (cycles or multiple cascade paths issue)
            IEnumerable<Friendship> friendships = this.friendshipRepository.GetFiltered(f => f.AcceptorId == profileId);
            foreach (Friendship friendship in friendships)
            {
                this.friendshipRepository.Remove(friendship);
            }
        }

        /// <summary>The delete profile views.</summary>
        /// <param name="profileId">The profile id.</param>
        private void DeleteProfileViews(Guid profileId)
        {
            // here we only delete profileviews connected to profile via ViewerId 
            // because there is no DELETE cascade for ViewerId (cycles or multiple cascade paths issue)
            IEnumerable<ProfileView> profileViews =
                this.profileViewRepository.GetFiltered(pv => pv.ViewerId == profileId);
            foreach (ProfileView profileView in profileViews)
            {
                this.profileViewRepository.Remove(profileView);
            }
        }

        /// <summary>The materialize profile from dto.</summary>
        /// <param name="profileDTO">The profile dto.</param>
        /// <returns>The <see cref="Profile"/>.</returns>
        private Profile MaterializeProfileFromDto(ProfileDTO profileDTO)
        {
            // create the current instance with changes from profileDTO
            var address = new ProfileAddress(
                profileDTO.AddressCity, 
                profileDTO.AddressZipCode, 
                profileDTO.AddressAddressLine1, 
                profileDTO.AddressAddressLine2);
            var sex = Gender.Unknown;
            Enum.TryParse(profileDTO.Sex, true, out sex);
            Profile current = ProfileFactory.CreateProfile(
                profileDTO.UserName, 
                profileDTO.FirstName, 
                profileDTO.LastName, 
                profileDTO.Email, 
                sex, 
                profileDTO.Birthday, 
                address);

            // set picture
            var picture = new ProfilePicture { RawPhoto = profileDTO.PictureRawPhoto };
            picture.ChangeCurrentIdentity(current.Id);

            current.ChangePicture(picture);

            // set identity
            current.ChangeCurrentIdentity(profileDTO.Id);

            return current;
        }

        /// <summary>The save profile.</summary>
        /// <param name="profile">The profile.</param>
        /// <exception cref="ApplicationValidationErrorsException"></exception>
        private void SaveProfile(Profile profile)
        {
            // recover validator
            IEntityValidator validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(profile))
            {
                // if profile is valid
                // add the profile into the repository
                this.profileRepository.Add(profile);

                // commit the unit of work
                this.profileRepository.UnitOfWork.Commit();
            }
            else
            {
                // profile is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(profile));
            }
        }

        #endregion
    }
}