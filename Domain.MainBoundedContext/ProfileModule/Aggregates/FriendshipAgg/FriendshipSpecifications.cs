// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipSpecifications.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   A list of Friendship specifications. You can learn
//   about Specifications, Enhanced Query Objects or repository methods
//   reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;

    /// <summary>
    ///     A list of Friendship specifications. You can learn
    ///     about Specifications, Enhanced Query Objects or repository methods
    ///     reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
    /// </summary>
    public static class FriendshipSpecifications
    {
        #region Public Methods and Operators

        /// <summary>The existing friendship.</summary>
        /// <param name="initiatorId">The initiator id.</param>
        /// <param name="acceptorId">The acceptor id.</param>
        /// <returns>The <see cref="Specification"/>.</returns>
        public static Specification<Friendship> ExistingFriendship(Guid initiatorId, Guid acceptorId)
        {
            var spec1 =
                new DirectSpecification<Friendship>(fr => fr.AcceptorId == acceptorId && fr.InitiatorId == initiatorId);
            var spec2 =
                new DirectSpecification<Friendship>(fr => fr.InitiatorId == acceptorId && fr.AcceptorId == initiatorId);

            return spec1 || spec2;
        }

        #endregion

        public static Specification<Friendship> FriendRequests(Guid profileId)
        {
            return
                new DirectSpecification<Friendship>(
                    fr => fr.AcceptorId == profileId && fr.Status == FriendshipStatus.Requested);
        }
    }
}