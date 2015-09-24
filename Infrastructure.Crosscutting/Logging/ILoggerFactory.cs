// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILoggerFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Base contract for Log abstract factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging
{
    /// <summary>
    /// Base contract for Log abstract factory
    /// </summary>
    public interface ILoggerFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Create a new ILog
        /// </summary>
        /// <returns>The ILog created</returns>
        ILogger Create();

        #endregion
    }
}