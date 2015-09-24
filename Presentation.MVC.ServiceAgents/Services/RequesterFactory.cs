// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequesterFactory.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The requester factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services
{
    using System.Web;

    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;

    /// <summary>The requester factory.</summary>
    public static class RequesterFactory
    {
        #region Public Methods and Operators

        /// <summary>The create request.</summary>
        /// <returns>
        ///     The <see cref="Requester" />.
        /// </returns>
        public static Requester CreateRequest()
        {
            // TODO: to pull out the Id of the current user from Identity
            return new Requester { UserName = HttpContext.Current.User.Identity.Name };
        }

        #endregion
    }
}