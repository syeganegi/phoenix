// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTOBase.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.Seedwork
{
    using System;

    /// <summary>The dto base.</summary>
    public abstract class DTOBase
    {
        #region Public Properties

        /// <summary>Gets or sets the id.</summary>
        public Guid Id { get; set; }

        #endregion
    }
}