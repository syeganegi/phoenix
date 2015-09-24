// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostFactory.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg
{
    using System;

    /// <summary>The post factory.</summary>
    public static class PostFactory
    {
        #region Public Methods and Operators

        /// <summary>The create.</summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="profileId">The profile id.</param>
        /// <returns>The <see cref="Post"/>.</returns>
        public static Post Create(string title, string content, Guid profileId)
        {
            var post = new Post { Title = title, Content = content, ProfileId = profileId, DateCreated = DateTime.Now };
            post.GenerateNewIdentity();

            return post;
        }

        #endregion
    }
}