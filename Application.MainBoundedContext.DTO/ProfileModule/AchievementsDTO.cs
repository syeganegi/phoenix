// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AchievementsDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The about DTO.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    /// <summary>
    ///     The about DTO.
    /// </summary>
    public class AchievementsDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the about.
        /// </summary>
        /// <value>
        ///     The about.
        /// </value>
        public string Achievements { get; set; }

        #endregion
    }
}