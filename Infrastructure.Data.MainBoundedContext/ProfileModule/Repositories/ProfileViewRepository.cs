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

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;
    using Phoenix.PhoenixApp.Infrastructure.Data.Seedwork;

    /// <summary>
    /// ProfileView repository implementation
    /// </summary>
    public class ProfileViewRepository : Repository<ProfileView>, IProfileViewRepository
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileViewRepository"/> class. 
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">
        /// Associated unit of work
        /// </param>
        public ProfileViewRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// <see cref="IProfileViewRepository"/>
        /// </summary>
        /// <param name="id">
        /// The profile Id
        /// </param>
        /// <returns>
        /// The <see cref="ProfileView"/>.
        /// </returns>
        public override ProfileView Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                if (currentUnitOfWork == null)
                {
                    throw new NullReferenceException("currentUnitOfWork");
                }

                DbSet<ProfileView> set = currentUnitOfWork.CreateSet<ProfileView>();

                return
                    set.Include(p => p.Viewer).Include(p => p.Viewed).SingleOrDefault(
                        c => c.Id == id);
            }

            return null;
        }

        public override IEnumerable<ProfileView> GetFiltered(System.Linq.Expressions.Expression<Func<ProfileView, bool>> filter)
        {
            if (filter != null)
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                if (currentUnitOfWork == null)
                {
                    throw new NullReferenceException("currentUnitOfWork");
                }

                DbSet<ProfileView> set = currentUnitOfWork.CreateSet<ProfileView>();

                return set.Include(p => p.Viewer).Where(filter);
            }

            return null;
        }
        #endregion
    }
}