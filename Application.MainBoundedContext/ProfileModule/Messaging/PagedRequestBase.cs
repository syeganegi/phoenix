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
    public abstract class PagedRequestBase : RequestBase
    {
        #region Public Properties

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        #endregion
    }
}