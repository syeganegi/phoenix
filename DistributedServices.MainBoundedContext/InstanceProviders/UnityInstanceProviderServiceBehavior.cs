// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityInstanceProviderServiceBehavior.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.DistributedServices.MainBoundedContext.InstanceProviders
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    ///     Service behavior for adding Unity instance provider in each
    ///     endpoint dispatcher
    /// </summary>
    public class UnityInstanceProviderServiceBehavior : Attribute, IServiceBehavior
    {
        #region Public Methods and Operators

        /// <summary>The add binding parameters.</summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host base.</param>
        /// <param name="endpoints">The endpoints.</param>
        /// <param name="bindingParameters">The binding parameters.</param>
        public void AddBindingParameters(
            ServiceDescription serviceDescription, 
            ServiceHostBase serviceHostBase, 
            Collection<ServiceEndpoint> endpoints, 
            BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>The apply dispatch behavior.</summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host base.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            // load the assembly or type
            foreach (ChannelDispatcherBase item in serviceHostBase.ChannelDispatchers)
            {
                var dispatcher = item as ChannelDispatcher;
                if (dispatcher != null)
                {
                    // add new instance provider for each end point dispatcher
                    dispatcher.Endpoints.ToList()
                              .ForEach(
                                  endpoint =>
                                      {
                                          endpoint.DispatchRuntime.InstanceProvider =
                                              new UnityInstanceProvider(serviceDescription.ServiceType);
                                      });
                }
            }
        }

        /// <summary>The validate.</summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host base.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }
}