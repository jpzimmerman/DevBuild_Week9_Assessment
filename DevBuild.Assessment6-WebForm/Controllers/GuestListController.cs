using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBuild.Assessment6_WebForm.Models;

namespace DevBuild.Assessment6_WebForm.Controllers
{
    public class GuestListController : Controller
    {
        private List<Guest> masterGuestList = new List<Guest>();
        // GET: GuestList
        public ActionResult Index()
        {
            using (PartyDBEntities3 ORM = new PartyDBEntities3())
            {
                List<Guest> masterGuestList = ORM.Guests.ToList();
                return View(masterGuestList);
            }

        }
    }
}