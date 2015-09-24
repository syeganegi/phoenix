// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NonSystemTableSqlGenerator .cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.Migrations.Sql;

    /// <summary>The non system table sql generator.
    /// http://blog.oneunicorn.com/2012/02/27/code-first-migrations-making-__migrationhistory-not-a-system-table/
    /// </summary>
    public class NonSystemTableSqlGenerator : SqlServerMigrationSqlGenerator
    {
        #region Methods

        /// <summary>The generate make system table.</summary>
        /// <param name="createTableOperation">The create table operation.</param>
        protected override void GenerateMakeSystemTable(CreateTableOperation createTableOperation)
        {
        }

        #endregion
    }
}