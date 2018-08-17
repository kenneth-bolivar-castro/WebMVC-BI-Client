using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMVC_BI_Client.Models
{
    public class BIClientDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BIClientDBContext() : base("DefaultConnection")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<UsersData> UsersData { get; set; }

        public DbSet<Entry> Entries { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsersData>().ToTable("AspNetUsers");
        }

       
    }
}
