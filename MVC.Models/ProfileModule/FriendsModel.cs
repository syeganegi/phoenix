// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendsModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The friends model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    /// <summary>The friends model.</summary>
    public class FriendsModel
    {
        #region Public Properties

        /// <summary>Gets or sets the friends.</summary>
        public ProfileModel[] Friends { get; set; }

        /// <summary>Gets or sets the user name.</summary>
        public string UserName { get; set; }

        #endregion
    }
}