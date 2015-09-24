// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileModelBase.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile model base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>The profile model base.</summary>
    public class ProfileModelBase : ModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the id.</summary>
        public string Id { get; set; }

        /// <summary>Gets or sets the user name.</summary>
        public string UserName { get; set; }

        #endregion
    }
}