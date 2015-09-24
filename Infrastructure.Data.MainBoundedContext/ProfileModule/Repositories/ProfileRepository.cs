// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileRepository.cs" company="Phoenix Pty Ltd">
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

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;
    using Phoenix.PhoenixApp.Infrastructure.Data.Seedwork;

    /// <summary>
    ///     Profile repository implementation
    /// </summary>
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ProfileRepository"/> class.
        ///     Create a new instance</summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public ProfileRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary><see cref="Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.IProfileRepository"/></summary>
        /// <param name="id">The profile Id</param>
        /// <returns>The <see cref="Profile"/>.</returns>
        public override Profile Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                if (currentUnitOfWork == null)
                {
                    throw new NullReferenceException("currentUnitOfWork");
                }

                DbSet<Profile> set = currentUnitOfWork.CreateSet<Profile>();

                return set.Include(p => p.Picture).Include(p => p.InstanceMessages).SingleOrDefault(c => c.Id == id);
            }

            return null;
        }

        /// <summary>Gets the specified user name.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The <see cref="Profile"/>.</returns>
        /// <exception cref="System.NullReferenceException">currentUnitOfWork</exception>
        public Profile Get(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                if (currentUnitOfWork == null)
                {
                    throw new NullReferenceException("currentUnitOfWork");
                }

                DbSet<Profile> set = currentUnitOfWork.CreateSet<Profile>();

                return
                    set.Include(p => p.Picture)
                       .Include(p => p.InstanceMessages)
                       .FirstOrDefault(c => c.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            }

            return null;
        }

        /// <summary><see cref="Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.IProfileRepository"/></summary>
        /// <param name="pageIndex"><see cref="Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.IProfileRepository"/></param>
        /// <param name="pageCount"><see cref="Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.IProfileRepository"/></param>
        /// <returns>The list of profiles.</returns>
        public IEnumerable<Profile> GetEnabled(int pageIndex, int pageCount)
        {
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

            if (currentUnitOfWork == null)
            {
                throw new NullReferenceException("currentUnitOfWork");
            }

            return
                currentUnitOfWork.Profiles.Where(c => c.IsEnabled)
                                 .OrderBy(c => c.FullName)
                                 .Skip(pageIndex * pageCount)
                                 .Take(pageCount);
        }

        /// <summary>The merge.</summary>
        /// <param name="persisted">The persisted.</param>
        /// <param name="current">The current.</param>
        public override void Merge(Profile persisted, Profile current)
        {
            // merge customer and customer picture
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;
            if (currentUnitOfWork == null)
            {
                throw new NullReferenceException("currentUnitOfWork");
            }

            currentUnitOfWork.ApplyCurrentValues(persisted, current);
            currentUnitOfWork.ApplyCurrentValues(persisted.Picture, current.Picture);
        }

        /// <summary>The search.</summary>
        /// <param name="profileId">The profile id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public virtual IEnumerable<ProfileSearchResult> Search(Guid profileId, Expression<Func<Profile, bool>> filter)
        {
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

            if (currentUnitOfWork == null)
            {
                throw new NullReferenceException("currentUnitOfWork");
            }

            IQueryable<ProfileSearchResult> profiles =
                currentUnitOfWork.Profiles.AsNoTracking()
                                 .Where(filter)
                                 .Select(
                                     profile =>
                                     new ProfileSearchResult
                                     {
                                         Profile = profile,
                                         Friendship =
                                             profile.Initiators.FirstOrDefault(
                                                 i => i.AcceptorId == profileId)
                                             ?? profile.Acceptors.FirstOrDefault(
                                                 a => a.InitiatorId == profileId)
                                     });

            return profiles;
        }

        #endregion
    }
}