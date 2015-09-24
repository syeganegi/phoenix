// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindProfileByUserNameRequest.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The find profiles request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging
{
    using System;

    /// <summary>The find profiles request.</summary>
    public class FindProfileRequest : RequestBase
    {
        #region Public Properties

        /// <summary>Gets or sets a value indicating whether touch.</summary>
        public bool Touch { get; set; }

        /// <summary>Gets or sets the username.</summary>
        public string Username { get; set; }

        public Guid Id { get; set; }

        #endregion
    }
}