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
        List<Item> ItemList = new List<Item>()
        {
            new Item("Hot Chocolate", "Milk, Cocoa, Sugar, Fat", 1.99),
            new Item("Latte",  "Milk, Coffee", 1.99),
            new Item("Coffee",  "Coffee, Water", 1.00),
            new Item("Tea", "Black Tea", 1.00),
            new Item("Frozen Lemonade",  "Lemon, Sugar, Ice", 1.99)
        };
        List<Item> ShoppingCart = new List<Item>();

        public ActionResult Index()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            return View();
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

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        List<User> UserList = new List<User>();

        public ActionResult LoggedInUser(User newUser)
        {
            if (Session["CurrentUser"] != null)
            {
                newUser = (User)Session["CurrentUser"];
            }
            if (Session["AllUsers"] != null)
            {
                UserList = (List<User>)Session["AllUsers"];
            }

            return RedirectToAction("Login", new { message = "Login failed. Please try again." });
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

        public ActionResult ListItems()
        {
            ViewBag.ItemsList = ItemList;
            return View();
        }

        public ActionResult AddItem(string itemName)
        {
            if (Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Item>)Session["ShoppingCart"];
            }

            foreach (Item item in ItemList)
            {              //find item in list
                if (item.ItemName == itemName)
                {
                    ShoppingCart.Add(item);
                }
            }

            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("ListItems");
        }

    }
}
 