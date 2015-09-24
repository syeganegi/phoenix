// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipAggTests.cs" company="">
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
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;

    /// <summary>
    /// The profile agg tests.
    /// </summary>
    [TestClass]
    public class FriendshipAggTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The profile factory with create valid profile.
        /// </summary>
        [TestMethod]
        public void FriendRequestFactoryWithCreatedValidRequest()
        {
            // Arrange
            Profile initiator = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            Profile acceptor = ProfileFactory.CreateProfile(
                "username2", "John", "Smith", "j.smith@outlook.com", Gender.Female, new DateTime(1990, 12, 3));

            // Act
            var friendRequest = FriendFactory.CreateFriendRequest(initiator, acceptor);
            var validationContext = new ValidationContext(friendRequest, null, null);
            IEnumerable<ValidationResult> validationResults = friendRequest.Validate(validationContext);

            // Assert
            Assert.AreEqual(friendRequest.AcceptorId, acceptor.Id);
            Assert.AreEqual(friendRequest.InitiatorId, initiator.Id);
            Assert.AreEqual(friendRequest.Status, FriendshipStatus.Requested);

            Assert.IsFalse(validationResults.Any());
        }

        /// <summary>
        /// The friend request factory with null acceptor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FriendRequestFactoryWithNullAcceptor()
        {
            // Arrange
            Profile initiator = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));

            // Act
            FriendFactory.CreateFriendRequest(initiator, null);
        }

        /// <summary>
        /// The friend request factory with null initiator.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FriendRequestFactoryWithNullInitiator()
        {
            // Arrange
            Profile acceptor = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));

            // Act
            FriendFactory.CreateFriendRequest(null, acceptor);
        }

        /// <summary>
        /// The friend request factory with same id.
        /// </summary>
        [TestMethod]
        public void FriendRequestFactoryWithSameId()
        {
            // Arrange
            Profile initiator = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            Profile acceptor = ProfileFactory.CreateProfile(
                "username2", "John", "Smith", "j.smith@outlook.com", Gender.Female, new DateTime(1990, 12, 3));
            acceptor.ChangeCurrentIdentity(initiator.Id);

            // Act
            var friendRequest = FriendFactory.CreateFriendRequest(initiator, acceptor);
            var validationContext = new ValidationContext(friendRequest, null, null);
            IEnumerable<ValidationResult> validationResults = friendRequest.Validate(validationContext);

            // Assert
            Assert.IsTrue(validationResults.Any());
        }

        /// <summary>
        /// The profile factory with create valid profile.
        /// </summary>
        [TestMethod]
        public void FriendshipFactoryWithCreatedValidRequest()
        {
            // Arrange
            Profile initiator = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            Profile acceptor = ProfileFactory.CreateProfile(
                "username2", "John", "Smith", "j.smith@outlook.com", Gender.Female, new DateTime(1990, 12, 3));

            // Act
            Friendship friendship = FriendFactory.CreateFriendRequest(initiator, acceptor);
            var validationContext = new ValidationContext(friendship, null, null);
            IEnumerable<ValidationResult> validationResults = friendship.Validate(validationContext);

            // Assert
            Assert.AreEqual(friendship.AcceptorId, acceptor.Id);
            Assert.AreEqual(friendship.InitiatorId, initiator.Id);

            Assert.IsFalse(validationResults.Any());
        }

        /// <summary>
        /// The friendship factory with null friend 1.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FriendshipFactoryWithNullFriend1()
        {
            // Arrange
            Profile friend2 = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));

            // Act
            FriendFactory.CreateFriendRequest(null, friend2);
        }

        /// <summary>
        /// The friendship factory with null friend 2.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FriendshipFactoryWithNullFriend2()
        {
            // Arrange
            Profile friend1 = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));

            // Act
            FriendFactory.CreateFriendRequest(friend1, null);
        }

        /// <summary>
        /// The friendship factory with same id.
        /// </summary>
        [TestMethod]
        public void FriendshipFactoryWithSameId()
        {
            // Arrange
            Profile friend1 = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            Profile friend2 = ProfileFactory.CreateProfile(
                "username2", "John", "Smith", "j.smith@outlook.com", Gender.Female, new DateTime(1990, 12, 3));
            friend2.ChangeCurrentIdentity(friend1.Id);

            // Act
            Friendship friendship = FriendFactory.CreateFriendRequest(friend1, friend2);
            var validationContext = new ValidationContext(friendship, null, null);
            IEnumerable<ValidationResult> validationResults = friendship.Validate(validationContext);

            // Assert
            Assert.IsTrue(validationResults.Any());
        }

        #endregion
    }
}