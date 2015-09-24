// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeletedProfileRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;
    using Phoenix.PhoenixApp.Infrastructure.Data.Seedwork;

    /// <summary>
    ///     Profile repository implementation
    /// </summary>
    public class DeletedProfileRepository : Repository<DeletedProfile>, IDeletedProfileRepository
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="DeletedProfileRepository"/> class. Initializes a new instance of the <see cref="ProfileRepository"/> class.
        ///     Create a new instance</summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public DeletedProfileRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}