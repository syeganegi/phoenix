// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeAdapterFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The type adapter factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter
{
    /// <summary>
    /// The type adapter factory.
    /// </summary>
    public static class TypeAdapterFactory
    {
        #region Static Fields

        /// <summary>
        /// The _current type adapter factory.
        /// </summary>
        private static ITypeAdapterFactory _currentTypeAdapterFactory;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Create a new type adapter from currect factory
        /// </summary>
        /// <returns>Created type adapter</returns>
        public static ITypeAdapter CreateAdapter()
        {
            return _currentTypeAdapterFactory.Create();
        }

        /// <summary>
        /// Set the current type adapter factory
        /// </summary>
        /// <param name="adapterFactory">
        /// The adapter factory to set
        /// </param>
        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            _currentTypeAdapterFactory = adapterFactory;
        }

        #endregion
    }
}