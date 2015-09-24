// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileAdaperTests.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Application.MainBoundedContext.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    ///     The profile adaper tests.
    /// </summary>
    [TestClass]
    public class ProfileAdaperTests
    {
        #region Public Methods and Operators

        /// <summary>The contact dto to profile adapt.</summary>
        [TestMethod]
        public void ContactDTOToProfileAdapt()
        {
            // Arrange
            var dto = new ContactDTO { MobilePhone = "6112345678" };
            var address = new ProfileAddress("Monforte", "27400", "AddressLine1", "AddressLine2");

            Profile profile = ProfileFactory.CreateProfile(
                userName: "username1", 
                firstName: "Ali", 
                lastName: "Mohammad", 
                email: "al@gmail.com", 
                sex: Gender.Male, 
                dob: new DateTime(1985, 1, 1));
            profile.Address = address;
            var picture = new ProfilePicture { RawPhoto = new byte[0] { } };

            profile.ChangePicture(picture);

            // Act
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            adapter.Adapt(dto, profile);

            // Assert
            Assert.AreEqual(profile.MobilePhone, "6112345678");
        }

        /// <summary>
        ///     The profile enumerable to profile list dto list adapt.
        /// </summary>
        [TestMethod]
        public void ProfileEnumerableToProfileListDTOListAdapt()
        {
            // Arrange
            var address = new ProfileAddress("Monforte", "27400", "AddressLine1", "AddressLine2");

            Profile profile = ProfileFactory.CreateProfile(
                userName: "username1", 
                firstName: "Ali", 
                lastName: "Mohammad", 
                email: "al@gmail.com", 
                sex: Gender.Male, 
                dob: new DateTime(1985, 1, 1));
            profile.Address = address;
            var picture = new ProfilePicture { RawPhoto = new byte[0] { } };

            profile.ChangePicture(picture);

            IEnumerable<Profile> profiles = new List<Profile> { profile };

            // Act
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();

            List<ProfileListDTO> dtos = adapter.Adapt<IEnumerable<Profile>, List<ProfileListDTO>>(profiles);

            // Assert
            Assert.IsNotNull(dtos);
            Assert.IsTrue(dtos.Any());
            Assert.IsTrue(dtos.Count == 1);

            ProfileListDTO dto = dtos[0];

            Assert.AreEqual(profile.Id, dto.Id);
            Assert.AreEqual(profile.FirstName, dto.FirstName);
            Assert.AreEqual(profile.LastName, dto.LastName);
            Assert.AreEqual("Male", dto.Sex);
            Assert.AreEqual(profile.Email, dto.Email);
            Assert.AreEqual(profile.Birthday, dto.Birthday);
        }

        /// <summary>
        ///     The profile to profile dto adapt.
        /// </summary>
        [TestMethod]
        public void ProfileToProfileDTOAdapt()
        {
            // Arrange
            var address = new ProfileAddress("Monforte", "27400", "AddressLine1", "AddressLine2");

            Profile profile = ProfileFactory.CreateProfile(
                userName: "username1", 
                firstName: "Ali", 
                lastName: "Mohammad", 
                email: "al@gmail.com", 
                sex: Gender.Male, 
                dob: new DateTime(1985, 1, 1));
            profile.Address = address;
            var picture = new ProfilePicture { RawPhoto = new byte[0] { } };

            profile.ChangePicture(picture);

            // Act
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            ProfileDTO dto = adapter.Adapt<Profile, ProfileDTO>(profile);

            // Assert
            Assert.AreEqual(profile.Id, dto.Id);
            Assert.AreEqual(profile.FirstName, dto.FirstName);
            Assert.AreEqual(profile.LastName, dto.LastName);
            Assert.AreEqual("Male", dto.Sex);
            Assert.AreEqual(profile.Email, dto.Email);
            Assert.AreEqual(profile.Birthday, dto.Birthday);

            Assert.AreEqual(profile.Address.City, dto.AddressCity);
            Assert.AreEqual(profile.Address.ZipCode, dto.AddressZipCode);
            Assert.AreEqual(profile.Address.AddressLine1, dto.AddressAddressLine1);
            Assert.AreEqual(profile.Address.AddressLine2, dto.AddressAddressLine2);
        }

        /// <summary>The string to sex adapt.</summary>
        [TestMethod]
        public void StringToSexAdapt()
        {
            string dto = "Male";

            // Act
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            Gender phoneType = adapter.Adapt<string, Gender>(dto);

            // Assert
            Assert.IsNotNull(phoneType);
            Assert.AreEqual(phoneType, Gender.Male);
        }

        #endregion
    }
}