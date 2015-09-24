// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceMessage.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The instance message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     The instance message.
    /// </summary>
    public class InstanceMessage : Entity, IValidatableObject
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="InstanceMessage" /> class.
        /// </summary>
        public InstanceMessage()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InstanceMessage"/> class.</summary>
        /// <param name="screenName">The screen name.</param>
        /// <param name="type">The type.</param>
        public InstanceMessage(string screenName, InstanceMessageType type)
        {
            this.ScreenName = screenName;
            this.InstanceMessageType = type;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the instance message type.
        /// </summary>
        public InstanceMessageType InstanceMessageType { get; set; }

        /// <summary>
        ///     Gets or sets the profile id.
        /// </summary>
        public Guid ProfileId { get; set; }

        /// <summary>
        ///     Gets or sets the screen name.
        /// </summary>
        public string ScreenName { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The validate.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (this.ProfileId == Guid.Empty)
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_InstaceMessageProfileIdIsEmpty, new[] { "ProfileId" }));
            }

            if (string.IsNullOrEmpty(this.ScreenName))
            {
                validationResults.Add(
                    new ValidationResult(
                        Messages.validation_InstaceMessageScreenNameCannotBenull, new[] { "ScreenName" }));
            }

            return validationResults;
        }

        #endregion
    }
}