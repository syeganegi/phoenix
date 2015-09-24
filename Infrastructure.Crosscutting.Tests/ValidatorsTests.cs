// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorsTests.cs" company="">
//   
// </copyright>
// <summary>
//   The validators tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Crosscutting.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Infrastructure.Crosscutting.Tests.Classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;

    /// <summary>
    /// The validators tests.
    /// </summary>
    [TestClass]
    public class ValidatorsTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The class initialze.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        [ClassInitialize]
        public static void ClassInitialze(TestContext context)
        {
            // Initialize default log factory
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }

        /// <summary>
        /// The perform validation is valid return false with invalid entities.
        /// </summary>
        [TestMethod]
        public void PerformValidationIsValidReturnFalseWithInvalidEntities()
        {
            // Arrange
            var entityA = new EntityWithValidationAttribute();
            entityA.RequiredProperty = null;

            var entityB = new EntityWithValidatableObject();
            entityB.RequiredProperty = null;

            IEntityValidator entityValidator = EntityValidatorFactory.CreateValidator();

            // Act
            bool entityAValidationResult = entityValidator.IsValid(entityA);
            IEnumerable<string> entityAInvalidMessages = entityValidator.GetInvalidMessages(entityA);

            bool entityBValidationResult = entityValidator.IsValid(entityB);
            IEnumerable<string> entityBInvalidMessages = entityValidator.GetInvalidMessages(entityB);

            // Assert
            Assert.IsFalse(entityAValidationResult);
            Assert.IsFalse(entityBValidationResult);

            Assert.IsTrue(entityAInvalidMessages.Any());
            Assert.IsTrue(entityBInvalidMessages.Any());
        }

        /// <summary>
        /// The perform validation is valid return true with valid entities.
        /// </summary>
        [TestMethod]
        public void PerformValidationIsValidReturnTrueWithValidEntities()
        {
            // Arrange
            var entityA = new EntityWithValidationAttribute();
            entityA.RequiredProperty = "the data";

            var entityB = new EntityWithValidatableObject();
            entityB.RequiredProperty = "the data";

            IEntityValidator entityValidator = EntityValidatorFactory.CreateValidator();

            // Act
            bool entityAValidationResult = entityValidator.IsValid(entityA);
            IEnumerable<string> entityAInvalidMessages = entityValidator.GetInvalidMessages(entityA);

            bool entityBValidationResult = entityValidator.IsValid(entityB);
            IEnumerable<string> entityBInvalidMessages = entityValidator.GetInvalidMessages(entityB);

            // Assert
            Assert.IsTrue(entityAValidationResult);
            Assert.IsTrue(entityBValidationResult);

            Assert.IsFalse(entityAInvalidMessages.Any());
            Assert.IsFalse(entityBInvalidMessages.Any());
        }

        #endregion
    }
}