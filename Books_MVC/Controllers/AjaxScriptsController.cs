using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books_MVC.Controllers
{
    public class AjaxScriptsController : Controller
    {
        //
        // GET: /AjaxScripts/

        public static List<string> _comments = new List<string>() { "comment1", "comment2", "comment3", "comment4" };

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
    }
}
