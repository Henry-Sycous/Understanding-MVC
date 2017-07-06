using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_Application.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            ViewData["NumIterations"] = 10;

            return View();
        }

        //Setup Welcome() View Controller with some default values for name, numTimes & ID
        //GET: /HelloWorld/Welcome
        public ActionResult Welcome(String name = "Jim", int numTimes = 10, int ID = 1)
        {
            //Set ViewData Welcome Message to blah blah
            //Could also be formatted as ViewBag.WelcomeMsg = "blah blah"
            ViewData["WelcomeMsg"] = "Welcome to the welcome page " + name + ", your user ID is: " + ID;
            //Add some variables to the view bag 
            //Can also access ViewData variables by calling ViewBag method in the view (welcome.cshtml)
            ViewBag.numTimes = numTimes;
            ViewBag.name = name;

            return View();
        }
    }
}