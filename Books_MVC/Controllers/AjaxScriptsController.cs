using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books_MVC.Models;

namespace Books_MVC.Controllers
{
    public class AjaxScriptsController : Controller
    {
        //
        // GET: /AjaxScripts/

        public static List<string> _comments = new List<string>() { "comment1", "comment2", "comment3", "comment4" };

        public static List<Speaker> _speakerRepo = new List<Speaker>()
        {
            new Speaker(){Id=1, FirstName="Alejandro", LastName="Deambrossi", Bio="bio", PictureUrl="/Content/img/user1.jpg"},
            new Speaker(){Id=2, FirstName="Ruben", LastName="Deambrossi", Bio="bio", PictureUrl="/Content/img/user2.jpg"},
            new Speaker(){Id=3, FirstName="Juan", LastName="Deambrossi", Bio="bio", PictureUrl="/Content/img/user3.jpg"},
            new Speaker(){Id=4, FirstName="Carlos", LastName="Deambrossi", Bio="bio", PictureUrl="/Content/img/user4.jpg"},
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return PartialView();
        }


        public ActionResult ShowComments()
        {
            return View(_comments);
        }

        [HttpPost]
        public ActionResult AddComment(string comment)
        {
            _comments.Add(comment);

            if (Request.IsAjaxRequest())
            {
                /*
                    if request is ajax then fill a partial view that return an html
                    that will be added to the <ul> list by javascript
                 */

                ViewBag.Comment = comment;
                return PartialView();
            }

            /* 
                if request is not ajax then redirect to the ShowComment 
                action after adding the new comment to the list
             */

            return RedirectToAction("ShowComments");
        }


        public ActionResult ShowSpeakers()
        {
            var speakers = from s in _speakerRepo select s;

            return View(speakers);
        }

        [HttpPost]
        public ActionResult SpeakerDetail(int spid)
        {
            
            var speaker_detail = _speakerRepo.Where(i=>i.Id == spid).FirstOrDefault();

            return Json(speaker_detail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SpeakerPartial()
        {
            /* display speckers with partial view */
            return View(_speakerRepo);
        }
    }

}
