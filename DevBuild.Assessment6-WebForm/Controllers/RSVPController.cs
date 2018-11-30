using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBuild.Assessment6_WebForm.Models;

namespace DevBuild.Assessment6_WebForm.Controllers
{
    public class RSVPController : Controller
    {
        // GET: RSVP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(UserData userData) {
            if (userData.IsAttending)
            {
                TempData.Add("FirstName", userData.FirstName);
                TempData.Add("LastName", userData.LastName);
                TempData.Add("PartyDate", userData.PartyDates[userData.SelectedPartyDate]);
                TempData.Add("HasAPlusOne", userData.HasAPlusOne);
            }
            TempData.Add("IsAttending", userData.IsAttending);
            return RedirectToAction("Confirmation");
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}