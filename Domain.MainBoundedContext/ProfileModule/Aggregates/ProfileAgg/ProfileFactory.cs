// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileFactory.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   This is the factory for Profile creation, which means that the main purpose
//   is to encapsulate the creation knowledge.
//   What is created is a transient entity instance, with nothing being said about persistence as yet
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;

    /// <summary>
    ///     This is the factory for Profile creation, which means that the main purpose
    ///     is to encapsulate the creation knowledge.
    ///     What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class ProfileFactory
    {
        #region Public Methods and Operators

        /// <summary>Create a new transient Profile</summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="firstName">The Profile firstName</param>
        /// <param name="lastName">The Profile lastName</param>
        /// <param name="email">The email.</param>
        /// <param name="sex">The sex.</param>
        /// <param name="dob">The dob.</param>
        /// <param name="address">The address.</param>
        /// <param name="rawPhoto">The raw picture.</param>
        /// <returns>A valid Profile</returns>
        public static Profile CreateProfile(
            string userName, 
            string firstName, 
            string lastName, 
            string email, 
            Gender sex, 
            DateTime dob, 
            ProfileAddress address = null, 
            byte[] rawPhoto = null)
        {
            // create new instance and set identity
            var profile = new Profile
                              {
                                  UserName = userName, 
                                  FirstName = firstName, 
                                  LastName = lastName, 
                                  Sex = sex, 
                                  Birthday = dob, 
                                  Email = email, 
                                  ViewCounter = 0, 
                                  Address =
                                      address
                                      ?? new ProfileAddress(
                                             string.Empty, string.Empty, string.Empty, string.Empty)
                              };

            // Profile is enabled by default
            profile.GenerateNewIdentity();
            profile.Enable();

            // set default picture
            var picture = new ProfilePicture { RawPhoto = rawPhoto };
            picture.ChangeCurrentIdentity(profile.Id);
            profile.ChangePicture(picture);

            return profile;
        }

        #endregion
    }
}