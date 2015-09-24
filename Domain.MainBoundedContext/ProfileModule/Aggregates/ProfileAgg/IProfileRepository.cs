// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     Base contract for product repository
    ///     <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{Profile}" />
    /// </summary>
    public interface IProfileRepository : IRepository<Profile>
    {
        #region Public Methods and Operators

        /// <summary>Gets the specified user name.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The profile</returns>
        Profile Get(string userName);

        /// <summary>The get enabled.</summary>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<Profile> GetEnabled(int pageIndex, int pageCount);

        /// <summary>The search.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<ProfileSearchResult> Search(Guid profileId, Expression<Func<Profile, bool>> filter);

        #endregion
    }
}