// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityValidatorFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Base contract for entity validator abstract factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator
{
    /// <summary>
    /// Base contract for entity validator abstract factory
    /// </summary>
    public interface IEntityValidatorFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Create a new IEntityValidator
        /// </summary>
        /// <returns>IEntityValidator</returns>
        IEntityValidator Create();

        #endregion
    }
}