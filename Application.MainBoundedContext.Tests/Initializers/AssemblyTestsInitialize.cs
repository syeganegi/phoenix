// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyTestsInitialize.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The assembly tests initialize.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Application.MainBoundedContext.Tests.Initializers
{
    using System;
    using System.Data.Entity;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Adapter;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;

    /// <summary>
    /// The assembly tests initialize.
    /// </summary>
    [TestClass]
    public class AssemblyTestsInitialize
    {
        #region Public Methods and Operators

        /// <summary>
        /// Initialize all factories for tests
        /// </summary>
        /// <param name="context">
        /// The MS TEST context
        /// </param>
        [AssemblyInitialize]
        public static void InitializeFactories(TestContext context)
        {
            // Sets the data directory.
            AppDomain.CurrentDomain.SetData(
                "DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));

            // Set default initializer for MainBCUnitOfWork
            //Database.SetInitializer(new MainBCUnitOfWorkInitializer());

            LoggerFactory.SetCurrent(new TraceSourceLogFactory());

            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            // this is only to force  current domain to load de .DTO assembly and all profiles
            var dto = new ProfileDTO();

            var adapterfactory = new AutomapperTypeAdapterFactory();
            TypeAdapterFactory.SetCurrent(adapterfactory);
        }

        #endregion
    }
}