﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilePictureDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The about DTO.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    /// <summary>
    ///     The profile picture DTO.
    /// </summary>
    public class ProfilePictureDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the about.
        /// </summary>
        /// <value>
        ///     The about.
        /// </value>
        public byte[] RawPhoto { get; set; }

        #endregion
    }
}