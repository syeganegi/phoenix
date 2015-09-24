// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The about DTO.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System.Collections.Generic;

    /// <summary>
    ///     The about DTO.
    /// </summary>
    public class ContactDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the address address line1.
        /// </summary>
        /// <value>
        ///     The address address line1.
        /// </value>
        public string AddressAddressLine1 { get; set; }

        /// <summary>
        ///     Gets or sets the address address line2.
        /// </summary>
        /// <value>
        ///     The address address line2.
        /// </value>
        public string AddressAddressLine2 { get; set; }

        /// <summary>
        ///     Gets or sets the address city.
        /// </summary>
        /// <value>
        ///     The address city.
        /// </value>
        public string AddressCity { get; set; }

        /// <summary>
        ///     Gets or sets the address zip code.
        /// </summary>
        /// <value>
        ///     The address zip code.
        /// </value>
        public string AddressZipCode { get; set; }

        /// <summary>
        ///     Gets or sets the emails.
        /// </summary>
        public string Email { get; set; }

        /// <summary>Gets or sets the home phone.</summary>
        public string HomePhone { get; set; }

        /// <summary>
        ///     Gets or sets the instance messages.
        /// </summary>
        public IList<InstanceMessageDTO> InstanceMessages { get; set; }

        /// <summary>Gets or sets the mobile phone.</summary>
        public string MobilePhone { get; set; }

        /// <summary>
        ///     Gets or sets the website.
        /// </summary>
        public string Website { get; set; }

        /// <summary>Gets or sets the work phone.</summary>
        public string WorkPhone { get; set; }

        #endregion
    }
}