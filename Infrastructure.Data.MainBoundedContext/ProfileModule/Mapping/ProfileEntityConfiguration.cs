﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileEntityConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The Profile entity type configuration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;

    /// <summary>
    /// The Profile entity type configuration
    /// </summary>
    internal class ProfileEntityConfiguration : EntityTypeConfiguration<Profile>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEntityConfiguration"/> class. 
        /// Create a new instance of Profile entity configuration
        /// </summary>
        public ProfileEntityConfiguration()
        {
            // configure keys and properties
            this.HasKey(c => c.Id);

            // TODO: Make User Id as unique index
            this.Property(c => c.UserName).HasMaxLength(256).IsRequired();

            this.Property(c => c.FirstName).HasMaxLength(50).IsRequired();

            this.Property(c => c.LastName).HasMaxLength(100).IsRequired();

            this.Property(c => c.IsEnabled).IsRequired();

            this.Property(c => c.ViewCounter).IsRequired();

            this.HasMany(c => c.InstanceMessages) // 1..*
                .WithRequired().HasForeignKey(i => i.ProfileId).WillCascadeOnDelete();

            // configure associations
            this.HasRequired(c => c.Picture) // this is a table-splitting
                .WithRequiredPrincipal();

            // configure table map
            this.ToTable("Profiles");
        }

        #endregion
    }
}