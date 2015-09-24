// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The account controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.ServiceModel;
    using System.Transactions;
    using System.Web.Mvc;
    using System.Web.Security;

    using DotNetOpenAuth.AspNet;

    using Microsoft.Web.WebPages.OAuth;

    using Phoenix.PhoenixApp.Presentation.MVC.Client.Extensions;
    using Phoenix.PhoenixApp.Presentation.MVC.Client.Filters;
    using Phoenix.PhoenixApp.Presentation.MVC.Client.Resources;
    using Phoenix.PhoenixApp.Presentation.MVC.Common.Helpers;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;
    using Phoenix.PhoenixApp.Presentation.Seedwork;
    
    using WebMatrix.WebData;

    /// <summary>
    ///     The account controller.
    /// </summary>
    [InitializeSimpleMembership]
    [HandleError(ExceptionType = typeof(HttpAntiForgeryException), View = "AntiForgeryError")]
    public partial class AccountController : Controller
    {
        // GET: /Account/Login

        // POST: /Account/Disassociate
        #region Fields

        /// <summary>
        ///     The account service.
        /// </summary>
        private readonly IAccountMvcService accountService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        public AccountController()
            : this(new AccountMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AccountController"/> class.</summary>
        /// <param name="accountService">The account service.</param>
        public AccountController(IAccountMvcService accountService)
        {
            this.accountService = accountService;
        }

        #endregion

        #region Enums

        /// <summary>
        ///     The manage message id.
        /// </summary>
        public enum ManageMessageId
        {
            /// <summary>
            ///     The change password success.
            /// </summary>
            ChangePasswordSuccess, 

            /// <summary>
            ///     The set password success.
            /// </summary>
            SetPasswordSuccess, 

            /// <summary>
            ///     The remove login success.
            /// </summary>
            RemoveLoginSuccess, 
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The disassociate.</summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider user id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == this.User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (
                    var scope = new TransactionScope(
                        TransactionScopeOption.Required, 
                        new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount =
                        OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(this.User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(this.User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return this.RedirectToAction(MVCT.Account.Manage(message));
        }

        // GET: /Account/Manage

        // POST: /Account/ExternalLogin

        /// <summary>The external login.</summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, this.Url.Action(MVCT.Account.ExternalLoginCallback(returnUrl)));
        }

        // GET: /Account/ExternalLoginCallback

        /// <summary>The external login callback.</summary>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [AllowAnonymous]
        public virtual ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result =
                OAuthWebSecurity.VerifyAuthentication(this.Url.Action(MVCT.Account.ExternalLoginCallback(returnUrl)));
            if (!result.IsSuccessful)
            {
                return this.RedirectToAction(MVCT.Account.ExternalLoginFailure());
            }

            // here we check if user exists and enabled
            if (!this.accountService.UserExistsAndEnabled(result.UserName))
            {
                return this.RedirectToAction(MVCT.Account.ExternalLoginFailure());
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return this.RedirectToLocal(returnUrl);
            }

            if (this.User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, this.User.Identity.Name);
                return this.RedirectToLocal(returnUrl);
            }

            // User is new, ask for their desired membership name
            string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
            this.ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
            this.ViewBag.ReturnUrl = returnUrl;
            return this.View("ExternalLoginConfirmation", this.GetExternalLoginModel(result, loginData));
        }

        // POST: /Account/ExternalLoginConfirmation

        /// <summary>The external login confirmation.</summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (this.User.Identity.IsAuthenticated
                || !OAuthWebSecurity.TryDeserializeProviderUserId(
                    model.ExternalLoginData, out provider, out providerUserId))
            {
                return this.RedirectToAction(MVCT.Account.Manage());
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.accountService.AddNewExternalAccountProfile(provider, providerUserId, model);
                    OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                    return this.RedirectToLocal(returnUrl);
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            this.ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            this.ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        // GET: /Account/ExternalLoginFailure

        /// <summary>
        ///     The external login failure.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return this.View();
        }

        /// <summary>The external logins list.</summary>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [AllowAnonymous]
        [ChildActionOnly]
        public virtual ActionResult ExternalLoginsList(string returnUrl)
        {
            this.ViewBag.ReturnUrl = returnUrl;
            return this.PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        /// <summary>
        ///     The log off.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            WebSecurity.Logout();

            return this.RedirectToAction(MVCT.Home.Index());
        }

        /// <summary>The login.</summary>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            this.ViewBag.ReturnUrl = returnUrl;
            return this.View();
        }

        // POST: /Account/Login

        /// <summary>The login.</summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(LoginModel model, string returnUrl)
        {
            if (this.ModelState.IsValid && this.accountService.UserExistsAndEnabled(model.UserName)
                && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return this.RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError(string.Empty, Messages.error_The_user_name_or_password_provided_is_incorrect_);
            return View(model);
        }

        /// <summary>The manage.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Manage(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess
                                             ? "Your password has been changed."
                                             : message == ManageMessageId.SetPasswordSuccess
                                                   ? "Your password has been set."
                                                   : message == ManageMessageId.RemoveLoginSuccess
                                                         ? "The external login was removed."
                                                         : string.Empty;
            this.ViewBag.HasLocalPassword =
                OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(this.User.Identity.Name));
            this.ViewBag.ReturnUrl = this.Url.Action("Manage");
            return this.View();
        }

        // POST: /Account/Manage

        /// <summary>The manage.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(this.User.Identity.Name));
            this.ViewBag.HasLocalPassword = hasLocalAccount;
            this.ViewBag.ReturnUrl = this.Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (this.ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(
                            this.User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return this.RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        this.ModelState.AddModelError(
                            string.Empty, "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = this.ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (this.ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(this.User.Identity.Name, model.NewPassword);
                        return this.RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception e)
                    {
                        this.ModelState.AddModelError(string.Empty, e);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        ///     The register.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return this.View();
        }

        // POST: /Account/Register

        /// <summary>The register.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", 
            Justification = "Reviewed. Suppression is OK here.")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Register(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    // for a new user we use default profile picture
                    byte[] picture = PictureHelper.GetDefaultProfileImage();
                    model.PictureRawPhoto = PictureHelper.ResizePicture(picture);
                    this.accountService.AddNewLocalAccountProfile(model);
                    WebSecurity.Login(model.UserName, model.Password);
                    return this.RedirectToAction(MVCT.Home.Index());
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (MembershipCreateUserException e)
                {
                    this.ModelState.AddModelError(string.Empty, ErrorCodeToString(e.StatusCode));
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return View(model);
        }

        /// <summary>
        ///     The remove external logins.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [ChildActionOnly]
        public virtual ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(this.User.Identity.Name);
            var externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(
                    new ExternalLogin
                        {
                            Provider = account.Provider, 
                            ProviderDisplayName = clientData.DisplayName, 
                            ProviderUserId = account.ProviderUserId, 
                        });
            }

            this.ViewBag.ShowRemoveButton = externalLogins.Count > 1
                                            || OAuthWebSecurity.HasLocalAccount(
                                                WebSecurity.GetUserId(this.User.Identity.Name));
            return this.PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        /// <summary>The secret log off.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult SecretLogOff()
        {
            WebSecurity.Logout();

            return this.RedirectToAction(MVCT.Home.Index());
        }

        #endregion

        #region Methods

        /// <summary>The error code to string.</summary>
        /// <param name="createStatus">The create status.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return Messages.error_User_name_already_exists;

                case MembershipCreateStatus.DuplicateEmail:
                    return
                        "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        /// <summary>Gets the guarded dictionary value.</summary>
        /// <param name="dic">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetGuardedDicValue(IDictionary<string, string> dic, string key)
        {
            return dic.ContainsKey(key) ? dic[key] : string.Empty;
        }

        /// <summary>Gets the external login model.</summary>
        /// <param name="result">The result.</param>
        /// <param name="loginData">The login data.</param>
        /// <returns>The <see cref="RegisterExternalLoginModel"/>.</returns>
        private RegisterExternalLoginModel GetExternalLoginModel(AuthenticationResult result, string loginData)
        {
            if (result.Provider.Equals("facebook", StringComparison.OrdinalIgnoreCase))
            {
                return this.GetFacebookExternalLoginModel(result, loginData);
            }

            return new RegisterExternalLoginModel();
        }

        /// <summary>Gets the facebook external login model.</summary>
        /// <param name="result">The result.</param>
        /// <param name="loginData">The login data.</param>
        /// <returns>The <see cref="RegisterExternalLoginModel"/>.</returns>
        private RegisterExternalLoginModel GetFacebookExternalLoginModel(AuthenticationResult result, string loginData)
        {
            return new RegisterExternalLoginModel
                       {
                           UserName = result.UserName.CleanInput(), 
                           Email = GetGuardedDicValue(result.ExtraData, "email"), 
                           FirstName = GetGuardedDicValue(result.ExtraData, "first_name"), 
                           LastName = GetGuardedDicValue(result.ExtraData, "last_name"), 
                           Sex = GetGuardedDicValue(result.ExtraData, "gender").ToSex(), 
                           Birthday =
                               GetGuardedDicValue(result.ExtraData, "birthday").ToBirthday(), 
                           ImageUrl =
                               string.Format(
                                   FacebookHelper.PictureUrlFormat, result.ProviderUserId), 
                           ExternalLoginData = loginData
                       };
        }

        /// <summary>The redirect to local.</summary>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.RedirectToAction(MVCT.Home.Index());
            }
        }

        #endregion

        /// <summary>
        ///     The external login result.
        /// </summary>
        internal class ExternalLoginResult : ActionResult
        {
            #region Constructors and Destructors

            /// <summary>Initializes a new instance of the <see cref="ExternalLoginResult"/> class.</summary>
            /// <param name="provider">The provider.</param>
            /// <param name="returnUrl">The return url.</param>
            public ExternalLoginResult(string provider, string returnUrl)
            {
                this.Provider = provider;
                this.ReturnUrl = returnUrl;
            }

            #endregion

            #region Public Properties

            /// <summary>
            ///     Gets the provider.
            /// </summary>
            public string Provider { get; private set; }

            /// <summary>
            ///     Gets the return url.
            /// </summary>
            public string ReturnUrl { get; private set; }

            #endregion

            #region Public Methods and Operators

            /// <summary>The execute result.</summary>
            /// <param name="context">The context.</param>
            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(this.Provider, this.ReturnUrl);
            }

            #endregion
        }
    }
}