// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrueSpecification.cs" company="">
//   
// </copyright>
// <summary>
//   True specification
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.Seedwork.Specification
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// True specification
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of entity in this specification
    /// </typeparam>
    public sealed class TrueSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Public Methods and Operators

        /// <summary>
        /// <see cref=" Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification{TEntity}"/>
        /// </summary>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            // Create "result variable" transform adhoc execution plan in prepared plan
            // for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
            bool result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}