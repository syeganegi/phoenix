// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileRepositoryTests.cs" company="">
//   
// </copyright>
// <summary>
//   The profile repository tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Data.MainBoundedContext.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Repositories;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;

    /// <summary>
    /// The profile repository tests.
    /// </summary>
    [TestClass]
    public class ProfileRepositoryTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The profile repository add new item save item.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryAddNewItemSaveItem()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            Profile profile = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            profile.AddInstanceMessage("syg66", InstanceMessageType.Yahoo);
            profile.AddInstanceMessage("s.yeganegi", InstanceMessageType.Skype);
            profile.MobilePhone = "+61410811721";
            profile.HomePhone = "+6190450570";
            profile.WorkPhone = "+6189679012";
            profile.Address = new ProfileAddress("city", "zipCode", "addressLine1", "addressLine2");

            // Act
            profileRepository.Add(profile);
            unitOfWork.Commit();
        }

        /// <summary>
        /// The profile repository all matching method return entities with satisfied criteria.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryAllMatchingMethodReturnEntitiesWithSatisfiedCriteria()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            Specification<Profile> spec = ProfileSpecifications.EnabledProfiles();

            // Act
            IEnumerable<Profile> result = profileRepository.AllMatching(spec);

            // Assert
            Assert.IsNotNull(result.All(c => c.IsEnabled));
        }

        /// <summary>
        /// The profile repository filter method return entitis with satisfied filter.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryFilterMethodReturnEntitisWithSatisfiedFilter()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            // Act
            IEnumerable<Profile> result = profileRepository.GetFiltered(c => c.FirstName.Equals("Sasan"));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(c => c.FirstName.Equals("Sasan")));
        }

        /// <summary>
        /// The profile repository get all return materialized all items.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryGetAllReturnMaterializedAllItems()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            // Act
            IEnumerable<Profile> allItems = profileRepository.GetAll();

            // Assert
            Assert.IsNotNull(allItems);
            Assert.IsTrue(allItems.Any());
        }

        /// <summary>
        /// The profile repository get enalbed return only enabled profiles.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryGetEnalbedReturnOnlyEnabledProfiles()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            // Act
            IEnumerable<Profile> result = profileRepository.GetEnabled(0, 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(c => c.IsEnabled));
        }

        /// <summary>
        /// The profile repository get method return null when id is empty.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryGetMethodReturnNullWhenIdIsEmpty()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            // Act
            Profile profile = profileRepository.Get(Guid.Empty);

            // Assert
            Assert.IsNull(profile);
        }

        /// <summary>
        /// Profiles the repository get method.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryGetMethod()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            // Act
            Profile profile = profileRepository.Get("username1");

            // Assert
            Assert.IsNotNull(profile);
            Assert.AreEqual("Sasan", profile.FirstName);
        }

        /// <summary>
        /// The profile repository get method return profile with picture.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryGetMethodReturnProfileWithPicture()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            var profileId = new Guid("d7db612b-59c3-cbd8-1243-08cf857c45e2");

            // Act
            Profile profile = profileRepository.Get(profileId);

            // Assert
            Assert.IsNotNull(profile);
            Assert.IsNotNull(profile.Picture);
            Assert.IsNotNull(profile.Picture.RawPhoto);
            Assert.IsTrue(profile.Id == profileId);
        }

        /// <summary>
        /// The profile repository paged method return entities in page fashion.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryPagedMethodReturnEntitiesInPageFashion()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            // Act
            IEnumerable<Profile> pageI = profileRepository.GetPaged(0, 1, b => b.Id, false);
            IEnumerable<Profile> pageII = profileRepository.GetPaged(1, 1, b => b.Id, false);

            // Assert
            Assert.IsNotNull(pageI);
            Assert.IsTrue(pageI.Count() == 1);

            Assert.IsNotNull(pageII);
            Assert.IsTrue(pageII.Count() == 1);

            Assert.IsFalse(pageI.Intersect(pageII).Any());
        }

        /// <summary>
        /// The profile repository remove item delete it.
        /// </summary>
        [TestMethod]
        public void ProfileRepositoryRemoveItemDeleteIt()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);

            Profile profile = ProfileFactory.CreateProfile(
                "username1", "First", "Last", "f.last@gmail.com", Gender.Male, new DateTime(1980, 6, 6));
            profile.AddInstanceMessage("f.last", InstanceMessageType.Yahoo);
            profile.AddInstanceMessage("f.last", InstanceMessageType.Twitter);
            profile.MobilePhone = "+6111111111";
            profile.HomePhone = "+6122222222";
            profile.Address = new ProfileAddress("Sydney", "2077", "408/25-31 Orara st", "WAITARA");

            profileRepository.Add(profile);
            unitOfWork.Commit();

            // Act
            profileRepository.Remove(profile);
            unitOfWork.Commit();

            Profile result = profileRepository.Get(profile.Id);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// The profile repository remove item delete it.
        /// </summary>
        [TestMethod]
        public void ProfileRepositorySearch()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);
            Specification<Profile> filter = ProfileSpecifications.ProfileFullText("Smith");
            var profile = profileRepository.AllMatching(ProfileSpecifications.ProfileFullText("Sasan")).FirstOrDefault();

            // Act
            var profileSearchResults = profileRepository.Search(profile.Id, filter.SatisfiedBy());

            // Assert
            Assert.IsNotNull(profileSearchResults);
            Assert.AreEqual(profileSearchResults.Any(), true);
        }
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // rest of initialize implementation ...
        }

        #endregion
    }
}