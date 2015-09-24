// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The post.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;

    /// <summary>The post.</summary>
    public class PostDTO
    {
        #region Public Properties

        /// <summary>Gets or sets the content.</summary>
        public string Content { get; set; }

        /// <summary>Gets or sets the date created.</summary>
        public DateTime DateCreated { get; set; }

        /// <summary>Gets or sets the id.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the profile id.</summary>
        public Guid ProfileId { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title { get; set; }

        #endregion
    }
}