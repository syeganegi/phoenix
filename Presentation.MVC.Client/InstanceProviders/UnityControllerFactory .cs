namespace Phoenix.PhoenixApp.Presentation.MVC.Client.InstanceProviders
{
    using System;
    using System.Web.Mvc;

    public class UnityControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            IController result = null;

            if (null != controllerType)
            {
                result = DependencyResolver.Current.GetService(controllerType) as IController;
            }

            return result;
        }
    }
}