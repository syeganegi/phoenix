// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileCounterDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile counter dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    /// <summary>The profile counter dto.</summary>
    public class ProfileCounterDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>Gets or sets the view counter.</summary>
        public long ViewCounter { get; set; }

        #endregion
    }
}