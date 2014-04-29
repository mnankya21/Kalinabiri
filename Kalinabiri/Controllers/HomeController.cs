using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kalinabiri.Models;

namespace Kalinabiri.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            Session["name"] = "Lyadda Dison";

            return View("Index");
        }

  

        public ActionResult Logout()
        {

            Session["name"] = null;

            return View("Index");
        }

    }
}
