// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthConfig.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client
{
    using Microsoft.Web.WebPages.OAuth;

    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>
    /// The auth config.
    /// </summary>
    public static class AuthConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register auth.
        /// </summary>
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            // OAuthWebSecurity.RegisterMicrosoftClient(
            // clientId: "",
            // clientSecret: "");

            // OAuthWebSecurity.RegisterTwitterClient(
            // consumerKey: "",
            // consumerSecret: "");
            // OAuthWebSecurity.RegisterFacebookClient(
            // appId: "158024297673688", appSecret: "b1f47583f25bbee3f0f43fdcde042390");
            OAuthWebSecurity.RegisterClient(
                new FacebookScopedClient("158024297673688", "b1f47583f25bbee3f0f43fdcde042390"), "Facebook", null);

            // OAuthWebSecurity.RegisterGoogleClient();
        }

        #endregion
    }
}