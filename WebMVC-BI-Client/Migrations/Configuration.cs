namespace WebMVC_BI_Client.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebMVC_BI_Client.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebMVC_BI_Client.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebMVC_BI_Client.Models.ApplicationDbContext";
        }

        protected override void Seed(WebMVC_BI_Client.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Seed application users.
            ApplicationUsersSeeder.run(context);
        }
        
    }
}
