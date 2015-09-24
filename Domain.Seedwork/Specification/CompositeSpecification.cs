// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositeSpecification.cs" company="">
//   
// </copyright>
// <summary>
//   Base class for composite specifications
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.Seedwork.Specification
{
    /// <summary>
    /// Base class for composite specifications
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of entity that check this specification
    /// </typeparam>
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Public Properties

        /// <summary>
        /// Left side specification for this composite element
        /// </summary>
        public abstract ISpecification<TEntity> LeftSideSpecification { get; }

        /// <summary>
        /// Right side specification for this composite element
        /// </summary>
        public abstract ISpecification<TEntity> RightSideSpecification { get; }

        #endregion
    }
}