// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraceSourceLogFactory.cs" company="">
//   
// </copyright>
// <summary>
//   A Trace Source base, log factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging
{
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging;

    /// <summary>
    /// A Trace Source base, log factory
    /// </summary>
    public class TraceSourceLogFactory : ILoggerFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public ILogger Create()
        {
            return new TraceSourceLog();
        }

        #endregion
    }
}