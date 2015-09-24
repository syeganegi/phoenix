// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileDTOBase.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile dto base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The profile dto base.</summary>
    public abstract class ProfileDTOBase : DTOBase
    {
        #region Public Properties

        /// <summary>Gets or sets the user name.</summary>
        public string UserName { get; set; }

        #endregion
    }
}