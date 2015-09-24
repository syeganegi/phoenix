// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DirectSpecification.cs" company="">
//   
// </copyright>
// <summary>
//   A Direct Specification is a simple implementation
//   of specification that acquire this from a lambda expression
//   in  constructor
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.Seedwork.Specification
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// A Direct Specification is a simple implementation
    /// of specification that acquire this from a lambda expression
    /// in  constructor
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of entity that check this specification
    /// </typeparam>
    public sealed class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Fields

        /// <summary>
        /// The _ matching criteria.
        /// </summary>
        private readonly Expression<Func<TEntity, bool>> _MatchingCriteria;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectSpecification{TEntity}"/> class. 
        /// Default constructor for Direct Specification
        /// </summary>
        /// <param name="matchingCriteria">
        /// A Matching Criteria
        /// </param>
        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
            {
                throw new ArgumentNullException("matchingCriteria");
            }

            this._MatchingCriteria = matchingCriteria;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return this._MatchingCriteria;
        }

        #endregion
    }
}