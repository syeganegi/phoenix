// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindProfilesRequest.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The find profiles request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging
{
    /// <summary>The find profiles request.</summary>
    public class FindProfileStatsRequest : PagedRequestBase
    {
        #region Public Properties

        public string Username { get; set; }

        #endregion
    }
}