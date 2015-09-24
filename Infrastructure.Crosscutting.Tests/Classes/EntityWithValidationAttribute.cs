// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityWithValidationAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The entity with validation attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Infrastructure.Crosscutting.Tests.Classes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The entity with validation attribute.
    /// </summary>
    internal class EntityWithValidationAttribute
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the required property.
        /// </summary>
        [Required(ErrorMessage = "This is a required property")]
        public string RequiredProperty { get; set; }

        #endregion
    }
}