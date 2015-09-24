// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilePrincipal.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.Entities
{
    using System;

    using Phoenix.PhoenixApp.Presentation.Seedwork;

    /// <summary>The profile prinicipal.</summary>
    public class ProfilePrincipal : IProfilePrincipal
    {
        #region Public Properties

        /// <summary>Gets or sets the current club team.</summary>
        public string CurrentClubTeam { get; set; }

        /// <summary>Gets or sets the current management company.</summary>
        public string CurrentManagementCompany { get; set; }

        /// <summary>Gets or sets the current playing position.</summary>
        public string CurrentPlayingPosition { get; set; }
        public string Sport { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        public string FullName { get; set; }

        /// <summary>Gets or sets the id.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        public string LastName { get; set; }
        public string UserName { get; set; }

        #endregion
    }
}