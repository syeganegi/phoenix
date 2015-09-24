// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomapperTypeAdapterTests.cs" company="">
//   
// </copyright>
// <summary>
//   The automapper type adapter tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Crosscutting.Tests
{
    using System.Collections.Generic;

    using AutoMapper;

    using Infrastructure.Crosscutting.Tests.Classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Adapter;

    /// <summary>
    /// The automapper type adapter tests.
    /// </summary>
    [TestClass]
    public class AutomapperTypeAdapterTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The auto mapper type adapter adapt entity.
        /// </summary>
        [TestMethod]
        public void AutoMapperTypeAdapterAdaptEntity()
        {
            // Arrange
            Mapper.Initialize(cfg => cfg.AddProfile(new TypeAdapterProfile()));
            var typeAdapter = new AutomapperTypeAdapter();

            var customer = new Customer { Id = 1, FirstName = "Jhon", LastName = "Bep" };

            // act
            CustomerDTO dto = typeAdapter.Adapt<Customer, CustomerDTO>(customer);

            // Assert
            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.CustomerId, customer.Id);
            Assert.AreEqual(dto.FullName, string.Format("{0},{1}", customer.LastName, customer.FirstName));
        }

        /// <summary>
        /// The auto mapper type adapter adapt entity enumerable.
        /// </summary>
        [TestMethod]
        public void AutoMapperTypeAdapterAdaptEntityEnumerable()
        {
            // Arrange
            Mapper.Initialize(cfg => cfg.AddProfile(new TypeAdapterProfile()));
            var typeAdapter = new AutomapperTypeAdapter();

            var customer = new Customer { Id = 1, FirstName = "Jhon", LastName = "Bep" };

            // act
            List<CustomerDTO> dto = typeAdapter.Adapt<IEnumerable<Customer>, List<CustomerDTO>>(new[] { customer });

            // Assert
            Assert.IsNotNull(dto);
            Assert.IsTrue(dto.Count == 1);
            Assert.AreEqual(dto[0].CustomerId, customer.Id);
            Assert.AreEqual(dto[0].FullName, string.Format("{0},{1}", customer.LastName, customer.FirstName));
        }

        #endregion
    }
}