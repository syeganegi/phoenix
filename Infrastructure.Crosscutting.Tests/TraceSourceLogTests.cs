// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraceSourceLogTests.cs" company="">
//   
// </copyright>
// <summary>
//   The trace source log test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Crosscutting.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging;

    /// <summary>
    /// The trace source log test.
    /// </summary>
    [TestClass]
    public class TraceSourceLogTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// The class initialze.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        [ClassInitialize]
        public static void ClassInitialze(TestContext context)
        {
            // Initialize default log factory
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
        }

        /// <summary>
        /// The log debug with exception.
        /// </summary>
        [TestMethod]
        public void LogDebugWithException()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.Debug("{0}", new ArgumentNullException("param"), "the debug mesage");
        }

        /// <summary>
        /// The log debug with message.
        /// </summary>
        [TestMethod]
        public void LogDebugWithMessage()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.Debug("{0}", "the debug mesage");
        }

        /// <summary>
        /// The log debug with object.
        /// </summary>
        [TestMethod]
        public void LogDebugWithObject()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.Debug(new object());
        }

        /// <summary>
        /// The log error.
        /// </summary>
        [TestMethod]
        public void LogError()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.LogError("{0}", "the error message");
        }

        /// <summary>
        /// The log error with exception.
        /// </summary>
        [TestMethod]
        public void LogErrorWithException()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.LogError("{0}", new ArgumentNullException("param"), "the error message");
        }

        /// <summary>
        /// The log fatal with exception.
        /// </summary>
        [TestMethod]
        public void LogFatalWithException()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.Fatal("{0}", new ArgumentNullException("param"), "the debug mesage");
        }

        /// <summary>
        /// The log fatal with message.
        /// </summary>
        [TestMethod]
        public void LogFatalWithMessage()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.Fatal("{0}", "the debug mesage");
        }

        /// <summary>
        /// The log info.
        /// </summary>
        [TestMethod]
        public void LogInfo()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.LogInfo("{0}", "the info message");
        }

        /// <summary>
        /// The log warning.
        /// </summary>
        [TestMethod]
        public void LogWarning()
        {
            // Arrange
            ILogger log = LoggerFactory.CreateLog();

            // Act
            log.LogWarning("{0}", "the warning message");
        }

        #endregion
    }
}