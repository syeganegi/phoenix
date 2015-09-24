// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendshipStatus.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The friendship status type
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg
{
    /// <summary>
    ///     The friendship status type
    /// </summary>
    public enum FriendshipStatus
    {
        /// <summary>
        ///     The unknown.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The requested.
        /// </summary>
        Requested,

        /// <summary>
        ///     The accepted
        /// </summary>
        Accepted, 

        /// <summary>
        ///     The rejected
        /// </summary>
        Rejected, 

        /// <summary>
        ///     The banned
        /// </summary>
        Banned, 
    }
}