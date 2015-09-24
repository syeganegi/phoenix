// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="">
//   
// </copyright>
// <summary>
//   DI container accessor
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.InstanceProviders
{
    using Microsoft.Practices.Unity;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Adapter;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>
    /// DI container accessor
    /// </summary>
    public static class UnityConfigurator
    {
        #region Static Fields

        /// <summary>
        /// The _current container.
        /// </summary>
        private static IUnityContainer _currentContainer;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="UnityConfigurator"/> class.
        /// </summary>
        static UnityConfigurator()
        {
            ConfigureContainer();

            ConfigureFactories();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the current configured container
        /// </summary>
        /// <returns>Configured container</returns>
        public static IUnityContainer Current
        {
            get
            {
                return _currentContainer;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The configure container.
        /// </summary>
        private static void ConfigureContainer()
        {
            /*
             * Add here the code configuration or the call to configure the container 
             * using the application configuration file
             */
            _currentContainer = new UnityContainer();

            // -> Adapters
            _currentContainer.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(
                new ContainerControlledLifetimeManager());

            // -> Application services
            _currentContainer.RegisterType<IProfileMvcService, ProfileMvcService>();

            
            /*
            // -> Unit of Work and repositories
            _currentContainer.RegisterType(typeof(MainBCUnitOfWork), new PerResolveLifetimeManager());

            _currentContainer.RegisterType<IProfileRepository, ProfileRepository>();
            _currentContainer.RegisterType<IFriendRequestRepository, FriendRequestRepository>();
            _currentContainer.RegisterType<IFriendshipRepository, FriendshipRepository>();

            // -> Domain Services
            _currentContainer.RegisterType<IFriendshipService, FriendshipService>();

            // -> Distributed Services
            _currentContainer.RegisterType<IProfileModuleService, ProfileModuleService>();
 * */
        }

        /// <summary>
        /// The configure factories.
        /// </summary>
        private static void ConfigureFactories()
        {
            //LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            //EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = _currentContainer.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        #endregion
    }
}