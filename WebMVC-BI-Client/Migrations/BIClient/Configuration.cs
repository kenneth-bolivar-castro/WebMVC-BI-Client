namespace WebMVC_BI_Client.Migrations.BIClient
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebMVC_BI_Client.Models.BIClientDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\BIClient";
        }

        protected override void Seed(WebMVC_BI_Client.Models.BIClientDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //
            ClientSeeder.Run(context);

            //
            EntrySeeder.Run(context);
        }
    }
}
