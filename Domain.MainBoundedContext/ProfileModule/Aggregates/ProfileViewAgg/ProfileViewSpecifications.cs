// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileViewSpecifications.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   A list of ProfileView specifications. You can learn
//   about Specifications, Enhanced Query Objects or repository methods
//   reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;

    /// <summary>
    ///     A list of ProfileView specifications. You can learn
    ///     about Specifications, Enhanced Query Objects or repository methods
    ///     reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
    /// </summary>
    public static class ProfileViewSpecifications
    {
        #region Public Methods and Operators

        /// <summary>ProfileView with viewedId <paramref name="id"/></summary>
        /// <param name="id">The id to find</param>
        /// <returns>Associated specification for this creterion</returns>
        public static Specification<ProfileView> ProfileViewWithViewedId(Guid id)
        {
            Specification<ProfileView> specification = new DirectSpecification<ProfileView>(p => p.ViewedId == id);

            return specification;
        }

        #endregion
    }
}