// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileSearchResult.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The profile search result.</summary>
    public class ProfileSearchResult : ValueObject<ProfileSearchResult>
    {
        #region Public Properties

        /// <summary>Gets or sets the friendship.</summary>
        public Friendship Friendship { get; set; }

        /// <summary>Gets or sets the profile.</summary>
        public Profile Profile { get; set; }

        #endregion
    }
}