// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectionsExtensionMethods.cs" company="">
//   
// </copyright>
// <summary>
//   The projections extension methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.Seedwork
{
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// The projections extension methods.
    /// </summary>
    public static class ProjectionsExtensionMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// Project a type using a DTO
        /// </summary>
        /// <typeparam name="TProjection">
        /// The dto projection
        /// </typeparam>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The projected type
        /// </returns>
        public static TProjection ProjectedAs<TProjection>(this ModelBase item) where TProjection : class, new()
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">
        /// The dtop projection type
        /// </typeparam>
        /// <param name="items">
        /// the collection of entity items
        /// </param>
        /// <returns>
        /// Projected collection
        /// </returns>
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<ModelBase> items)
            where TProjection : class, new()
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        #endregion
    }
}