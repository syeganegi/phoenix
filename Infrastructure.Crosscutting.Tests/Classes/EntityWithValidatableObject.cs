// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityWithValidatableObject.cs" company="">
//   
// </copyright>
// <summary>
//   The entity with validatable object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Infrastructure.Crosscutting.Tests.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The entity with validatable object.
    /// </summary>
    internal class EntityWithValidatableObject : IValidatableObject
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the required property.
        /// </summary>
        public string RequiredProperty { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="validationContext">
        /// The validation context.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.RequiredProperty))
            {
                validationResults.Add(new ValidationResult("Invalid Required property", new[] { "RequiredProperty" }));
            }

            return validationResults;
        }

        #endregion
    }
}