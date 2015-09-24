// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAccountMvcService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The AccountMvcService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services
{
    using System;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;

    /// <summary>The AccountMvcService interface.</summary>
    public interface IAccountMvcService : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>The add new external account profile.</summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider user id.</param>
        /// <param name="model">The model.</param>
        void AddNewExternalAccountProfile(string provider, string providerUserId, RegisterExternalLoginModel model);

        /// <summary>The add new local account profile.</summary>
        /// <param name="model">The model.</param>
        void AddNewLocalAccountProfile(RegisterModel model);

        /// <summary>The update user.</summary>
        /// <param name="username">The username.</param>
        /// <param name="enabled">The enabled.</param>
        void UpdateUser(string username, bool enabled);

        /// <summary>The user exists and enabled.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool UserExistsAndEnabled(string username);

        #endregion
    }
}