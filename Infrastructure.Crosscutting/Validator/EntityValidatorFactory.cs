// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityValidatorFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Entity Validator Factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator
{
    /// <summary>
    /// Entity Validator Factory
    /// </summary>
    public static class EntityValidatorFactory
    {
        #region Static Fields

        /// <summary>
        /// The _factory.
        /// </summary>
        private static IEntityValidatorFactory _factory;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Createt a new <paramref name="Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging.ILog"/>
        /// </summary>
        /// <returns>Created ILog</returns>
        public static IEntityValidator CreateValidator()
        {
            return (_factory != null) ? _factory.Create() : null;
        }

        /// <summary>
        /// Set the  log factory to use
        /// </summary>
        /// <param name="factory">
        /// Log factory to use
        /// </param>
        public static void SetCurrent(IEntityValidatorFactory factory)
        {
            _factory = factory;
        }

        #endregion
    }
}