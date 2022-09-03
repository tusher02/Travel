using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        TravelEntities db = new TravelEntities();  
        //bool isLogIn = false;
        public ActionResult Index()
        {
            var blogList = db.Posts.ToList().OrderByDescending(x => x.postId);
            return View(blogList);
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