// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotSpecification.cs" company="">
//   
// </copyright>
// <summary>
//   NotEspecification convert a original
//   specification with NOT logic operator
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.Seedwork.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// NotEspecification convert a original
    /// specification with NOT logic operator
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of element for this specificaiton
    /// </typeparam>
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Fields

        /// <summary>
        /// The _ original criteria.
        /// </summary>
        private readonly Expression<Func<TEntity, bool>> _OriginalCriteria;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{TEntity}"/> class. 
        /// Constructor for NotSpecificaiton
        /// </summary>
        /// <param name="originalSpecification">
        /// Original specification
        /// </param>
        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            this._OriginalCriteria = originalSpecification.SatisfiedBy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{TEntity}"/> class. 
        /// Constructor for NotSpecification
        /// </summary>
        /// <param name="originalSpecification">
        /// Original specificaiton
        /// </param>
        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            this._OriginalCriteria = originalSpecification;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.Specification.ISpecification{TEntity}"/>
        /// </summary>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Not(this._OriginalCriteria.Body), this._OriginalCriteria.Parameters.Single());
        }

        #endregion
    }
}