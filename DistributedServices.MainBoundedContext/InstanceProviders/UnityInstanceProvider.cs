// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityInstanceProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The unity instance provider. This class provides
//   an extensibility point for creating instances of wcf
//   service.
//   <remarks>
//   The goal is to inject dependencies from the inception point
//   </remarks>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.DistributedServices.MainBoundedContext.InstanceProviders
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The unity instance provider. This class provides
    /// an extensibility point for creating instances of wcf
    /// service.
    /// <remarks>
    /// The goal is to inject dependencies from the inception point
    /// </remarks>
    /// </summary>
    public class UnityInstanceProvider : IInstanceProvider
    {
        #region Fields

        /// <summary>
        /// The _container.
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// The _service type.
        /// </summary>
        private readonly Type _serviceType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityInstanceProvider"/> class. 
        /// Create a new instance of unity instance provider
        /// </summary>
        /// <param name="serviceType">
        /// The service where we apply the instance provider
        /// </param>
        public UnityInstanceProvider(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            this._serviceType = serviceType;
            this._container = Container.Current;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </summary>
        /// <param name="instanceContext">
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </param>
        /// <param name="message">
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            // This is the only call to UNITY container in the whole solution
            return this._container.Resolve(this._serviceType);
        }

        /// <summary>
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </summary>
        /// <param name="instanceContext">
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        /// <summary>
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </summary>
        /// <param name="instanceContext">
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </param>
        /// <param name="instance">
        /// <see cref="System.ServiceModel.Dispatcher.IInstanceProvider"/>
        /// </param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            if (instance is IDisposable)
            {
                ((IDisposable)instance).Dispose();
            }
        }

        #endregion
    }
}