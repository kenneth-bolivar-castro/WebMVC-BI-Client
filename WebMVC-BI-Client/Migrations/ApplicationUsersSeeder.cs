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
        public static void Run(ApplicationDbContext context)
        {
            // Create user store and manager.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            // Load user entity.
            var user = userManager.Users.FirstOrDefault(u => u.UserName == "admin");

            // Verify that "admin" user already exists.
            if (null == user)
            {
                // Create new user instance.
                user = new ApplicationUser
                {
                    UserName = "admin",
                    ApiToken = Guid.NewGuid().ToString()
                };

                // Finally create it within database also defining a password that will be hashed.
                userManager.Create(user, "S3cr3t!");
            }

            // Create role store and manager.
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            //
            string[] roleNames = { "Admin", "User" };
            foreach (string roleName in roleNames)
            {
                // Verify that given role name exists.
                if(roleManager.RoleExists(roleName))
                {
                    continue;
                }

                // Create new role entity.
                var role = new IdentityRole(roleName);
                roleManager.Create(role);
            }

            userManager.AddToRole(user.Id, "Admin");
        }
    }
}