// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelException.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The model exception.
    /// </summary>
    public class ServiceAgentException : Exception, ISerializable
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAgentException"/> class.
        /// </summary>
        public ServiceAgentException()
        {
            // Add implementation.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAgentException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ServiceAgentException(string message)
            : base(message)
        {
            // Add implementation.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAgentException"/> class.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public ServiceAgentException(string key, string message)
            : base(message)
        {
            this.Key = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAgentException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public ServiceAgentException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation.
        }

        // This constructor is needed for serialization.
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAgentException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected ServiceAgentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation.
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the key.
        /// </summary>
        public string Key { get; private set; }

        #endregion
    }
}