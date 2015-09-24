// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomapperTypeAdapterFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The automapper type adapter factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// The automapper type adapter factory.
    /// </summary>
    public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomapperTypeAdapterFactory"/> class. 
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            // scan all assemblies finding Automapper Profile
            IEnumerable<Type> profiles =
                AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(
                    t => t.BaseType == typeof(Profile));

            Mapper.Initialize(
                cfg =>
                    {
                        foreach (Type item in profiles)
                        {
                            if (item.FullName != "AutoMapper.SelfProfiler`2")
                            {
                                cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                            }
                        }
                    });
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ITypeAdapter"/>.
        /// </returns>
        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}