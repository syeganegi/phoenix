// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomapperTypeAdapter.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Adapter
{
    using AutoMapper;

    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    ///     Automapper type adapter implementation
    /// </summary>
    public class AutomapperTypeAdapter : ITypeAdapter
    {
        #region Public Methods and Operators

        /// <summary>The adapt.</summary>
        /// <param name="source">The source.</param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <returns>The <see cref="TTarget"/>.</returns>
        public TTarget Adapt<TSource, TTarget>(TSource source) // where TTarget : new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>The adapt.</summary>
        /// <param name="source">The source.</param>
        /// <typeparam name="TTarget"></typeparam>
        /// <returns>The <see cref="TTarget"/>.</returns>
        public TTarget Adapt<TTarget>(object source) // where TTarget : new()
        {
            return Mapper.Map<TTarget>(source);
        }

        /// <summary>The adapt.</summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        public TDestination Adapt<TSource, TDestination>(TSource source, TDestination destination) 
        {
            return Mapper.Map(source, destination);
        }

        #endregion
    }
}