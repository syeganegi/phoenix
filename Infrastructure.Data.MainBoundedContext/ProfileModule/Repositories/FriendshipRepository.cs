// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;
    using Phoenix.PhoenixApp.Infrastructure.Data.Seedwork;

    /// <summary>
    ///     Friendship repository implementation
    /// </summary>
    public class FriendshipRepository : Repository<Friendship>, IFriendshipRepository
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="FriendshipRepository"/> class.
        ///     Create a new instance</summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public FriendshipRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The get.</summary>
        /// <param name="username1">The username 1.</param>
        /// <param name="username2">The username 2.</param>
        /// <returns>The <see cref="Friendship"/>.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public Friendship Get(string username1, string username2)
        {
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

            if (currentUnitOfWork == null)
            {
                throw new NullReferenceException("currentUnitOfWork");
            }

            Func<Friendship, bool> exp =
                f =>
                (f.Initiator.UserName.Equals(username1, StringComparison.OrdinalIgnoreCase)
                 && f.Acceptor.UserName.Equals(username2, StringComparison.OrdinalIgnoreCase))
                || (f.Initiator.UserName.Equals(username2, StringComparison.OrdinalIgnoreCase)
                    && f.Acceptor.UserName.Equals(username1, StringComparison.OrdinalIgnoreCase));

            return currentUnitOfWork.Friendships.Include(f => f.Initiator).Include(f => f.Acceptor).FirstOrDefault(exp);
        }

        /// <summary>The get friends.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public virtual IEnumerable<Profile> GetFriends(Guid profileId, Expression<Func<Profile, bool>> filter)
        {
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

            if (currentUnitOfWork == null)
            {
                throw new NullReferenceException("currentUnitOfWork");
            }

            IQueryable<Profile> acceptors =
                currentUnitOfWork.Friendships.Include(f => f.Acceptor)
                                 .AsNoTracking()
                                 .Where(f => f.InitiatorId == profileId && f.Status == FriendshipStatus.Accepted)
                                 .Select(f => f.Acceptor)
                                 .Where(filter);

            IQueryable<Profile> initiators =
                currentUnitOfWork.Friendships.Include(f => f.Initiator)
                                 .AsNoTracking()
                                 .Where(f => f.AcceptorId == profileId && f.Status == FriendshipStatus.Accepted)
                                 .Select(f => f.Initiator)
                                 .Where(filter);

            return acceptors.Union(initiators).OrderBy(p => p.FullName);
        }

        /// <summary>The get initiators.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public virtual IEnumerable<Profile> GetInitiators(Expression<Func<Friendship, bool>> filter)
        {
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

            if (currentUnitOfWork == null)
            {
                throw new NullReferenceException("currentUnitOfWork");
            }

            IQueryable<Profile> initiators =
                currentUnitOfWork.Friendships.Include(f => f.Initiator)
                                 .AsNoTracking()
                                 .Where(filter)
                                 .Select(f => f.Initiator);

            return initiators.OrderBy(p => p.FullName);
        }

        #endregion
    }
}