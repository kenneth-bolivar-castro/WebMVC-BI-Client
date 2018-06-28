using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC_BI_Client.Models;

namespace WebMVC_BI_Client.Migrations
{
    public class ApplicationUsersSeeder
    {
        public static void run(ApplicationDbContext context)
        {
            if (context.Users.Any(u => u.UserName == "admin"))
            {
                return;
            }

            // Create user store and manager.
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            // Create new user instance.
            var user = new ApplicationUser {
                UserName = "admin",
                ApiToken = Guid.NewGuid().ToString()
            };

            // Finally create it within database also defining a password that will be hashed.
            manager.Create(user, "S3cr3t!");
        }
    }
}