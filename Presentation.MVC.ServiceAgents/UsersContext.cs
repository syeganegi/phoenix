namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents
{
    using System.Data.Entity;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;

    /// <summary>
    /// The users context.
    /// </summary>
    public class UsersContext : DbContext
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersContext"/> class.
        /// </summary>
        public UsersContext()
            : base("PhoenixConnection")
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the user profiles.
        /// </summary>
        public DbSet<UserProfile> UserProfiles { get; set; }

        #endregion
    }
}