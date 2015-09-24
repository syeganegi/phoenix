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
    public class FindFriendsRequest : PagedRequestBase
    {
        #region Public Properties

        public string UserName { get; set; }

        /// <summary>Gets or sets the search text.</summary>
        public string SearchText { get; set; }

        #endregion
    }
}