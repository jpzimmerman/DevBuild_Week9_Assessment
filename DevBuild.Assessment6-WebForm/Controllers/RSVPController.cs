using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBuild.Assessment6_WebForm.Models;
using DevBuild.Assessment6_WebForm.Data;

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

                    GoTCharacter favoriteCharacter = GoTCharactersRepository.GetCharacterByName(guestData.CharacterName);
                    guestData.GameOfThronesCharacter = new GameOfThronesCharacter();
                    guestData.GameOfThronesCharacter.Name = favoriteCharacter.name;
                    guestData.GameOfThronesCharacter.Url = favoriteCharacter.url;
                    guestData.GameOfThronesCharacter.Titles = favoriteCharacter.titles[0];
                    guestData.GameOfThronesCharacter.Aliases = favoriteCharacter.aliases[0];

                    using (PartyDBEntities3 context = new PartyDBEntities3())
                    {
                        context.Guests.Add(guestData);
                        //context.Entry(guestData).State = EntityState.Added;
                        context.SaveChanges();
                    }
                }
                TempData.Add("IsAttending", guestData.IsAttending);
                TempData.Add("FavoriteGoTCharacter", guestData.GameOfThronesCharacter.Name);
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