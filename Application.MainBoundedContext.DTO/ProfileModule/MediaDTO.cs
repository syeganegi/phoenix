// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The media dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;

    /// <summary>The media dto.</summary>
    public class MediaDTO
    {
        #region Public Properties

        /// <summary>Gets or sets the date created.</summary>
        public DateTime DateCreated { get; set; }

        /// <summary>Gets or sets the id.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the media url.</summary>
        public string MediaUrl { get; set; }

        /// <summary>Gets or sets the profile id.</summary>
        public Guid ProfileId { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the type.</summary>
        public string Type { get; set; }

        #endregion
    }
}