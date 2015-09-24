// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriedshipRepositoryTests.cs" company="">
//   
// </copyright>
// <summary>
//   The friend request repository tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Data.MainBoundedContext.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Repositories;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;

    /// <summary>
    /// The friend request repository tests.
    /// </summary>
    [TestClass]
    public class FriendshipRepositoryTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// Friends the request repository add friend request save item.
        /// </summary>
        [TestMethod]
        public void FriendshipRepositoryAddFriendshipSaveItem()
        {
            // Arrange
            var unitOfWork = new MainBCUnitOfWork();
            var profileRepository = new ProfileRepository(unitOfWork);
            var friendshipRepository = new FriendshipRepository(unitOfWork);

            Profile initiator = profileRepository.Get(new Guid("d7db612b-59c3-cbd8-1243-08cf857c45e2"));
            Profile acceptor = profileRepository.Get(new Guid("6e1b40eb-64f4-c275-8787-08cf857c45e2"));

            // Act
            Friendship friendship = FriendFactory.CreateFriendRequest(initiator, acceptor);
            friendshipRepository.Add(friendship);
            unitOfWork.Commit();
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