// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Log Factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging
{
    /// <summary>
    /// Log Factory
    /// </summary>
    public static class LoggerFactory
    {
        #region Static Fields

        /// <summary>
        /// The _current log factory.
        /// </summary>
        private static ILoggerFactory _currentLogFactory;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Createt a new <paramref name="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILog"/>
        /// </summary>
        /// <returns>Created ILog</returns>
        public static ILogger CreateLog()
        {
            return (_currentLogFactory != null) ? _currentLogFactory.Create() : null;
        }

        /// <summary>
        /// Set the  log factory to use
        /// </summary>
        /// <param name="logFactory">
        /// Log factory to use
        /// </param>
        public static void SetCurrent(ILoggerFactory logFactory)
        {
            _currentLogFactory = logFactory;
        }

        #endregion
    }
}