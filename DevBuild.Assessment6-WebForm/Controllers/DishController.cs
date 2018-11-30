using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBuild.Assessment6_WebForm.Models;

namespace DevBuild.Assessment6_WebForm.Controllers
{
    public class DishController : Controller
    {
        // GET: Dish
        public ActionResult Index()
        {
            return View();
        }
    }
}