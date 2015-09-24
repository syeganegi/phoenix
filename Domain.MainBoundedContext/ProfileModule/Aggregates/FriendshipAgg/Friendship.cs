// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Friendship.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     The friendship.
    /// </summary>
    public class Friendship : Entity, IValidatableObject
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Friendship" /> class.
        /// </summary>
        public Friendship()
            : this(FriendshipStatus.Unknown)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Friendship"/> class.</summary>
        /// <param name="status">The status.</param>
        public Friendship(FriendshipStatus status)
        {
            this.DateCreated = DateTime.UtcNow;
            this.SetStatus(status);
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the acceptor.</summary>
        public Profile Acceptor { get; set; }

        /// <summary>
        ///     Gets or sets the acceptor id.
        /// </summary>
        public Guid AcceptorId { get; set; }

        /// <summary>
        ///     Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; protected set; }

        /// <summary>
        ///     Gets the state change date.
        /// </summary>
        /// <value>
        ///     The state change date.
        /// </value>
        public DateTime DateStatusChanged { get; private set; }

        /// <summary>Gets or sets the initiator.</summary>
        public Profile Initiator { get; set; }

        /// <summary>
        ///     Gets or sets the initiator id.
        /// </summary>
        public Guid InitiatorId { get; set; }

        /// <summary>
        ///     Gets a value indicating whether is requested.
        /// </summary>
        public bool IsRequested
        {
            get
            {
                return this.Status == FriendshipStatus.Requested;
            }
        }

        /// <summary>
        ///     Gets the type of the status.
        /// </summary>
        /// <value>
        ///     The type of the status.
        /// </value>
        public FriendshipStatus Status { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Changes the state to.</summary>
        /// <param name="state">The state.</param>
        public void SetStatus(FriendshipStatus state)
        {
            this.Status = state;
            this.DateStatusChanged = DateTime.UtcNow;
        }

        /// <summary>Determines whether the specified object is valid.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A collection that holds failed-validation information.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (this.InitiatorId == this.AcceptorId)
            {
                validationResults.Add(
                    new ValidationResult(
                        Messages.validation_FriendshipPartiesCannotBeSame, new[] { "InitiatorId", "AcceptorId" }));
            }

            return validationResults;
        }

        #endregion
    }
}