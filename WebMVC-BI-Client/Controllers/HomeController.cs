using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC_BI_Client.Models;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity.Owin;

namespace WebMVC_BI_Client.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private BIClientDBContext context = new BIClientDBContext();

        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public async Task<ActionResult> Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            var result = (from e in context.Entries
                        group e by e.UserId into g
                        select new
                        {
                            UserId = g.Key,
                            Count = g.Count()
                        }).ToList();

            var manager = UserManager;
            foreach(var row in result)
            {
                var user = await manager.FindByIdAsync(row.UserId);
                dataPoints.Add(new DataPoint(user.UserName, row.Count));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}