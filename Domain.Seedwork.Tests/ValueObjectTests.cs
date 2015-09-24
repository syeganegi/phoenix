// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueObjectTests.cs" company="">
//   
// </copyright>
// <summary>
//   The value object tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Domain.Seedwork.Tests
{
    using Domain.Seedwork.Tests.Classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The value object tests.
    /// </summary>
    [TestClass]
    public class ValueObjectTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The diferent data equal operator is false test.
        /// </summary>
        [TestMethod]
        public void DiferentDataEqualOperatorIsFalseTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", "city", "zipcode");
            var address2 = new Address("streetLine2", "streetLine1", "city", "zipcode");

            // Act
            bool result = address1 == address2;
            bool resultSimetric = address2 == address1;

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(resultSimetric);
        }

        /// <summary>
        /// The diferent data equals is false test.
        /// </summary>
        [TestMethod]
        public void DiferentDataEqualsIsFalseTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", "city", "zipcode");
            var address2 = new Address("streetLine2", "streetLine1", "city", "zipcode");

            // Act
            bool result = address1.Equals(address2);
            bool resultSimetric = address2.Equals(address1);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(resultSimetric);
        }

        /// <summary>
        /// The diferent data in diferent properties produce diferent hash code test.
        /// </summary>
        [TestMethod]
        public void DiferentDataInDiferentPropertiesProduceDiferentHashCodeTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine2", "streetLine1", null, null);

            // Act
            int address1HashCode = address1.GetHashCode();
            int address2HashCode = address2.GetHashCode();

            // Assert
            Assert.AreNotEqual(address1HashCode, address2HashCode);
        }

        /// <summary>
        /// The diferent data is not equal operator is true test.
        /// </summary>
        [TestMethod]
        public void DiferentDataIsNotEqualOperatorIsTrueTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", "city", "zipcode");
            var address2 = new Address("streetLine2", "streetLine1", "city", "zipcode");

            // Act
            bool result = address1 != address2;
            bool resultSimetric = address2 != address1;

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(resultSimetric);
        }

        /// <summary>
        /// The identical data equal operator is true test.
        /// </summary>
        [TestMethod]
        public void IdenticalDataEqualOperatorIsTrueTest()
        {
            // Arraneg
            var address1 = new Address("streetLine1", "streetLine2", "city", "zipcode");
            var address2 = new Address("streetLine1", "streetLine2", "city", "zipcode");

            // Act
            bool resultEquals = address1 == address2;
            bool resultEqualsSimetric = address2 == address1;
            bool resultEqualsOnThis = address1 == address1;

            // Assert
            Assert.IsTrue(resultEquals);
            Assert.IsTrue(resultEqualsSimetric);
            Assert.IsTrue(resultEqualsOnThis);
        }

        /// <summary>
        /// The identical data equals is true test.
        /// </summary>
        [TestMethod]
        public void IdenticalDataEqualsIsTrueTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", "city", "zipcode");
            var address2 = new Address("streetLine1", "streetLine2", "city", "zipcode");

            // Act
            bool resultEquals = address1.Equals(address2);
            bool resultEqualsSimetric = address2.Equals(address1);
            bool resultEqualsOnThis = address1.Equals(address1);

            // Assert
            Assert.IsTrue(resultEquals);
            Assert.IsTrue(resultEqualsSimetric);
            Assert.IsTrue(resultEqualsOnThis);
        }

        /// <summary>
        /// The identical data is not equal operator is false test.
        /// </summary>
        [TestMethod]
        public void IdenticalDataIsNotEqualOperatorIsFalseTest()
        {
            // Arraneg
            var address1 = new Address("streetLine1", "streetLine2", "city", "zipcode");
            var address2 = new Address("streetLine1", "streetLine2", "city", "zipcode");

            // Act
            bool resultEquals = address1 != address2;
            bool resultEqualsSimetric = address2 != address1;
            bool resultEqualsOnThis = address1 != address1;

            // Assert
            Assert.IsFalse(resultEquals);
            Assert.IsFalse(resultEqualsSimetric);
            Assert.IsFalse(resultEqualsOnThis);
        }

        /// <summary>
        /// The same data in diferent properties equal operator false test.
        /// </summary>
        [TestMethod]
        public void SameDataInDiferentPropertiesEqualOperatorFalseTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine2", "streetLine1", null, null);

            // Act
            bool result = address1 == address2;

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// The same data in diferent properties is equals false test.
        /// </summary>
        [TestMethod]
        public void SameDataInDiferentPropertiesIsEqualsFalseTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine2", "streetLine1", null, null);

            // Act
            bool result = address1.Equals(address2);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// The same data in diferent properties produce diferent hash code test.
        /// </summary>
        [TestMethod]
        public void SameDataInDiferentPropertiesProduceDiferentHashCodeTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", null, null, "streetLine1");
            var address2 = new Address(null, "streetLine1", "streetLine1", null);

            // Act
            int address1HashCode = address1.GetHashCode();
            int address2HashCode = address2.GetHashCode();

            // Assert
            Assert.AreNotEqual(address1HashCode, address2HashCode);
        }

        /// <summary>
        /// The same data same hash code test.
        /// </summary>
        [TestMethod]
        public void SameDataSameHashCodeTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine1", "streetLine2", null, null);

            // Act
            int address1HashCode = address1.GetHashCode();
            int address2HashCode = address2.GetHashCode();

            // Assert
            Assert.AreEqual(address1HashCode, address2HashCode);
        }

        /// <summary>
        /// The same reference equals true test.
        /// </summary>
        [TestMethod]
        public void SameReferenceEqualsTrueTest()
        {
            // Arrange
            var address1 = new Address("streetLine1", null, null, "streetLine1");
            Address address2 = address1;

            // Act
            if (!address1.Equals(address2))
            {
                Assert.Fail();
            }

            if (!(address1 == address2))
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// The self reference not produce infinite loop.
        /// </summary>
        [TestMethod]
        public void SelfReferenceNotProduceInfiniteLoop()
        {
            // Arrange
            var aReference = new SelfReference();
            var bReference = new SelfReference();

            // Act
            aReference.Value = bReference;
            bReference.Value = aReference;

            // Assert
            Assert.AreNotEqual(aReference, bReference);
        }

        #endregion
    }
}