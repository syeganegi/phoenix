// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Media.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The media.</summary>
    public class Media : Entity, IValidatableObject
    {
        #region Public Properties

        /// <summary>Gets or sets the date created.</summary>
        public DateTime DateCreated { get; set; }

        /// <summary>Gets or sets the media url.</summary>
        public string MediaUrl { get; set; }

        /// <summary>Gets or sets the profile.</summary>
        public Profile Profile { get; set; }

        /// <summary>Gets or sets the profile id.</summary>
        public Guid ProfileId { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the type.</summary>
        public MediaType Type { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The validate.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.MediaUrl))
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_MediaUrlCannotBeEmpty, new[] { "MediaUrl" }));
            }

            if (this.ProfileId == Guid.Empty)
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_MediaProfileIdCannotBeEmpty, new[] { "ProfileId" }));
            }

            return validationResults;
        }

        #endregion
    }
}