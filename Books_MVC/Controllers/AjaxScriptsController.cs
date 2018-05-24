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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return PartialView();
        }

    }
}
