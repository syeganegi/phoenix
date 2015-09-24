// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityValidator.cs" company="">
//   
// </copyright>
// <summary>
//   The entity validator base contract
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The entity validator base contract
    /// </summary>
    public interface IEntityValidator
    {
        #region Public Methods and Operators

        /// <summary>
        /// Return the collection of errors if entity state is not valid
        /// </summary>
        /// <typeparam name="TEntity">
        /// The type of entity
        /// </typeparam>
        /// <param name="item">
        /// The instance with validation errors
        /// </param>
        /// <returns>
        /// A collection of validation errors
        /// </returns>
        IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Perform validation and return if the entity state is valid
        /// </summary>
        /// <typeparam name="TEntity">
        /// The type of entity to validate
        /// </typeparam>
        /// <param name="item">
        /// The instance to validate
        /// </param>
        /// <returns>
        /// True if entity state is valid
        /// </returns>
        bool IsValid<TEntity>(TEntity item) where TEntity : class;

        #endregion
    }
}