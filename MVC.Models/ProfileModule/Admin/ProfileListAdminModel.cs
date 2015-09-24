// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileListAdminModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin
{
    /// <summary>The profile list admin model.</summary>
    public class ProfileListAdminModel
    {
        #region Public Properties

        /// <summary>Gets or sets the profiles.</summary>
        public ProfileAdminModel[] Profiles { get; set; }

        #endregion
    }
}