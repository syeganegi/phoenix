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

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;
    using Phoenix.PhoenixApp.Infrastructure.Data.Seedwork;

    /// <summary>
    /// Post repository implementation
    /// </summary>
    public class PostRepository : Repository<Post>, IPostRepository
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PostRepository"/> class. 
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">
        /// Associated unit of work
        /// </param>
        public PostRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}