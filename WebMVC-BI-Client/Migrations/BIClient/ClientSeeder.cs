using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC_BI_Client.Models;

namespace WebMVC_BI_Client.Migrations.BIClient
{
    public class ClientSeeder
    {
        public static void Run(BIClientDBContext context)
        {
            // Verify if custom client already exist.
            var client = context.Clients.FirstOrDefault(c => c.DNI.Equals("707770777"));
            if(null == client)
            {
                // Create a new client object.
                client = new Client
                {
                    Name = "Gerardo Sanchez",
                    DNI = "707770777",
                    Phone = "2202-9285",
                    Email = "gsanchez@uaca.ac.cr"
                };

                // Include and save client into database.
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }
    }
}