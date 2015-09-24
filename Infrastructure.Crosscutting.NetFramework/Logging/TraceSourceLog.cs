// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraceSourceLog.cs" company="">
//   
// </copyright>
// <summary>
//   Implementation of contract <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger" />
//   using System.Diagnostics API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Security;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging;

    /// <summary>
    /// Implementation of contract <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
    /// using System.Diagnostics API.
    /// </summary>
    public sealed class TraceSourceLog : ILogger
    {
        #region Fields

        /// <summary>
        /// The source.
        /// </summary>
        private readonly TraceSource source;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TraceSourceLog"/> class. 
        /// Create a new instance of this trace manager
        /// </summary>
        public TraceSourceLog()
        {
            // Create default source
            this.source = new TraceSource("PhoenixApp");
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void Debug(string message, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                this.TraceInternal(TraceEventType.Verbose, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="exception">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void Debug(string message, Exception exception, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message) && exception != null)
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                string exceptionData = exception.ToString();
                    
                    // The ToString() create a string representation of the current exception
                this.TraceInternal(
                    TraceEventType.Error, 
                    string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="item">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void Debug(object item)
        {
            if (item != null)
            {
                this.TraceInternal(TraceEventType.Verbose, item.ToString());
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void Fatal(string message, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                this.TraceInternal(TraceEventType.Critical, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="exception">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message) && exception != null)
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                string exceptionData = exception.ToString();
                    
                    // The ToString() create a string representation of the current exception
                this.TraceInternal(
                    TraceEventType.Critical, 
                    string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void LogError(string message, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                this.TraceInternal(TraceEventType.Error, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="exception">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void LogError(string message, Exception exception, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message) && exception != null)
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                string exceptionData = exception.ToString();
                    
                    // The ToString() create a string representation of the current exception
                this.TraceInternal(
                    TraceEventType.Error, 
                    string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void LogInfo(string message, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                this.TraceInternal(TraceEventType.Information, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </summary>
        /// <param name="message">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        /// <param name="args">
        /// <see cref="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILogger"/>
        /// </param>
        public void LogWarning(string message, params object[] args)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                this.TraceInternal(TraceEventType.Warning, messageToTrace);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Trace internal message in configured listeners
        /// </summary>
        /// <param name="eventType">
        /// Event type to trace
        /// </param>
        /// <param name="message">
        /// Message of event
        /// </param>
        private void TraceInternal(TraceEventType eventType, string message)
        {
            if (this.source != null)
            {
                try
                {
                    this.source.TraceEvent(eventType, (int)eventType, message);
                }
                catch (SecurityException)
                {
                    // Cannot access to file listener or cannot have
                    // privileges to write in event log etc...
                }
            }
        }

        #endregion
    }
}