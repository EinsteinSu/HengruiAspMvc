using System.Data.Entity.Migrations;

namespace Hengrui.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HengruiDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Hengrui.DataAccess.HengruiDataContext";
        }

        protected override void Seed(HengruiDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}