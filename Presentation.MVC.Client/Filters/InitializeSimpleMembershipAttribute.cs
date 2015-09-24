// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitializeSimpleMembershipAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The initialize simple membership attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Filters
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Security;

    using Phoenix.PhoenixApp.Presentation.MVC.Common.Helpers;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    using WebMatrix.WebData;

    /// <summary>
    /// The initialize simple membership attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        #region Static Fields

        /// <summary>
        /// The _initializer.
        /// </summary>
        private static SimpleMembershipInitializer _initializer;

        /// <summary>
        /// The _initializer lock.
        /// </summary>
        private static object _initializerLock = new object();

        /// <summary>
        /// The _is initialized.
        /// </summary>
        private static bool _isInitialized;

        private const string AdminUsername = "administrator";
        private const string AdminRolename = "Administrator";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_isInitialized)
            {
                return;
            }

            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        #endregion

        /// <summary>
        /// The simple membership initializer.
        /// </summary>
        private class SimpleMembershipInitializer
        {
            private readonly IAccountMvcService accountService;

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="SimpleMembershipInitializer"/> class.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// </exception>
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);
                this.accountService = new AccountMvcService();

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection(
                        "PhoenixConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                    // creating default admin role
                    if (!Roles.RoleExists(AdminRolename))
                    {
                        Roles.CreateRole(AdminRolename);
                    }

                    // creating default admin user and profile
                    if (!WebSecurity.UserExists(AdminUsername))
                    {
                        var model = new RegisterModel
                                        {
                                            UserName = AdminUsername,
                                            Password = "adminSecret",
                                            Birthday = new Birthday(1980, 1, 1),
                                            Email = "Administrator@esione.com",
                                            FirstName = "Admin",
                                            LastName = "Admin",
                                            Sex = Sex.Male
                                        };
                        byte[] picture = PictureHelper.GetDefaultProfileImage();
                        model.PictureRawPhoto = PictureHelper.ResizePicture(picture);
                        this.accountService.AddNewLocalAccountProfile(model);

                        if (!Roles.RoleExists(AdminRolename))
                        {
                            Roles.CreateRole(AdminRolename);
                            Roles.AddUserToRole(AdminUsername, AdminRolename);
                        }
                    }

                    // adding default admin user to Administrator role
                    if (!Roles.IsUserInRole(AdminUsername, AdminRolename))
                    {
                        Roles.AddUserToRole(AdminUsername, AdminRolename);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        "The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", 
                        ex);
                }
            }

            #endregion
        }
    }
}