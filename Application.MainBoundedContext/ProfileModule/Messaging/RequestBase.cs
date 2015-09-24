// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestBase.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The request base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging
{
    /// <summary>The request base.</summary>
    public abstract class RequestBase
    {
        #region Public Properties

        /// <summary>Gets or sets the requester.</summary>
        public Requester Requester { get; set; }

        #endregion
    }
}