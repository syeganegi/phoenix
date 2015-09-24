// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileSearchResultModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile search result model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>The profile search result model.</summary>
    public class ProfileSearchResultModel : ModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the search results.</summary>
        public ProfileSearchResult[] SearchResults { get; set; }

        #endregion
    }
}