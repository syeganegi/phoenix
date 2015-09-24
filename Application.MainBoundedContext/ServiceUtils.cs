// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceUtils.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Application.MainBoundedContext
{
    using System;

    /// <summary>The service utils.</summary>
    public sealed class ServiceUtils
    {
        #region Public Methods and Operators

        /// <summary>The get total number of pages.</summary>
        /// <param name="numberOfItemsFound">The number of items found.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int GetTotalNumberOfPages(int numberOfItemsFound, int pageSize)
        {
            if (pageSize == 0)
            {
                return 0;
            }

            return (int)Math.Ceiling(numberOfItemsFound / (double)pageSize);
        }

        #endregion
    }
}