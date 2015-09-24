// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilePictureEntityConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The picture entity type configuration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;

    /// <summary>
    /// The picture entity type configuration
    /// </summary>
    internal class ProfilePictureEntityConfiguration : EntityTypeConfiguration<ProfilePicture>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePictureEntityConfiguration"/> class. 
        /// Create a new instance of picture entity type configuration
        /// </summary>
        public ProfilePictureEntityConfiguration()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.RawPhoto).IsOptional();

            this.ToTable("Profiles");
        }

        #endregion
    }
}