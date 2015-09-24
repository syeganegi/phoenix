// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPostAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The PostAppService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;

    /// <summary>The PostAppService interface.</summary>
    public interface IPostAppService
    {
        #region Public Methods and Operators

        /// <summary>The add new post.</summary>
        /// <param name="postDTO">The post dto.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        PostDTO AddNewPost(PostDTO postDTO);

        /// <summary>The delete post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool DeletePost(Guid id);

        /// <summary>The get post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        PostDTO GetPost(Guid id);

        /// <summary>The get posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        List<PostDTO> GetPosts(string username);

        #endregion
    }
}