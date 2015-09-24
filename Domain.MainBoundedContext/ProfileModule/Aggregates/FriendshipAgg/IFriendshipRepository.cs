// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFriendshipRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     Base contract for product repository
    ///     <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{Friendship}" />
    /// </summary>
    public interface IFriendshipRepository : IRepository<Friendship>
    {
        #region Public Methods and Operators

        /// <summary>The get.</summary>
        /// <param name="username1">The username 1.</param>
        /// <param name="username2">The username 2.</param>
        /// <returns>The <see cref="Friendship"/>.</returns>
        Friendship Get(string username1, string username2);

        /// <summary>The get friends.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<Profile> GetFriends(Guid profileId, Expression<Func<Profile, bool>> filter);

        /// <summary>The get initiators.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<Profile> GetInitiators(Expression<Func<Friendship, bool>> filter);

        #endregion
    }
}