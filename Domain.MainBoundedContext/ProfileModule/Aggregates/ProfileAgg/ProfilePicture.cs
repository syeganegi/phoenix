// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilePicture.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   Picture of customer
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     Picture of customer
    /// </summary>
    public class ProfilePicture : Entity
    {
        #region Public Properties

        /// <summary>
        ///     Get the raw of photo
        /// </summary>
        public byte[] RawPhoto { get; set; }

        #endregion
    }
}