// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostEntityConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The orderline entity type configuration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;

    /// <summary>
    /// The Post entity configuration.
    /// </summary>
    internal class PostEntityConfiguration : EntityTypeConfiguration<Post>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PostEntityConfiguration" /> class.
        /// </summary>
        public PostEntityConfiguration()
        {
            this.HasKey(fs => fs.Id);
            this.Property(p => p.Title).HasMaxLength(256).IsRequired();
            this.HasRequired(a => a.Profile)
                           .WithMany(p => p.Posts)
                           .HasForeignKey(u => u.ProfileId).WillCascadeOnDelete();

            // configure table map
            this.ToTable("Posts");
        }

        #endregion
    }
}