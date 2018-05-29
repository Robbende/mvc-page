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
            return View(Pets);
        }

        public ActionResult Details()
        {
            var pet_id = (string)RouteData.Values["id"];

            var pet = Pets.Where(i => i.id == int.Parse(pet_id)).FirstOrDefault();

            if (pet == null)
            {
                // return RedirectToAction("NotFound", new { message = "Pet with the Id: " + pet_id + " was not found" });
                
                return PetNotFound(); // return an HTTP 404 not found, recomended for SEO optimization to browser reindex
            }

            return View(pet);
        }

        
        public ActionResult NotFound(string message)
        {
            ViewBag.msg = message;
            return View();
        }


        public FileResult DownloadPetPicture()
        {
            var pet_id = (string)RouteData.Values["id"];
            var pet = Pets.Where(i => i.id == int.Parse(pet_id)).FirstOrDefault();

            var picture = "/Content/img/" + pet.name + ".jpg";
            var contentType = "image/jpg";
            var fileName = pet.name + ".jpg";

            return File(picture, contentType, fileName);
        }


        public ActionResult PetNotFound()
        {
            return HttpNotFound("Pet Not Found");
        }

    }
}
