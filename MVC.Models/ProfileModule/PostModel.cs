// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The post.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>The post.</summary>
    public class PostModel : ModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the content.</summary>
        [Required]
        public string Content { get; set; }

        /// <summary>Gets or sets the date created.</summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DateCreated { get; set; }

        /// <summary>Gets or sets the id.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the profile id.</summary>
        public Guid ProfileId { get; set; }

        /// <summary>Gets or sets the title.</summary>
        [Required]
        public string Title { get; set; }

        #endregion
    }
}