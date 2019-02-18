using _2_14_19StateManagementLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_14_19StateManagementLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            return View();
        }

        public ActionResult About()
        {
            if (!TempData.ContainsKey("HappyMessage"))
            {
                TempData.Add("HappyMessage", "Happy Valentine's Day!");
            }
            ViewBag.Message = "This is the about page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (TempData.ContainsKey("HappyMessage"))
            {
                ViewBag.Message = TempData["HappyMessage"];
                TempData["HappyMessage"] = TempData["HappyMessage"];
            }
            //ViewBag.Message = TempData["HappyMessage"];
            //TempData["HappyMessage"] = TempData["HappyMessage"]; //This is how you keep it living one more time

            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult Result(User u)
        {
            ViewBag.userName = u.UserName;
            ViewBag.email = u.Email;
            ViewBag.password = u.Password;
            ViewBag.age = u.Age;

            return View();
        }

        public ActionResult UserDetails(User newUser)
        {
            if (Session["CurrentUser"] != null)
            {
                newUser = (User)Session["CurrentUser"];
                ViewBag.CurrentUser = newUser;
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ViewBag.CurrentUser = newUser;
                    Session["CurrentUser"] = newUser;
                    return View(); //If it is valid, go to the view. If not, go to error page.
                }
                else
                {
                    ViewBag.ErrorMessage = "Registration failed. Try again.";
                    return View("Error");
                }
            }

        }
        public ActionResult LogOut()
        {
            Session.Remove("CurrentUser"); //removes key and value from session, so session will no longer exist
            return RedirectToAction("Index"); //return to homepage
        }

    }
}
 