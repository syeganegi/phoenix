// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityTests.cs" company="">
//   
// </copyright>
// <summary>
//   The entity tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Domain.Seedwork.Tests
{
    using System;

    using Domain.Seedwork.Tests.Classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The entity tests.
    /// </summary>
    [TestClass]
    public class EntityTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The change identity set new identity.
        /// </summary>
        [TestMethod]
        public void ChangeIdentitySetNewIdentity()
        {
            // Arrange
            var entity = new SampleEntity();
            entity.GenerateNewIdentity();

            // act
            Guid expected = entity.Id;
            entity.ChangeCurrentIdentity(Guid.NewGuid());

            // assert
            Assert.AreNotEqual(expected, entity.Id);
        }

        /// <summary>
        /// The compare the same reference return true test.
        /// </summary>
        [TestMethod]
        public void CompareTheSameReferenceReturnTrueTest()
        {
            // Arrange
            var entityLeft = new SampleEntity();
            SampleEntity entityRight = entityLeft;

            // Act
            if (! entityLeft.Equals(entityRight))
            {
                Assert.Fail();
            }

            if (!(entityLeft == entityRight))
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// The compare using equals operators and null operands test.
        /// </summary>
        [TestMethod]
        public void CompareUsingEqualsOperatorsAndNullOperandsTest()
        {
            // Arrange
            SampleEntity entityLeft = null;
            var entityRight = new SampleEntity();

            entityRight.GenerateNewIdentity();

            // Act
            if (!(entityLeft == null))
            {
                // this perform ==(left,right)
                Assert.Fail();
            }

            if (!(entityRight != null))
            {
                // this perform !=(left,right)
                Assert.Fail();
            }

            entityRight = null;

            // Act
            if (!(entityLeft == entityRight))
            {
                // this perform ==(left,right)
                Assert.Fail();
            }

            if (entityLeft != entityRight)
            {
                // this perform !=(left,right)
                Assert.Fail();
            }
        }

        /// <summary>
        /// The compare when left is null and right is null return false test.
        /// </summary>
        [TestMethod]
        public void CompareWhenLeftIsNullAndRightIsNullReturnFalseTest()
        {
            // Arrange
            SampleEntity entityLeft = null;
            var entityRight = new SampleEntity();

            entityRight.GenerateNewIdentity();

            // Act
            if (!(entityLeft == null))
            {
                // this perform ==(left,right)
                Assert.Fail();
            }

            if (!(entityRight != null))
            {
                // this perform !=(left,right)
                Assert.Fail();
            }
        }

        /// <summary>
        /// The diferent id produce equals false test.
        /// </summary>
        [TestMethod]
        public void DiferentIdProduceEqualsFalseTest()
        {
            // Arrange
            var entityLeft = new SampleEntity();
            var entityRight = new SampleEntity();

            entityLeft.GenerateNewIdentity();
            entityRight.GenerateNewIdentity();

            // Act
            bool resultOnEquals = entityLeft.Equals(entityRight);
            bool resultOnOperator = entityLeft == entityRight;

            // Assert
            Assert.IsFalse(resultOnEquals);
            Assert.IsFalse(resultOnOperator);
        }

        /// <summary>
        /// The same identity produce equals true test.
        /// </summary>
        [TestMethod]
        public void SameIdentityProduceEqualsTrueTest()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            var entityLeft = new SampleEntity();
            var entityRight = new SampleEntity();

            entityLeft.ChangeCurrentIdentity(id);
            entityRight.ChangeCurrentIdentity(id);

            // Act
            bool resultOnEquals = entityLeft.Equals(entityRight);
            bool resultOnOperator = entityLeft == entityRight;

            // Assert
            Assert.IsTrue(resultOnEquals);
            Assert.IsTrue(resultOnOperator);
        }

        /// <summary>
        /// The set identity set a non transient entity.
        /// </summary>
        [TestMethod]
        public void SetIdentitySetANonTransientEntity()
        {
            // Arrange
            var entity = new SampleEntity();

            // Act
            entity.GenerateNewIdentity();

            // Assert
            Assert.IsFalse(entity.IsTransient());
        }

        #endregion
    }
}