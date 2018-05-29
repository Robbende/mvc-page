using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books_MVC.Models;

namespace Books_MVC.Controllers
{
    public class PetController : Controller
    {
        public static List<Pet> Pets = new List<Pet>(){
            new Pet(){id=1, name="firulais", ownerId=10},
            new Pet(){id=2, name="boby", ownerId=10},
            new Pet(){id=3, name="colitas", ownerId=10}
        };


        //
        // GET: /Pet/

        public ActionResult Index()
        {
            var pet_id = (string)RouteData.Values["id"];

            var pet = Pets.Where(i => i.id == int.Parse(pet_id)).FirstOrDefault();

            if (pet == null)
            {
                return RedirectToAction("NotFound", new { message = "Pet with the Id: " + pet_id + " was not found" });
            }

            return View(pet);
        }

        
        public ActionResult NotFound(string message)
        {
            ViewBag.msg = message;
            return View();
        }



    }
}
