// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentProfileHelper.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The current profile helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Entities
{
    using System.Web;

    using Microsoft.Practices.ServiceLocation;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;
    using System.Web.Mvc;

    /// <summary>The current profile helper.</summary>
    public static class CurrentProfileHelper
    {
        #region Static Fields

        /// <summary>The profile mvc service.</summary>
        private static readonly IProfileMvcService profileMvcService;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes static members of the <see cref="CurrentProfileHelper"/> class.</summary>
        static CurrentProfileHelper()
        {
            profileMvcService = DependencyResolver.Current.GetService<IProfileMvcService>();
        }

        #endregion

        public static ProfilePrincipal GetCurrentProfile(HttpRequestBase request, string username)
        {
            return request.IsAuthenticated
                                      ? Infrastructure.Crosscutting.Common.Cache.Run(
                                          () =>
                                          profileMvcService.GetProfilePrincipal(
                                              username),
                                          60,
                                          username)
                                      : null;
        }
    }
}