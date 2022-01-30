using Bookstore2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bookstore2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private BookstoreEntities db = new BookstoreEntities();



        public ActionResult Index()
        {
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


    }
}