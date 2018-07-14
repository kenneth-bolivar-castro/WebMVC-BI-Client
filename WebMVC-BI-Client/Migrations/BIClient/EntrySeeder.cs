using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC_BI_Client.Models;

namespace WebMVC_BI_Client.Migrations.BIClient
{
    public class EntrySeeder
    {
        public static void Run(BIClientDBContext context)
        {
            //
            string[] items = new string[] {
                "Cocina de gas con horno",
                "Aire acondicionado 12 000 VTU"
            };

            //
            foreach (string item in items)
            {
                //
                var entry = context.Entries.FirstOrDefault(e => e.Item == item);
                if (null == entry)
                {
                    //
                    entry = new Entry
                    {
                        Date = DateTime.Now,
                        Comments = "A comment related to current item",
                        Client = context.Clients.First(),
                        User = context.Users.First(),
                        Item = item,
                        Status = EntryStatus.Solicitud
                    };

                    //
                    context.Entries.Add(entry);
                    context.SaveChanges();
                }
            }
        }
    }
}