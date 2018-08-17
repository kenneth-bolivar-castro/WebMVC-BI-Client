using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Collections.Generic;
using System.Globalization;
//using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebMVC_BI_Client.Models;
//using ASPNET_MVC_ChartsDemo.Models;
using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.Web.Mvc;

namespace WebMVC_BI_Client.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {


            // GET: Home
          //  public ActionResult Index()
            
                List<DataPoint> dataPoints = new List<DataPoint>();

                dataPoints.Add(new DataPoint("Samsung", 25));
                dataPoints.Add(new DataPoint("Micromax", 13));
                dataPoints.Add(new DataPoint("Lenovo", 8));
                dataPoints.Add(new DataPoint("Intex", 7));
                dataPoints.Add(new DataPoint("Reliance", 6.8));
                dataPoints.Add(new DataPoint("Others", 40.2));

                ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

               // return View();
            


            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}