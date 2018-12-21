using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBuild.Assessment6_WebForm.Models;

namespace DevBuild.Assessment6_WebForm.Controllers
{
    public class DishController : Controller
    {
        private List<Dish> AllDishes { get; set; } = new List<Dish>();

        // GET: Dish
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowDishes()
        {
            using (PartyDBEntities2 context = new PartyDBEntities2())
            {
                AllDishes = context.Dishes.ToList();
            }
            return View(AllDishes);
        }

        public ActionResult MyDishes()
        {
            return View(AllDishes);
        }

        

        [HttpPost]
        public ActionResult Submit(Dish dishData)
        {
            TempData.Add("PersonName", dishData.PersonName);
            TempData.Add("PhoneNumber", dishData.PhoneNumber);
            TempData.Add("DishName", dishData.DishName);
            TempData.Add("DishDescription", dishData.DishDescription);
            TempData.Add("Options", dishData.Option);

            using (PartyDBEntities2 context = new PartyDBEntities2())
            {
                context.Dishes.Add(dishData);
                context.Entry(dishData).State = EntityState.Added;
                context.SaveChanges();
            }
            return RedirectToAction("Confirmation");
        }

        public ActionResult Confirmation()
        {
            return View();
        }


        public ActionResult EditDish(int? id)
        {
            if (id != null)
            {
                using (PartyDBEntities2 context = new PartyDBEntities2())
                {
                    Dish dishToEdit = context.Dishes.Find(id);
                    if (dishToEdit != null)
                    {
                        return View(dishToEdit);
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult SaveEdits(Dish dishToEdit)
        {
            using (PartyDBEntities2 context = new PartyDBEntities2())
            {
                Dish editedDish = new Dish()
                {
                    //PersonName = dishToEdit.PersonName,
                    //DishDescription = dishToEdit.DishDescription,
                    DishID = dishToEdit.DishID//,
                    //DishName = dishToEdit.DishName,
                    //PhoneNumber = dishToEdit.PhoneNumber,
                    //Option = dishToEdit.Option
                };

                context.Entry(dishToEdit).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteDish(int? id)
        {
            if (id != null)
            {
                using (PartyDBEntities2 context = new PartyDBEntities2())
                {
                    Dish dishToDelete = context.Dishes.Find(id);
                    if (dishToDelete != null)
                    {
                        context.Entry(dishToDelete).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ConfirmDelete(int? id)
        {
            return View();
        }
    }
}