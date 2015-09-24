// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Phoenix Pty Ltd" file="MainBCUnitOfWork.cs">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Mapping;
    using Phoenix.PhoenixApp.Infrastructure.Data.Seedwork;

    /// <summary>
    ///     The main bc unit of work.
    /// </summary>
    public class MainBCUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        #region Fields

        private IDbSet<Post> posts;

        private IDbSet<Media> medias;

        /// <summary>The friendships.</summary>
        private IDbSet<Friendship> friendships;

        /// <summary>
        ///     The profile pictures.
        /// </summary>
        private IDbSet<ProfilePicture> profilePictures;

        /// <summary>The profile views.</summary>
        private IDbSet<ProfileView> profileViews;

        /// <summary>
        ///     The profiles.
        /// </summary>
        private IDbSet<Profile> profiles;
        private IDbSet<DeletedProfile> deletedProfiles;

        #endregion

        #region Public Properties

        /// <summary>
        ///     The friendRequests.
        /// </summary>
        public IDbSet<Friendship> Friendships
        {
            get
            {
                return this.friendships ?? (this.friendships = this.Set<Friendship>());
            }
        }

        public IDbSet<Post> Posts
        {
            get
            {
                return this.posts ?? (this.posts = this.Set<Post>());
            }
        }

        public IDbSet<Media> Medias
        {
            get
            {
                return this.medias ?? (this.medias = this.Set<Media>());
            }
        }

        /// <summary>
        ///     Gets the profile pictures.
        /// </summary>
        public IDbSet<ProfilePicture> ProfilePictures
        {
            get
            {
                return this.profilePictures ?? (this.profilePictures = this.Set<ProfilePicture>());
            }
        }

        /// <summary>
        ///     The friendRequests.
        /// </summary>
        public IDbSet<ProfileView> ProfileViews
        {
            get
            {
                return this.profileViews ?? (this.profileViews = this.Set<ProfileView>());
            }
        }

        /// <summary>
        ///     Gets the profiles.
        /// </summary>
        public IDbSet<Profile> Profiles
        {
            get
            {
                return this.profiles ?? (this.profiles = this.Set<Profile>());
            }
        }

        public IDbSet<DeletedProfile> DeletedProfiles
        {
            get
            {
                return this.deletedProfiles ?? (this.deletedProfiles = this.Set<DeletedProfile>());
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The apply current values.</summary>
        /// <param name="original">The original.</param>
        /// <param name="current">The current.</param>
        /// <typeparam name="TEntity"></typeparam>
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            // if it is not attached, attach original and set current values
            this.Entry(original).CurrentValues.SetValues(current);
        }

        /// <summary>The attach.</summary>
        /// <param name="item">The item.</param>
        /// <typeparam name="TEntity"></typeparam>
        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            // attach and set as unchanged
            this.Entry(item).State = EntityState.Unchanged;
        }

        /// <summary>
        ///     The commit.
        /// </summary>
        public void Commit()
        {
            this.SaveChanges();
        }

        /// <summary>
        ///     The commit and refresh changes.
        /// </summary>
        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    this.SaveChanges();

                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList().ForEach(entry => { entry.OriginalValues.SetValues(entry.GetDatabaseValues()); });
                }
            }
            while (saveFailed);
        }

        /// <summary>
        ///     The create set.
        /// </summary>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="DbSet" />.
        /// </returns>
        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        /// <summary>The execute command.</summary>
        /// <param name="sqlCommand">The sql command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        /// <summary>The execute query.</summary>
        /// <param name="sqlQuery">The sql query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        /// <summary>
        ///     The rollback changes.
        /// </summary>
        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            base.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

        /// <summary>The set modified.</summary>
        /// <param name="item">The item.</param>
        /// <typeparam name="TEntity"></typeparam>
        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            // this operation also attach item in object state manager
            this.Entry(item).State = EntityState.Modified;
        }

        #endregion

        #region Methods

        /// <summary>The on model creating.</summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove unused conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Add entity configurations in a structured way using 'TypeConfiguration’ classes
            modelBuilder.Configurations.Add(new ProfileEntityConfiguration());
            modelBuilder.Configurations.Add(new DeletedProfileEntityConfiguration());
            modelBuilder.Configurations.Add(new ProfileViewEntityConfiguration());
            modelBuilder.Configurations.Add(new ProfilePictureEntityConfiguration());
            modelBuilder.Configurations.Add(new FriendshipEntityConfiguration());
            modelBuilder.Configurations.Add(new PostEntityConfiguration());
            modelBuilder.Configurations.Add(new MediaEntityConfiguration());
        }

        #endregion
    }
}