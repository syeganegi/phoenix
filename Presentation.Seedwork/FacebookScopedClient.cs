// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FacebookScopedClient.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The facebook scoped client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.Seedwork
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Web;

    using DotNetOpenAuth.AspNet;

    using Newtonsoft.Json;

    /// <summary>
    /// The facebook scoped client.
    /// </summary>
    public class FacebookScopedClient : IAuthenticationClient
    {
        #region Constants

        /// <summary>
        /// The graph API me.
        /// </summary>
        public const string GraphApiMe = "https://graph.facebook.com/me?";

        /// <summary>
        /// The graph API token.
        /// </summary>
        public const string GraphApiToken = "https://graph.facebook.com/oauth/access_token?";

        /// <summary>
        /// The base url.
        /// </summary>
        private const string BaseUrl = "https://www.facebook.com/dialog/oauth?client_id=";

        #endregion

        #region Fields

        /// <summary>
        /// The app id.
        /// </summary>
        private readonly string appId;

        /// <summary>
        /// The app secret.
        /// </summary>
        private readonly string appSecret;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookScopedClient"/> class.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <param name="appSecret">
        /// The app secret.
        /// </param>
        public FacebookScopedClient(string appId, string appSecret)
        {
            this.appId = appId;
            this.appSecret = appSecret;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the provider name.
        /// </summary>
        public string ProviderName
        {
            get
            {
                return "Facebook";
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The request authentication.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        public void RequestAuthentication(HttpContextBase context, Uri returnUrl)
        {
            string url = BaseUrl + this.appId + "&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.ToString())
                         + "&scope=" + HttpUtility.UrlEncode("email,user_birthday,offline_access");
            
            context.Response.Redirect(url);
        }

        /// <summary>
        /// The verify authentication.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="AuthenticationResult"/>.
        /// </returns>
        public AuthenticationResult VerifyAuthentication(HttpContextBase context)
        {
            var code = context.Request.QueryString["code"];

            var rawUrl = context.Request.Url.ToString();

            // From this we need to remove code portion
            rawUrl = Regex.Replace(rawUrl, "&code=[^&]*", string.Empty);

            var userData = this.GetUserData(code, rawUrl);

            if (userData == null)
            {
                return new AuthenticationResult(false, this.ProviderName, null, null, null);
            }

            var id = userData["id"];
            var username = userData["username"];
            userData.Remove("id");
            userData.Remove("username");

            var result = new AuthenticationResult(true, this.ProviderName, id, username, userData);
            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get html.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        private static string GetHtml(string url)
        {
            string connectionString = url;

            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(connectionString);
                myRequest.Credentials = CredentialCache.DefaultCredentials;

                // Get the response
                WebResponse webResponse = myRequest.GetResponse();
                Stream respStream = webResponse.GetResponseStream();

                var ioStream = new StreamReader(respStream);
                string pageContent = ioStream.ReadToEnd();

                // Close streams
                ioStream.Close();
                respStream.Close();
                return pageContent;
            }
            catch (Exception)
            {
            }

            return null;
        }

        /// <summary>
        /// The get user data.
        /// </summary>
        /// <param name="accessCode">
        /// The access code.
        /// </param>
        /// <param name="redirectURI">
        /// The redirect uri.
        /// </param>
        /// <returns>
        /// The <see cref="IDictionary"/>.
        /// </returns>
        private IDictionary<string, string> GetUserData(string accessCode, string redirectURI)
        {
            string token =
                GetHtml(
                    GraphApiToken + "client_id=" + this.appId + "&redirect_uri=" + HttpUtility.UrlEncode(redirectURI)
                    + "&client_secret=" + this.appSecret + "&code=" + accessCode);
            if (token == null || token == string.Empty)
            {
                return null;
            }

            // fields=id,name,email,username,gender,link&
            string data =
                GetHtml(
                    GraphApiMe
                    +
                    "fields=id,name,email,username,gender,first_name,last_name,middle_name,birthday&access_token="
                    + token.Replace("access_token=", string.Empty));

            // this dictionary must contains
            var userData = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            return userData;
        }

        #endregion
    }
}