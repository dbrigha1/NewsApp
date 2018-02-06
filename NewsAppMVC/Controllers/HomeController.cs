using NewsAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsAppMVC.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private NewsAppMVCContext db = new NewsAppMVCContext();
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}