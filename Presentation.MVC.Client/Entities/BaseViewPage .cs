// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewPage .cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The base view page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Entities
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;

    /// <summary>The base view page.</summary>
    public abstract class BaseViewPage : WebViewPage
    {
        #region Public Properties

        /// <summary>Gets the current profile.</summary>
        public virtual ProfilePrincipal CurrentProfile { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The init helpers.</summary>
        public override void InitHelpers()
        {
            base.InitHelpers();
            this.CurrentProfile = CurrentProfileHelper.GetCurrentProfile(this.Request, this.User.Identity.Name);
        }

        #endregion
    }

    /// <summary>The base view page.</summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        #region Public Properties

        /// <summary>Gets the current profile.</summary>
        public virtual ProfilePrincipal CurrentProfile { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The init helpers.</summary>
        public override void InitHelpers()
        {
            base.InitHelpers();
            this.CurrentProfile = CurrentProfileHelper.GetCurrentProfile(this.Request, this.User.Identity.Name);
        }

        #endregion
    }
}