// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LivingDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The living DTO.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    /// <summary>
    ///     The living DTO.
    /// </summary>
    public class LivingDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the current city.
        /// </summary>
        public string CurrentCity { get; set; }

        /// <summary>
        ///     Gets or sets the hometown.
        /// </summary>
        public string Hometown { get; set; }

        /// <summary>Gets or sets the nationality.</summary>
        public string Nationality { get; set; }

        #endregion
    }
}