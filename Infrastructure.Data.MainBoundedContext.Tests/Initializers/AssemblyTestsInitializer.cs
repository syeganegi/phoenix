// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyTestsInitializer.cs" company="">
//   
// </copyright>
// <summary>
//   The assembly tests initialize.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Data.MainBoundedContext.Tests.Initializers
{
    using System;
    using System.Data.Entity;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The assembly tests initialize.
    /// </summary>
    [TestClass]
    public class AssemblyTestsInitialize
    {
        #region Public Methods and Operators

        /// <summary>
        /// In this beta, the unit of work initializer is MainBCUnitOfWorkInitializer
        /// </summary>
        /// <param name="context">
        /// The MS TEST context
        /// </param>
        [AssemblyInitialize]
        public static void RebuildUnitOfWork(TestContext context)
        {
            // Sets the data directory.
            AppDomain.CurrentDomain.SetData(
                "DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));

            // Set default initializer for MainBCUnitOfWork
            //Database.SetInitializer(new MainBCUnitOfWorkInitializer());
        }

        #endregion
    }
}