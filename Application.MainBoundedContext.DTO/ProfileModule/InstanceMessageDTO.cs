// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceMessageDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The instance message dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The instance message dto.</summary>
    public class InstanceMessageDTO : DTOBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the instance message type.
        /// </summary>
        public string InstanceMessageType { get; set; }

        /// <summary>
        ///     Gets or sets the screen name.
        /// </summary>
        public string ScreenName { get; set; }

        #endregion
    }
}