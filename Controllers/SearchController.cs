using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Controllers
{
    public class SearchController : Controller
    {
        TravelEntities context = new TravelEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string search)
        {

            var post = from g in context.Posts where g.postTitle.Contains(search) || g.postDesc.Contains(search) select g;

            return View(post);
        }
    }
}