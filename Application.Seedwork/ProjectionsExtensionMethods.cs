// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectionsExtensionMethods.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.Seedwork
{
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Domain.Seedwork;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    ///     The projections extension methods.
    /// </summary>
    public static class ProjectionsExtensionMethods
    {
        #region Public Methods and Operators

        /// <summary>The merge as.</summary>
        /// <param name="source">The dto.</param>
        /// <param name="destination">The entity.</param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        public static TDestination MergeWith<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : class where TDestination : class
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt(source, destination);
        }

        /// <summary>Project a type using a DTO</summary>
        /// <typeparam name="TProjection">The dto projection</typeparam>
        /// <param name="item">The item.</param>
        /// <returns>The projected type</returns>
        public static TProjection ProjectedAs<TSource, TProjection>(this TSource item) where TSource : class
            where TProjection : class, new()
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        public static TProjection ProjectedAs<TProjection>(this Entity item)
            where TProjection : class, new()
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }
        /// <summary>The projected as collection.</summary>
        /// <param name="items">The items.</param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProjection"></typeparam>
        /// <returns>The <see cref="List"/>.</returns>
        public static List<TProjection> ProjectedAsCollection<TSource, TProjection>(this IEnumerable<TSource> items)
            where TSource : class
            where TProjection : class, new()
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        /// <summary>projected a enumerable collection of items</summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<Entity> items)
            where TProjection : class, new()
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        #endregion
    }
}