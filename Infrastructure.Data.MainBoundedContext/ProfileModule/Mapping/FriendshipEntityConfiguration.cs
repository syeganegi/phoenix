// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipEntityConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The orderline entity type configuration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.ProfileModule.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;

    /// <summary>
    /// The Friendship entity configuration.
    /// </summary>
    internal class FriendshipEntityConfiguration : EntityTypeConfiguration<Friendship>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FriendshipEntityConfiguration" /> class.
        /// </summary>
        public FriendshipEntityConfiguration()
        {
            this.HasKey(fs => fs.Id);

            this.HasRequired(a => a.Initiator)
                           .WithMany(p => p.Initiators)
                           .HasForeignKey(u => u.InitiatorId).WillCascadeOnDelete();

            this.HasRequired(a => a.Acceptor)
                        .WithMany(p => p.Acceptors)
                        .HasForeignKey(u => u.AcceptorId);

            // configure table map
            this.ToTable("Friendships");
        }

        #endregion
    }
}