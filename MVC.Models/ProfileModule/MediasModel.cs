// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediasModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The media.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    /// <summary>The media.</summary>
    public class MediasModel
    {
        #region Public Properties

        /// <summary>Gets or sets the medias.</summary>
        public MediaModel[] Medias { get; set; }

        /// <summary>Gets or sets the user name.</summary>
        public string UserName { get; set; }

        #endregion
    }
}