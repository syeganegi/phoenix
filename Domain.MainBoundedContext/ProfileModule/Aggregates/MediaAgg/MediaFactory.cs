// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaFactory.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;

    /// <summary>The post factory.</summary>
    public static class MediaFactory
    {
        #region Public Methods and Operators

        /// <summary>The create.</summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="profileId">The profile id.</param>
        /// <returns>The <see cref="Media"/>.</returns>
        public static Media Create(string title, string url, MediaType type, Guid profileId)
        {
            var media = new Media
                           {
                               Title = title,
                               MediaUrl = url,
                               ProfileId = profileId,
                               Type = type,
                               DateCreated = DateTime.Now
                           };
            media.GenerateNewIdentity();

            return media;
        }

        #endregion
    }
}