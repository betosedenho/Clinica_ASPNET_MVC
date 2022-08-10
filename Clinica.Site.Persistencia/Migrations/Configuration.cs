namespace Clinica.Site.Persistencia.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Clinica.Site.Persistencia.Context.ClinicaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            var hist = GetHistoryContextFactory("System.Data.SqlClient");
            SetHistoryContextFactory("System.Data.SqlClient", (dbc, schema) => hist.Invoke(dbc, "clinica"));
        }

        protected override void Seed(Clinica.Site.Persistencia.Context.ClinicaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
