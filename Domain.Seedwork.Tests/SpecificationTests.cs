// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecificationTests.cs" company="">
//   
// </copyright>
// <summary>
//   Summary description for SpecificationTests
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Domain.Seedwork.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Domain.Seedwork.Tests.Classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;

    /// <summary>
    /// Summary description for SpecificationTests
    /// </summary>
    [TestClass]
    public class SpecificationTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The check not specification operators.
        /// </summary>
        [TestMethod]
        public void CheckNotSpecificationOperators()
        {
            // Arrange
            Expression<Func<SampleEntity, bool>> specificationCriteria = t => t.Id == Guid.NewGuid();

            // Act
            Specification<SampleEntity> spec = new DirectSpecification<SampleEntity>(specificationCriteria);
            Specification<SampleEntity> notSpec = !spec;
            ISpecification<SampleEntity> resultAnd = notSpec && spec;
            ISpecification<SampleEntity> resultOr = notSpec || spec;

            // Assert
            Assert.IsNotNull(notSpec);
            Assert.IsNotNull(resultAnd);
            Assert.IsNotNull(resultOr);
        }

        /// <summary>
        /// The create and specification null left spec throw argument null exception test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAndSpecificationNullLeftSpecThrowArgumentNullExceptionTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            // Act
            var composite = new AndSpecification<SampleEntity>(null, rightAdHocSpecification);
        }

        /// <summary>
        /// The create and specification null right spec throw argument null exception test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAndSpecificationNullRightSpecThrowArgumentNullExceptionTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Expression<Func<SampleEntity, bool>> rightSpec = s => s.Id == Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.SampleProperty.Length > 2;

            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            // Act
            var composite = new AndSpecification<SampleEntity>(leftAdHocSpecification, null);
        }

        /// <summary>
        /// The create and specification test.
        /// </summary>
        [TestMethod]
        public void CreateAndSpecificationTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Guid identifier = Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == identifier;
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            // Act
            var composite = new AndSpecification<SampleEntity>(leftAdHocSpecification, rightAdHocSpecification);

            // Assert
            Assert.IsNotNull(composite.SatisfiedBy());
            ReferenceEquals(leftAdHocSpecification, composite.LeftSideSpecification);
            ReferenceEquals(rightAdHocSpecification, composite.RightSideSpecification);

            var list = new List<SampleEntity>();
            var sampleA = new SampleEntity { SampleProperty = "1" };
            sampleA.ChangeCurrentIdentity(identifier);

            var sampleB = new SampleEntity { SampleProperty = "the sample property" };
            sampleB.ChangeCurrentIdentity(identifier);

            list.AddRange(new[] { sampleA, sampleB });

            List<SampleEntity> result = list.AsQueryable().Where(composite.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 1);
        }

        /// <summary>
        /// The create direct specification null spec throw argument null exception test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateDirectSpecificationNullSpecThrowArgumentNullExceptionTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> adHocSpecification;
            Expression<Func<SampleEntity, bool>> spec = null;

            // Act
            adHocSpecification = new DirectSpecification<SampleEntity>(spec);
        }

        /// <summary>
        /// The create new direct specification test.
        /// </summary>
        [TestMethod]
        public void CreateNewDirectSpecificationTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> adHocSpecification;
            Expression<Func<SampleEntity, bool>> spec = s => s.Id == Guid.NewGuid();

            // Act
            adHocSpecification = new DirectSpecification<SampleEntity>(spec);

            // Assert
            ReferenceEquals(new PrivateObject(adHocSpecification).GetField("_MatchingCriteria"), spec);
        }

        /// <summary>
        /// The create not specification from negation operator.
        /// </summary>
        [TestMethod]
        public void CreateNotSpecificationFromNegationOperator()
        {
            // Arrange
            Expression<Func<SampleEntity, bool>> specificationCriteria = t => t.Id == Guid.NewGuid();

            // Act
            var spec = new DirectSpecification<SampleEntity>(specificationCriteria);
            ISpecification<SampleEntity> notSpec = !spec;

            // Assert
            Assert.IsNotNull(notSpec);
        }

        /// <summary>
        /// The create not specification null criteria throw argument null exception test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNotSpecificationNullCriteriaThrowArgumentNullExceptionTest()
        {
            // Arrange
            NotSpecification<SampleEntity> notSpec;

            // Act
            notSpec = new NotSpecification<SampleEntity>((Expression<Func<SampleEntity, bool>>)null);
        }

        /// <summary>
        /// The create not specification null specification throw argument null exception test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNotSpecificationNullSpecificationThrowArgumentNullExceptionTest()
        {
            // Arrange
            NotSpecification<SampleEntity> notSpec;

            // Act
            notSpec = new NotSpecification<SampleEntity>((ISpecification<SampleEntity>)null);
        }

        /// <summary>
        /// The create not specification with criteria test.
        /// </summary>
        [TestMethod]
        public void CreateNotSpecificationWithCriteriaTest()
        {
            // Arrange
            Expression<Func<SampleEntity, bool>> specificationCriteria = t => t.Id == Guid.NewGuid();

            // Act
            var notSpec = new NotSpecification<SampleEntity>(specificationCriteria);

            // Assert
            Assert.IsNotNull(notSpec);
            Assert.IsNotNull(new PrivateObject(notSpec).GetField("_OriginalCriteria"));
        }

        /// <summary>
        /// The create not specificationith specification test.
        /// </summary>
        [TestMethod]
        public void CreateNotSpecificationithSpecificationTest()
        {
            // Arrange
            Expression<Func<SampleEntity, bool>> specificationCriteria = t => t.Id == Guid.NewGuid();
            var specification = new DirectSpecification<SampleEntity>(specificationCriteria);

            // Act
            var notSpec = new NotSpecification<SampleEntity>(specification);
            var resultCriteria =
                new PrivateObject(notSpec).GetField("_OriginalCriteria") as Expression<Func<SampleEntity, bool>>;

            // Assert
            Assert.IsNotNull(notSpec);
            Assert.IsNotNull(resultCriteria);
            Assert.IsNotNull(notSpec.SatisfiedBy());
        }

        /// <summary>
        /// The create or specification null left spec throw argument null exception test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateOrSpecificationNullLeftSpecThrowArgumentNullExceptionTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            // Act
            var composite = new OrSpecification<SampleEntity>(null, rightAdHocSpecification);
        }

        /// <summary>
        /// The create or specification null right spec throw argument null exception test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateOrSpecificationNullRightSpecThrowArgumentNullExceptionTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Expression<Func<SampleEntity, bool>> rightSpec = s => s.Id == Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.SampleProperty.Length > 2;

            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            // Act
            var composite = new OrSpecification<SampleEntity>(leftAdHocSpecification, null);
        }

        /// <summary>
        /// The create or specification test.
        /// </summary>
        [TestMethod]
        public void CreateOrSpecificationTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Guid identifier = Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == identifier;
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            // Act
            var composite = new OrSpecification<SampleEntity>(leftAdHocSpecification, rightAdHocSpecification);

            // Assert
            Assert.IsNotNull(composite.SatisfiedBy());
            ReferenceEquals(leftAdHocSpecification, composite.LeftSideSpecification);
            ReferenceEquals(rightAdHocSpecification, composite.RightSideSpecification);

            var list = new List<SampleEntity>();

            var sampleA = new SampleEntity { SampleProperty = "1" };
            sampleA.ChangeCurrentIdentity(identifier);

            var sampleB = new SampleEntity { SampleProperty = "the sample property" };
            sampleB.GenerateNewIdentity();

            list.AddRange(new[] { sampleA, sampleB });

            List<SampleEntity> result = list.AsQueryable().Where(composite.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count() == 2);
        }

        /// <summary>
        /// The create true specification test.
        /// </summary>
        [TestMethod]
        public void CreateTrueSpecificationTest()
        {
            // Arrange
            ISpecification<SampleEntity> trueSpec = new TrueSpecification<SampleEntity>();
            bool expected = true;
            bool actual = trueSpec.SatisfiedBy().Compile()(new SampleEntity());

            // Assert
            Assert.IsNotNull(trueSpec);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The use specification and operator test.
        /// </summary>
        [TestMethod]
        public void UseSpecificationAndOperatorTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Guid identifier = Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == identifier;
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            // Act
            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            ISpecification<SampleEntity> andSpec = leftAdHocSpecification && rightAdHocSpecification;

            var list = new List<SampleEntity>();

            var sampleA = new SampleEntity { SampleProperty = "1" };
            sampleA.ChangeCurrentIdentity(identifier);

            var sampleB = new SampleEntity { SampleProperty = "the sample property" };
            sampleB.GenerateNewIdentity();

            var sampleC = new SampleEntity { SampleProperty = "the sample property" };
            sampleC.ChangeCurrentIdentity(identifier);

            list.AddRange(new[] { sampleA, sampleB, sampleC });

            List<SampleEntity> result = list.AsQueryable().Where(andSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 1);
        }

        /// <summary>
        /// The use specification bitwise or operator test.
        /// </summary>
        [TestMethod]
        public void UseSpecificationBitwiseOrOperatorTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Guid identifier = Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == identifier;
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            // Act
            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            Specification<SampleEntity> orSpec = leftAdHocSpecification | rightAdHocSpecification;

            // Assert
            var list = new List<SampleEntity>();

            var sampleA = new SampleEntity { SampleProperty = "1" };
            sampleA.ChangeCurrentIdentity(identifier);

            var sampleB = new SampleEntity { SampleProperty = "the sample property" };
            sampleB.GenerateNewIdentity();

            list.AddRange(new[] { sampleA, sampleB });

            List<SampleEntity> result = list.AsQueryable().Where(orSpec.SatisfiedBy()).ToList();
        }

        /// <summary>
        /// The use specification logic and operator test.
        /// </summary>
        [TestMethod]
        public void UseSpecificationLogicAndOperatorTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Guid identifier = Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == identifier;
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            // Act
            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            ISpecification<SampleEntity> andSpec = leftAdHocSpecification & rightAdHocSpecification;

            // Assert
            var list = new List<SampleEntity>();
            var sampleA = new SampleEntity { SampleProperty = "1" };
            sampleA.ChangeCurrentIdentity(identifier);

            var sampleB = new SampleEntity { SampleProperty = "the sample property" };
            sampleB.GenerateNewIdentity();

            var sampleC = new SampleEntity { SampleProperty = "the sample property" };
            sampleC.ChangeCurrentIdentity(identifier);

            list.AddRange(new[] { sampleA, sampleB, sampleC });

            List<SampleEntity> result = list.AsQueryable().Where(andSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 1);
        }

        /// <summary>
        /// The use specification or operator test.
        /// </summary>
        [TestMethod]
        public void UseSpecificationOrOperatorTest()
        {
            // Arrange
            DirectSpecification<SampleEntity> leftAdHocSpecification;
            DirectSpecification<SampleEntity> rightAdHocSpecification;

            Guid identifier = Guid.NewGuid();
            Expression<Func<SampleEntity, bool>> leftSpec = s => s.Id == identifier;
            Expression<Func<SampleEntity, bool>> rightSpec = s => s.SampleProperty.Length > 2;

            // Act
            leftAdHocSpecification = new DirectSpecification<SampleEntity>(leftSpec);
            rightAdHocSpecification = new DirectSpecification<SampleEntity>(rightSpec);

            Specification<SampleEntity> orSpec = leftAdHocSpecification || rightAdHocSpecification;

            // Assert
            var list = new List<SampleEntity>();
            var sampleA = new SampleEntity { SampleProperty = "1" };
            sampleA.ChangeCurrentIdentity(identifier);

            var sampleB = new SampleEntity { SampleProperty = "the sample property" };
            sampleB.GenerateNewIdentity();

            list.AddRange(new[] { sampleA, sampleB });

            List<SampleEntity> result = list.AsQueryable().Where(orSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count() == 2);
        }

        #endregion
    }
}