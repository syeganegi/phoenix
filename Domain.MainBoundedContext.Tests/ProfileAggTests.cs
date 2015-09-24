// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileAggTests.cs" company="">
//   
// </copyright>
// <summary>
//   The profile agg tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Domain.MainBoundedContext.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;

    /// <summary>
    /// The profile agg tests.
    /// </summary>
    [TestClass]
    public class ProfileAggTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The profile disable set is enabled to false.
        /// </summary>
        [TestMethod]
        public void ProfileDisableSetIsEnabledToFalse()
        {
            // Arrange 
            var profile = new Profile();

            // Act
            profile.Disable();

            // assert
            Assert.IsFalse(profile.IsEnabled);
        }

        /// <summary>
        /// The profile enable set is enabled to true.
        /// </summary>
        [TestMethod]
        public void ProfileEnableSetIsEnabledToTrue()
        {
            // Arrange 
            var profile = new Profile();

            // Act
            profile.Enable();

            // assert
            Assert.IsTrue(profile.IsEnabled);
        }

        /// <summary>
        /// The profile factory with create valid profile.
        /// </summary>
        [TestMethod]
        public void ProfileFactoryWithCreateValidProfile()
        {
            // Arrange
            string userName = "username1";
            string lastName = "El rojo";
            string firstName = "Jhon";
            string email = "john.Elrojo@gmail.com";
            var sex = Gender.Male;
            var dob = new DateTime(1975, 5, 7);

            // Act
            Profile profile = ProfileFactory.CreateProfile(userName, firstName, lastName, email, sex, dob);
            var validationContext = new ValidationContext(profile, null, null);
            IEnumerable<ValidationResult> validationResults = profile.Validate(validationContext);

            // Assert
            Assert.AreEqual(profile.LastName, lastName);
            Assert.AreEqual(profile.FirstName, firstName);
            Assert.AreEqual(profile.IsEnabled, true);
            Assert.AreEqual(profile.Email, email);
            Assert.AreEqual(profile.Sex, sex);
            Assert.AreEqual(profile.Birthday, dob);

            Assert.IsFalse(validationResults.Any());
        }

        /// <summary>
        /// The profile factory with default email.
        /// </summary>
        [TestMethod]
        public void ProfileFactoryWithEmail()
        {
            // Arrange
            string userName = "username1";
            string lastName = "El rojo";
            string firstName = "Jhon";
            string email = "john.Elrojo@gmail.com";
            var sex = Gender.Male;
            var dob = new DateTime(1975, 5, 7);

            // Act
            Profile profile = ProfileFactory.CreateProfile(userName, firstName, lastName, email, sex, dob);

            var validationContext = new ValidationContext(profile, null, null);
            IEnumerable<ValidationResult> validationResults = profile.Validate(validationContext);

            // Assert
            Assert.AreEqual(profile.Email, email);
            Assert.IsFalse(validationResults.Any());
        }

        /// <summary>
        /// The profile factory with empty user id.
        /// </summary>
        [TestMethod]
        public void ProfileFactoryWithEmptyUserId()
        {
            // Arrange
            string userName = string.Empty;
            string lastName = "El rojo";
            string firstName = "Jhon";
            string email = "john.Elrojo@gmail.com";
            var sex = Gender.Male;
            var dob = new DateTime(1975, 5, 7);

            // Act
            Profile profile = ProfileFactory.CreateProfile(userName, firstName, lastName, email, sex, dob);

            var validationContext = new ValidationContext(profile, null, null);
            IEnumerable<ValidationResult> validationResults = profile.Validate(validationContext);

            // Assert
            Assert.IsTrue(validationResults.Any());
        }

        /// <summary>
        /// The profile factory with invalid birthday.
        /// </summary>
        [TestMethod]
        public void ProfileFactoryWithInvalidBirthday()
        {
            // Arrange
            string userName = "username1";
            string lastName = "El rojo";
            string firstName = "Jhon";
            string email = "john.Elrojo@gmail.com";
            var sex = Gender.Male;
            var dob = new DateTime(2000, 5, 7);

            // Act
            Profile profile = ProfileFactory.CreateProfile(userName, firstName, lastName, email, sex, dob);
            var validationContext = new ValidationContext(profile, null, null);
            IEnumerable<ValidationResult> validationResults = profile.Validate(validationContext);

            // Assert
            Assert.IsTrue(validationResults.Any());
        }

        /// <summary>
        /// The profile factory with create valid profile.
        /// </summary>
        [TestMethod]
        public void ProfileViewFactoryWithCreatedValidRequest()
        {
            // Arrange
            Profile viewer = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            Profile viewed = ProfileFactory.CreateProfile(
                "username2", "John", "Smith", "j.smith@outlook.com", Gender.Female, new DateTime(1990, 12, 3));

            // Act
            ProfileView profileView = ProfileViewFactory.CreateProfileView(viewer, viewed);
            var validationContext = new ValidationContext(profileView, null, null);
            IEnumerable<ValidationResult> validationResults = profileView.Validate(validationContext);

            // Assert
            Assert.AreEqual(profileView.ViewedId, viewed.Id);
            Assert.AreEqual(profileView.ViewerId, viewer.Id);

            Assert.IsFalse(validationResults.Any());
        }

        /// <summary>
        /// The profile view factory with null viewed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProfileViewFactoryWithNullViewed()
        {
            // Arrange
            Profile viewer = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));

            // Act
            ProfileViewFactory.CreateProfileView(viewer, null);
        }

        /// <summary>
        /// The profile view factory with null viewer.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProfileViewFactoryWithNullViewer()
        {
            // Arrange
            Profile viewed = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));

            // Act
            ProfileViewFactory.CreateProfileView(null, viewed);
        }

        /// <summary>
        /// The profile view factory with same id.
        /// </summary>
        [TestMethod]
        public void ProfileViewFactoryWithSameId()
        {
            // Arrange
            Profile viewer = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            Profile viewed = ProfileFactory.CreateProfile(
                "username2", "John", "Smith", "j.smith@outlook.com", Gender.Female, new DateTime(1990, 12, 3));
            viewed.ChangeCurrentIdentity(viewer.Id);

            // Act
            ProfileView profileView = ProfileViewFactory.CreateProfileView(viewer, viewed);
            var validationContext = new ValidationContext(profileView, null, null);
            IEnumerable<ValidationResult> validationResults = profileView.Validate(validationContext);

            // Assert
            Assert.IsTrue(validationResults.Any());
        }

        #endregion
    }
}