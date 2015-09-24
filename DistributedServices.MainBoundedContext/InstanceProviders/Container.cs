// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="">
//   
// </copyright>
// <summary>
//   DI container accessor
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.DistributedServices.MainBoundedContext.InstanceProviders
{
    using Microsoft.Practices.Unity;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Services;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Adapter;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Repositories;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;

    /// <summary>
    /// DI container accessor
    /// </summary>
    public static class Container
    {
        #region Static Fields

        /// <summary>
        /// The _current container.
        /// </summary>
        private static IUnityContainer _currentContainer;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Container"/> class.
        /// </summary>
        static Container()
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

            // -> Unit of Work and repositories
            _currentContainer.RegisterType(typeof(MainBCUnitOfWork), new PerResolveLifetimeManager());

            // -> Repositories
            _currentContainer.RegisterType<IProfileRepository, ProfileRepository>();
            _currentContainer.RegisterType<IProfileViewRepository, ProfileViewRepository>();
            _currentContainer.RegisterType<IFriendshipRepository, FriendshipRepository>();
            _currentContainer.RegisterType<IPostRepository, PostRepository>();
            _currentContainer.RegisterType<IMediaRepository, MediaRepository>();
            _currentContainer.RegisterType<IDeletedProfileRepository, DeletedProfileRepository>();

            // -> Adapters
            _currentContainer.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(
                new ContainerControlledLifetimeManager());

            // -> Domain Services
            _currentContainer.RegisterType<IFriendshipService, FriendshipService>();

            // -> Application services
            _currentContainer.RegisterType<IProfileAppService, ProfileAppService>();
            _currentContainer.RegisterType<IFriendAppService, FriendAppService>();
            _currentContainer.RegisterType<IPostAppService, PostAppService>();
            _currentContainer.RegisterType<IMediaAppService, MediaAppService>();

            // -> Distributed Services
            _currentContainer.RegisterType<IProfileModuleService, ProfileModuleService>();
        }

        /// <summary>
        /// The configure factories.
        /// </summary>
        private static void ConfigureFactories()
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = _currentContainer.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        #endregion
    }
}