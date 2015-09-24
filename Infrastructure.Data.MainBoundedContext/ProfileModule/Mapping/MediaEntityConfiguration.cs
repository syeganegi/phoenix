// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaEntityConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The orderline entity type configuration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg;

    /// <summary>
    /// The Media entity configuration.
    /// </summary>
    internal class MediaEntityConfiguration : EntityTypeConfiguration<Media>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaEntityConfiguration" /> class.
        /// </summary>
        public MediaEntityConfiguration()
        {
            this.HasKey(fs => fs.Id);
            this.Property(p => p.Title).HasMaxLength(256);
            this.Property(p => p.MediaUrl).HasMaxLength(256).IsRequired();
            this.Property(p => p.DateCreated).IsRequired();
            this.HasRequired(a => a.Profile)
                           .WithMany(p => p.Medias)
                           .HasForeignKey(u => u.ProfileId).WillCascadeOnDelete();

            // configure table map
            this.ToTable("Medias");
        }

        #endregion
    }
}