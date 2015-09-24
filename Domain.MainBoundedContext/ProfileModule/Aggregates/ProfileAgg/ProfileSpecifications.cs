// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileSpecifications.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   A list of Profile specifications. You can learn
//   about Specifications, Enhanced Query Objects or repository methods
//   reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;
    using System.Linq;

    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;

    /// <summary>
    ///     A list of Profile specifications. You can learn
    ///     about Specifications, Enhanced Query Objects or repository methods
    ///     reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
    /// </summary>
    public static class ProfileSpecifications
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Enabled Profiles specification
        /// </summary>
        /// <returns>Asociated specification for this criteria</returns>
        public static Specification<Profile> EnabledProfiles()
        {
            return new DirectSpecification<Profile>(c => c.IsEnabled);
        }

        /// <summary>Profile with firstName or LastName equal to <paramref name="text"/></summary>
        /// <param name="text">The firstName or lastName to find</param>
        /// <returns>Associated specification for this creterion</returns>
        public static Specification<Profile> ProfileFullText(string text)
        {
            Specification<Profile> specification = new DirectSpecification<Profile>(c => c.IsEnabled);

            if (!string.IsNullOrWhiteSpace(text))
            {
                var firstNameSpec = new DirectSpecification<Profile>(c => c.FirstName.ToLower().Contains(text));
                var lastNameSpec = new DirectSpecification<Profile>(c => c.LastName.ToLower().Contains(text));
                var sportSpec = new DirectSpecification<Profile>(c => c.Sport.ToLower().Contains(text));

                specification &= firstNameSpec || lastNameSpec || sportSpec;
            }

            return specification;
        }

        public static Specification<Profile> NonFriendSameSport(Profile profile)
        {
            Specification<Profile> specification = new DirectSpecification<Profile>(c => c.IsEnabled);

            Specification<Profile> sportSpec;
            if (!string.IsNullOrWhiteSpace(profile.Sport))
            {
                sportSpec =
                    new DirectSpecification<Profile>(
                        c => c.Sport.Equals(profile.Sport, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                sportSpec = new TrueSpecification<Profile>();
            }

            var nonFriendSpec =
                new DirectSpecification<Profile>(c => c.Initiators.All(i => i.AcceptorId != profile.Id) &&
            c.Acceptors.All(i => i.InitiatorId != profile.Id));
            specification &= sportSpec & nonFriendSpec;

            return specification;
        }

        /// <summary>The profile not equal.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="Specification"/>.</returns>
        public static Specification<Profile> ProfileNotEqual(string username)
        {
            Specification<Profile> specification = new TrueSpecification<Profile>();

            if (!string.IsNullOrWhiteSpace(username))
            {
                var notUserNameSpec =
                    new DirectSpecification<Profile>(
                        c => !c.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

                specification &= notUserNameSpec;
            }

            return specification;
        }

        #endregion
    }
}