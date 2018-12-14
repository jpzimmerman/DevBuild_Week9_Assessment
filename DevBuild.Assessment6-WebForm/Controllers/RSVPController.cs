using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Submit(Guest guestData) {
            if (ModelState.IsValid)
            {
                if ((bool)guestData.IsAttending)
                {
                    TempData.Add("FirstName", guestData.FirstName);
                    TempData.Add("LastName", guestData.LastName);
                    TempData.Add("PartyDate", guestData.AttendanceDate);
                    TempData.Add("HasAPlusOne", guestData.HasAPlusOne);

                    using (PartyDBEntities1 context = new PartyDBEntities1())
                    {
                        context.Guests.Add(guestData);
                        context.Entry(guestData).State = EntityState.Added;
                        context.SaveChanges();

                    }
                }
                TempData.Add("IsAttending", guestData.IsAttending);
                return RedirectToAction("Confirmation");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}