// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeAdapterFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Base contract for adapter factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter
{
    /// <summary>
    /// Base contract for adapter factory
    /// </summary>
    public interface ITypeAdapterFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Create a type adater
        /// </summary>
        /// <returns>The created ITypeAdapter</returns>
        ITypeAdapter Create();

        #endregion
    }
}