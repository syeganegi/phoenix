// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileViewEntityConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The orderline entity type configuration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;

    /// <summary>
    /// The ProfileView entity configuration.
    /// </summary>
    internal class ProfileViewEntityConfiguration : EntityTypeConfiguration<ProfileView>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileViewEntityConfiguration" /> class.
        /// </summary>
        public ProfileViewEntityConfiguration()
        {
            this.HasKey(fs => fs.Id);

            this.HasRequired(a => a.Viewer)
                           .WithMany()
                           .HasForeignKey(u => u.ViewerId).WillCascadeOnDelete(false);

            this.HasRequired(a => a.Viewed)
                        .WithMany()
                        .HasForeignKey(u => u.ViewedId).WillCascadeOnDelete(true);
            
            // configure table map
            this.ToTable("ProfileViews");
        }

        #endregion
    }
}