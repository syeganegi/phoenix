// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryableUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The UnitOfWork contract for EF implementation
//   <remarks>
//   This contract extend IUnitOfWork for use with EF code
//   </remarks>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.Seedwork
{
    using System.Data.Entity;

    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    /// The UnitOfWork contract for EF implementation
    /// <remarks>
    /// This contract extend IUnitOfWork for use with EF code
    /// </remarks>
    /// </summary>
    public interface IQueryableUnitOfWork : IUnitOfWork, ISql
    {
        #region Public Methods and Operators

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <typeparam name="TEntity">
        /// The type of entity
        /// </typeparam>
        /// <param name="original">
        /// The original entity
        /// </param>
        /// <param name="current">
        /// The current entity
        /// </param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;

        /// <summary>
        /// The attach.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="TEntity">
        /// </typeparam>
        void Attach<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Returns a IDbSet instance for access to entities of the given type in the context, 
        /// the ObjectStateManager, and the underlying store. 
        /// </summary>
        /// <typeparam name="TValueObject">
        /// </typeparam>
        /// <returns>
        /// The <see cref="DbSet"/>.
        /// </returns>
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam name="TValueObject">
        /// The type of entity
        /// </typeparam>
        /// <param name="item">
        /// The entity item to set as modifed
        /// </param>
        void SetModified<TEntity>(TEntity item) where TEntity : class;

        #endregion
    }
}