// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountMvcService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The account service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.Transactions;

    using Microsoft.Web.WebPages.OAuth;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Resources;
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    using WebMatrix.WebData;

    /// <summary>
    ///     The account service.
    /// </summary>
    public class AccountMvcService : IAccountMvcService
    {
        #region Fields

        /// <summary>The profile client.</summary>
        private readonly ProfileModuleServiceClient profileClient;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountMvcService" /> class.
        /// </summary>
        public AccountMvcService()
        {
            this.profileClient = new ProfileModuleServiceClient();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The add new external account profile.</summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider user id.</param>
        /// <param name="model">The model.</param>
        /// <exception cref="Exception"></exception>
        public void AddNewExternalAccountProfile(
            string provider, string providerUserId, RegisterExternalLoginModel model)
        {
            // Insert a new user into the database
            using (var db = new UsersContext())
            {
                UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

                // Check if user already exists
                if (user != null)
                {
                    throw new ServiceAgentException("UserName", Messages.error_User_name_already_exists);
                }

                using (var scope = new TransactionScope())
                {
                    // Insert name into the profile table
                    db.UserProfiles.Add(new UserProfile { UserName = model.UserName, IsEnabled = true });
                    db.SaveChanges();

                    // profile piture
                    byte[] picture = this.GetProfilePicture(provider, providerUserId);

                    // adds the user profile
                    this.profileClient.AddNewProfile(
                        new ProfileDTO
                            {
                                Birthday = model.Birthday.ToDate(), 
                                FirstName = model.FirstName, 
                                LastName = model.LastName, 
                                Sex = model.Sex.ToString(), 
                                Email = model.Email, 
                                UserName = model.UserName, 
                                PictureRawPhoto = picture
                            });

                    OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                    scope.Complete();
                }
            }
        }

        /// <summary>The add new local account profile.</summary>
        /// <param name="model">The model.</param>
        public void AddNewLocalAccountProfile(RegisterModel model)
        {
            using (var scope = new TransactionScope())
            {
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { IsEnabled = true });

                // adds the user profile
                this.profileClient.AddNewProfile(
                    new ProfileDTO
                        {
                            Birthday = model.Birthday.ToDate(), 
                            FirstName = model.FirstName, 
                            LastName = model.LastName, 
                            Sex = model.Sex.ToString(), 
                            Email = model.Email, 
                            UserName = model.UserName, 
                            PictureRawPhoto = model.PictureRawPhoto
                        });
                scope.Complete();
            }
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            try
            {
                if (this.profileClient.State != CommunicationState.Faulted)
                {
                    this.profileClient.Close();
                }
            }
            catch (Exception)
            {
                this.profileClient.Abort();
            }
        }

        /// <summary>The update user.</summary>
        /// <param name="username">The username.</param>
        /// <param name="enabled">The enabled.</param>
        public void UpdateUser(string username, bool enabled)
        {
            using (var db = new UsersContext())
            {
                UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == username);
                if (user == null)
                {
                    return;
                }

                user.IsEnabled = enabled;
                db.SaveChanges();
            }
        }

        /// <summary>The user exists and enabled.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool UserExistsAndEnabled(string username)
        {
            bool resultOk;
            using (var db = new UsersContext())
            {
                UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == username);
                resultOk = user == null || user.IsEnabled;
            }

            return resultOk;
        }

        #endregion

        #region Methods

        /// <summary>Gets the profile picture.</summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider user id.</param>
        /// <returns>The profile picture.</returns>
        private byte[] GetProfilePicture(string provider, string providerUserId)
        {
            if (provider.Equals("facebook", StringComparison.OrdinalIgnoreCase))
            {
                return FacebookHelper.GetProfilePicture(providerUserId);
            }

            return null;
        }

        #endregion
    }
}