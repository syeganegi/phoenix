namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork.MainBCUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            // http://blog.oneunicorn.com/2012/02/27/code-first-migrations-making-__migrationhistory-not-a-system-table/
            SetSqlGenerator("System.Data.SqlClient", new NonSystemTableSqlGenerator());
        }

        protected override void Seed(Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork.MainBCUnitOfWork context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
