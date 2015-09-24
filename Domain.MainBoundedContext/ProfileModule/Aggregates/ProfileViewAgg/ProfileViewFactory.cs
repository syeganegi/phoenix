// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileViewFactory.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   This is the factory for ProfileView creation, which means that the main purpose
//   is to encapsulate the creation knowledge.
//   What is created is a transient entity instance, with nothing being said about persistence as yet
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg
{
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;

    /// <summary>
    ///     This is the factory for ProfileView creation, which means that the main purpose
    ///     is to encapsulate the creation knowledge.
    ///     What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class ProfileViewFactory
    {
        #region Public Methods and Operators

        /// <summary>The create profile view.</summary>
        /// <param name="viewer">The viewer.</param>
        /// <param name="viewed">The viewed.</param>
        /// <returns>The <see cref="ProfileView"/>.</returns>
        public static ProfileView CreateProfileView(Profile viewer, Profile viewed)
        {
            var profileView = new ProfileView();
            profileView.GenerateNewIdentity();
            profileView.SetViewed(viewed);
            profileView.SetViewer(viewer);

            return profileView;
        }

        #endregion
    }
}