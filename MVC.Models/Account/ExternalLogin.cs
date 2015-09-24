// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountModels.cs" company="">
//   
// </copyright>
// <summary>
//   The users context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.Account
{
    /// <summary>
    ///     The external login.
    /// </summary>
    public class ExternalLogin
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the provider.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        ///     Gets or sets the provider display name.
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the provider user id.
        /// </summary>
        public string ProviderUserId { get; set; }

        #endregion
    }
}