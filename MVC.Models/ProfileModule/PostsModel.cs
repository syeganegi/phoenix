// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostsModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The post.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    /// <summary>The post.</summary>
    public class PostsModel
    {
        #region Public Properties

        /// <summary>Gets or sets the posts.</summary>
        public PostModel[] Posts { get; set; }

        /// <summary>Gets or sets the user name.</summary>
        public string UserName { get; set; }

        #endregion
    }
}