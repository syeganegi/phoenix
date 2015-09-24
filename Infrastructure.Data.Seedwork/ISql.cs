// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISql.cs" company="">
//   
// </copyright>
// <summary>
//   Base contract for support 'dialect specific queries'.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.Seedwork
{
    using System.Collections.Generic;

    /// <summary>
    /// Base contract for support 'dialect specific queries'.
    /// </summary>
    public interface ISql
    {
        #region Public Methods and Operators

        /// <summary>
        /// Execute arbitrary command into underliying persistence store
        /// </summary>
        /// <param name="sqlCommand">
        /// Command to execute
        /// <example>
        /// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer &gt; {0}
        /// </example>
        /// </param>
        /// <param name="parameters">
        /// A vector of parameters values
        /// </param>
        /// <returns>
        /// The number of affected records
        /// </returns>
        int ExecuteCommand(string sqlCommand, params object[] parameters);

        /// <summary>
        /// Execute specific query with underliying persistence store
        /// </summary>
        /// <typeparam name="TEntity">
        /// Entity type to map query results
        /// </typeparam>
        /// <param name="sqlQuery">
        /// Dialect Query 
        /// <example>
        /// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer &gt; {0}
        /// </example>
        /// </param>
        /// <param name="parameters">
        /// A vector of parameters values
        /// </param>
        /// <returns>
        /// Enumerable results 
        /// </returns>
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        #endregion
    }
}