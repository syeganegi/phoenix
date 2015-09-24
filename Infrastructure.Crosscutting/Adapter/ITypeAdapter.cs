// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeAdapter.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter
{
    /// <summary>
    ///     Base contract for map dto to aggregate or aggregate to dto.
    ///     <remarks>
    ///         This is a  contract for work with "auto" mappers ( automapper,emitmapper,valueinjecter...)
    ///         or adhoc mappers
    ///     </remarks>
    /// </summary>
    public interface ITypeAdapter
    {
        #region Public Methods and Operators

        /// <summary>Adapt a source object to an instance of type <paramref name="TTarget"/></summary>
        /// <typeparam name="TSource">Type of source item</typeparam>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns><paramref name="source"/> mapped to <typeparamref name="TTarget"/></returns>
        TTarget Adapt<TSource, TTarget>(TSource source);//where TTarget : new();

        /// <summary>Adapt a source object to an instnace of type <paramref name="TTarget"/></summary>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns><paramref name="source"/> mapped to <typeparamref name="TTarget"/></returns>
        TTarget Adapt<TTarget>(object source); //where TTarget : new();

        /// <summary>The adapt.</summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Adapt<TSource, TDestination>(TSource source, TDestination destination);

        #endregion
    }
}