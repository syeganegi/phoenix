// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMediaAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The MediaAppService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;

    /// <summary>The MediaAppService interface.</summary>
    public interface IMediaAppService
    {
        #region Public Methods and Operators

        /// <summary>The add new media.</summary>
        /// <param name="mediaDTO">The media dto.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        MediaDTO AddNewMedia(MediaDTO mediaDTO);

        /// <summary>The delete media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool DeleteMedia(Guid id);

        /// <summary>The get media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        MediaDTO GetMedia(Guid id);

        /// <summary>The get medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        List<MediaDTO> GetMedias(string username);

        #endregion
    }
}