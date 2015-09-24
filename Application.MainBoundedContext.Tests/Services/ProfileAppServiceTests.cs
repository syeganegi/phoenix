// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileAppServiceTests.cs" company="SportWare">
//   SportWare copyright
// </copyright>
// <summary>
//   The profile app service tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Application.MainBoundedContext.Tests.Services
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;

    using Rhino.Mocks;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services;
    using Phoenix.PhoenixApp.Application.Seedwork;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Repositories;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;

    /// <summary>
    /// The profile app service tests.
    /// </summary>
    [TestClass]
    public class ProfileAppServiceTests
    {
        private MainBCUnitOfWork unitOfWork;

        private ProfileRepository profileRepository;
        private FriendshipRepository friendshipRepository;
        private DeletedProfileRepository deletedProfileRepository;

        private ProfileViewRepository profileViewRepository;

        private ProfileAppService profileAppService;

        private IProfileRepository profileRepositoryStub;

        private IProfileViewRepository profileViewRepositoryStub;

        private ProfileAppService profileAppServiceStub;
        private IFriendshipRepository friendshipRepositoryStub;
        private IDeletedProfileRepository deletedProfileRepositoryStub;

        #region Public Methods and Operators

        [TestInitialize()]
        public void Initialize()
        {
            unitOfWork = new MainBCUnitOfWork();
            profileRepository = new ProfileRepository(unitOfWork);
            profileViewRepository = new ProfileViewRepository(unitOfWork);
            friendshipRepository = new FriendshipRepository(unitOfWork);
            deletedProfileRepository = new DeletedProfileRepository(unitOfWork);
            profileAppService = new ProfileAppService(
                profileRepository, 
                profileViewRepository, 
                friendshipRepository,
                deletedProfileRepository);

            profileRepositoryStub = MockRepository.GenerateStub<IProfileRepository>();
            profileViewRepositoryStub = MockRepository.GenerateStub<IProfileViewRepository>();
            friendshipRepositoryStub = MockRepository.GenerateStub<IFriendshipRepository>();
            deletedProfileRepositoryStub = MockRepository.GenerateStub<IDeletedProfileRepository>();
            profileAppServiceStub = new ProfileAppService(
                profileRepositoryStub, profileViewRepositoryStub, friendshipRepositoryStub, deletedProfileRepositoryStub);
        }

        [TestMethod]
        public void FindProfileStatsTest()
        {
            // Arrange
            var request = new FindProfileStatsRequest
                              {
                                  Username = "jsmith",
                                  PageIndex = 0,
                                  PageSize = 10,
                                  Requester = new Requester()
                              };

            // act
            var result = this.profileAppService.FindProfileStats(request);

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// The add new profile return adapted DTO.
        /// </summary>
        [TestMethod]
        public void AddNewProfileReturnAdaptedDTO()
        {
            // Arrange

            var profileDTO = new ProfileDTO
                {
                    UserName = "username1", 
                    FirstName = "Jhon", 
                    LastName = "El rojo", 
                    Email = "j.smith@gmail.com", 
                    Sex = Gender.Male.ToString(), 
                    Birthday = new DateTime(1975, 5, 7)
                };

            // act
            ProfileDTO result = profileAppService.AddNewProfile(profileDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id != Guid.Empty);
            Assert.AreEqual(result.FirstName, profileDTO.FirstName);
            Assert.AreEqual(result.LastName, profileDTO.LastName);
        }

        /// <summary>
        /// The add new profile throw application errors when entity is not valid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationValidationErrorsException))]
        public void AddNewProfileThrowApplicationErrorsWhenEntityIsNotValid()
        {
            // Arrange

            var profileDTO = new ProfileDTO
                {
                    // missing lastname
                    UserName = "username1", 
                    FirstName = "Jhon", 
                    Email = "j.smith@gmail.com", 
                    Sex = Gender.Male.ToString(), 
                    Birthday = new DateTime(1975, 5, 7)
                };

            // act
            profileAppService.AddNewProfile(profileDTO);
        }

        /// <summary>
        /// The add new profile throw argument exception if profile email is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationValidationErrorsException))]
        public void AddNewProfileThrowArgumentExceptionIfProfileEmailIsEmpty()
        {
            // Arrange
            var profileDTO = new ProfileDTO { Email = null };

            profileAppService.AddNewProfile(profileDTO);
        }

        /// <summary>
        /// The add new profile throw exception if profile DTO is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewProfileThrowExceptionIfProfileDTOIsNull()
        {
            // Arrange

            // act
            ProfileDTO result = profileAppService.AddNewProfile(null);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// The constructor throw exception when profile repository dependency is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowExceptionWhenProfileRepositoryDependencyIsNull()
        {
            // Arrange

            // act
            new ProfileAppService(null, null, null, null);
        }

        /// <summary>
        /// The find profile materialize result if exist.
        /// </summary>
        [TestMethod]
        public void FindProfileMaterializeResultIfExist()
        {
            // Arrange

            profileRepositoryStub.Stub(x => x.Get(Guid.Empty)).IgnoreArguments().Return(this.GetTestProfile());

            // Act
            ProfileDTO result = profileAppServiceStub.FindProfile(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// The find profile return null if profile id is empty.
        /// </summary>
        [TestMethod]
        public void FindProfileReturnNullIfProfileIdIsEmpty()
        {
            // Arrange
            profileRepositoryStub.Stub(x => x.Get(Guid.Empty)).IgnoreArguments().Return(null);

            // Act
            ProfileDTO result = profileAppServiceStub.FindProfile(Guid.Empty);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// The find profiles by filter materialize results.
        /// </summary>
        [TestMethod]
        public void FindProfilesByFilterMaterializeResults()
        {
            // Arrange
            profileRepositoryStub.Stub(x => x.AllMatching(null)).IgnoreArguments().Return(
                new List<Profile> { this.GetTestProfile() });

            var request = new FindProfilesRequest { SearchText = "John", Requester = new Requester() };
            
            // Act
            var result = profileAppServiceStub.FindProfiles(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
        }

        /// <summary>
        /// The find profiles by filter return null if not data.
        /// </summary>
        [TestMethod]
        public void FindProfilesByFilterReturnNullIfNotData()
        {
            // Arrange
            profileRepositoryStub.Stub(x => x.AllMatching(null)).IgnoreArguments().Return(new List<Profile>());

            var request = new FindProfilesRequest { SearchText = "text", Requester = new Requester() };

            // Act
            var result = profileAppServiceStub.FindProfiles(request);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// The find profiles in page materialize results.
        /// </summary>
        [TestMethod]
        public void FindProfilesInPageMaterializeResults()
        {
            // Arrange
            profileRepositoryStub.Stub(x => x.GetEnabled(0, 0)).IgnoreArguments().Return(
                new List<Profile> { this.GetTestProfile() });

            // Act
            List<ProfileListDTO> result = profileAppServiceStub.FindProfiles();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
        }

        /// <summary>
        /// The find profiles in page return null if not data.
        /// </summary>
        [TestMethod]
        public void FindProfilesInPageReturnNullIfNotData()
        {
            // Arrange
            profileRepository.Stub(x => x.GetEnabled(0, 0)).IgnoreArguments().Return(new List<Profile>());

            // Act
            List<ProfileListDTO> result = profileAppServiceStub.FindProfiles();

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// The find profiles with invalid page arguments throw argument exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindProfilesWithInvalidPageArgumentsThrowArgumentException()
        {
            // Arrange

            // Act
            profileAppService.FindProfiles();
        }

        /// <summary>
        /// The remove profile set profile as disabled.
        /// </summary>
        [TestMethod]
        public void RemoveProfileSetProfileAsDisabled()
        {
            // Arrange
            Guid profileId = Guid.NewGuid();
            Profile profile = ProfileFactory.CreateProfile(
                "username1", "Jhon", "El rojo", "mail@test.com", Gender.Male, new DateTime(1975, 1, 1));
            profile.ChangeCurrentIdentity(profileId);

            var uow = MockRepository.GenerateStub<IUnitOfWork>();
            profileRepository.Stub(x => x.UnitOfWork).Return(uow);
            profileRepository.Stub(x => x.Get(profileId)).Return(profile);

            // Act
            profileAppServiceStub.RemoveProfile(profileId);

            // Assert
            Assert.IsFalse(profile.IsEnabled);
        }

        /// <summary>
        /// The update profile merge persistent and current.
        /// </summary>
        [TestMethod]
        public void UpdateProfileMergePersistentAndCurrent()
        {
            // Arrange
            Guid profileId = Guid.NewGuid();
            Profile profile = ProfileFactory.CreateProfile(
                "username1", "Jhon", "El rojo", "mail@test.com", Gender.Male, new DateTime(1975, 1, 1));
            profile.ChangeCurrentIdentity(profileId);

            var uow = MockRepository.GenerateStub<IUnitOfWork>();
            profileRepositoryStub.Stub(x => x.UnitOfWork).Return(uow);
            profileRepositoryStub.Stub(x => x.Get(profileId)).Return(profile);
            profileRepositoryStub.Stub(x => x.Merge(null, null)).IgnoreArguments().WhenCalled(
                x =>
                    {
                        Assert.AreEqual(x.Arguments[0], x.Arguments[1]);
                        Assert.IsTrue(x.Arguments[0] != null);
                        Assert.IsTrue(x.Arguments[1] != null);
                    });


            var profileDTO = new ProfileDTO { Id = profileId, FirstName = "Jhon", LastName = "El rojo", };

            // missing lastname

            // act
            profileAppServiceStub.UpdateProfile(profileDTO);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the test profile.
        /// </summary>
        /// <returns>
        /// The <see cref="Profile"/>.
        /// </returns>
        private Profile GetTestProfile()
        {
            Guid profileId = Guid.NewGuid();
            Profile profile = ProfileFactory.CreateProfile(
                "username1", "Jhon", "El rojo", "mail@test.com", Gender.Male, new DateTime(1975, 1, 1));
            profile.ChangeCurrentIdentity(profileId);

            return profile;
        }

        #endregion
    }
}