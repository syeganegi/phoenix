// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileView.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     The profile view.
    /// </summary>
    public class ProfileView : Entity, IValidatableObject
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfileView" /> class.
        /// </summary>
        public ProfileView()
        {
            this.DateViewed = DateTime.UtcNow;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the date viewed.
        /// </summary>
        public DateTime DateViewed { get; set; }

        /// <summary>Gets or sets the viewed.</summary>
        public Profile Viewed { get; set; }

        /// <summary>
        ///     Gets or sets the viewed id.
        /// </summary>
        public Guid ViewedId { get; set; }

        /// <summary>Gets or sets the viewer.</summary>
        public Profile Viewer { get; set; }

        /// <summary>
        ///     Gets or sets the viewer id.
        /// </summary>
        public Guid ViewerId { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Sets the viewed.</summary>
        /// <param name="viewed">The viewed.</param>
        /// <exception cref="System.ArgumentException">Cannot Associate Transient Or Null Viewed</exception>
        public void SetViewed(Profile viewed)
        {
            if (viewed == null || viewed.IsTransient())
            {
                throw new ArgumentException(Messages.exception_CannotAssociateTransientOrNullInitiator);
            }

            this.ViewedId = viewed.Id;
        }

        /// <summary>Sets the viewer.</summary>
        /// <param name="viewer">The viewer.</param>
        /// <exception cref="System.ArgumentException">Cannot Associate Transient Or Null Friend1</exception>
        public void SetViewer(Profile viewer)
        {
            if (viewer == null || viewer.IsTransient())
            {
                throw new ArgumentException(Messages.exception_CannotAssociateTransientOrNullAcceptor);
            }

            this.ViewerId = viewer.Id;
        }

        /// <summary>Determines whether the specified object is valid.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A collection that holds failed-validation information.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (this.ViewerId == this.ViewedId)
            {
                validationResults.Add(
                    new ValidationResult(
                        Messages.validation_ProfileViewerCannotBeSame, new[] { "ViewerId", "ViewedId" }));
            }

            return validationResults;
        }

        #endregion
    }
}