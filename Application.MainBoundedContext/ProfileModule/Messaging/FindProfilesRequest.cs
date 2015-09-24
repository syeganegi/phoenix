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
    public class FindProfilesRequest : RequestBase
    {
        #region Public Properties

        /// <summary>Gets or sets a value indicating whether exclude requester.</summary>
        public bool ExcludeRequester { get; set; }

        /// <summary>Gets or sets the search text.</summary>
        public string SearchText { get; set; }

        #endregion
    }
}