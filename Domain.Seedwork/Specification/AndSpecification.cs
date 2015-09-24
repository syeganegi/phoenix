// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AndSpecification.cs" company="">
//   
// </copyright>
// <summary>
//   A logic AND Specification
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.Seedwork.Specification
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// A logic AND Specification
    /// </summary>
    /// <typeparam name="T">
    /// Type of entity that check this specification
    /// </typeparam>
    public sealed class AndSpecification<T> : CompositeSpecification<T>
        where T : class
    {
        #region Fields

        /// <summary>
        /// The _ left side specification.
        /// </summary>
        private readonly ISpecification<T> _LeftSideSpecification;

        /// <summary>
        /// The _ right side specification.
        /// </summary>
        private readonly ISpecification<T> _RightSideSpecification;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AndSpecification{T}"/> class. 
        /// Default constructor for AndSpecification
        /// </summary>
        /// <param name="leftSide">
        /// Left side specification
        /// </param>
        /// <param name="rightSide">
        /// Right side specification
        /// </param>
        public AndSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == null)
            {
                throw new ArgumentNullException("leftSide");
            }

            if (rightSide == null)
            {
                throw new ArgumentNullException("rightSide");
            }

            this._LeftSideSpecification = leftSide;
            this._RightSideSpecification = rightSide;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Left side specification
        /// </summary>
        public override ISpecification<T> LeftSideSpecification
        {
            get
            {
                return this._LeftSideSpecification;
            }
        }

        /// <summary>
        /// Right side specification
        /// </summary>
        public override ISpecification<T> RightSideSpecification
        {
            get
            {
                return this._RightSideSpecification;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.Specification.ISpecification{T}"/>
        /// </summary>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = this._LeftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = this._RightSideSpecification.SatisfiedBy();

            return left.And(right);
        }

        #endregion
    }
}