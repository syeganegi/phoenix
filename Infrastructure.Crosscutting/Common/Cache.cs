// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cache.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common
{
    using System;
    using System.Runtime.Caching;

    /// <summary>The cache.</summary>
    public class Cache
    {
        #region Static Fields

        /// <summary>The _cache.</summary>
        private static readonly ObjectCache _cache = MemoryCache.Default;

        #endregion

        #region Public Methods and Operators

        /// <summary>Remove item from cache</summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>The run.</summary>
        /// <param name="func">The func.</param>
        /// <param name="absoluteExpiration">The absolute expiration in seconds.</param>
        /// <param name="prms">The prms.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public static T Run<T>(Func<T> func, int absoluteExpiration, params object[] prms) where T : class
        {
            string key = GetKey(func, prms);

            if (!_cache.Contains(key) || !(_cache[key] is T))
            {
                var policy = new CacheItemPolicy
                                 {
                                     AbsoluteExpiration =
                                         DateTimeOffset.Now.AddSeconds(absoluteExpiration)
                                 };
                var o = func();
                if (o == null)
                {
                    return null;
                }

                _cache.Set(key, func(), policy);
            }

            return (T)_cache[key];
        }

        #endregion

        #region Methods

        /// <summary>The get key.</summary>
        /// <param name="func">The func.</param>
        /// <param name="prms">The prms.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetKey<T>(Func<T> func, params object[] prms)
        {
            string method = func.Method.DeclaringType + "." + func.Method.Name;
            string type = typeof(T).FullName;

            return string.Format("{0}_{1}_{2}", method, type, string.Join("_", prms));
        }

        #endregion
    }
}