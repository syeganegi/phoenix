// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileCounterModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile counter model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    /// <summary>The profile counter model.</summary>
    public class ProfileCounterModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the view counter.</summary>
        public long ViewCounter { get; set; }

        #endregion
    }
}