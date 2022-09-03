using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Travel.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        TravelEntities db = new TravelEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            using (TravelEntities context = new TravelEntities())
            {
                bool isValid = context.Users.Any(x => x.userName == model.userName && x.userPass == model.userPass && x.userRole == model.userRole);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.userName, false);// ber hoye gele automatic logout hbe
                    // method name, controller name
                    string whichUser = model.userRole;
                    
                    ViewBag.loggedUserName = model.userName;

                    //var usersId = db.Database.SqlQuery<NonEntityUser>("Select userId from Users where userName = " + model.userName).FirstOrDefault<NonEntityUser>(); ;

                    //ViewBag.usersId = usersId;

                    //IEnumerable<Post> postList = db.Posts.SqlQuery("Select * from Posts where userId = " + usersId);

                    //ViewBag.allPost = postList;

                    if (whichUser.ToLower() == "admin")
                    {
                        //isLogIn = true;
                        ViewBag.isLogIn = false;
                        ViewBag.isSignUp = false;
                        ViewBag.isHome = false;
                        ViewBag.isAbout = false;
                        ViewBag.isContact = false;
                        return View("", "~/Views/_AdminPanelLayout.cshtml", null);
                    }
                    else
                    {
                        //isLogIn = true;
                        ViewBag.isLogIn = false;
                        ViewBag.isSignUp = false;
                        ViewBag.isHome = false;
                        ViewBag.isAbout = false;
                        ViewBag.isContact = false;
                        ViewBag.name = model.userName;
                        return View("", "~/Views/_UserPanelLayout.cshtml", null);
                    }
                }
                ModelState.AddModelError("", "Invalid username or password or userrole");
                return View();
            }

        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (TravelEntities context = new TravelEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}