using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books_MVC.Models;

namespace Books_MVC.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/

        booksDbContext db = new booksDbContext("DbTesting");
        

        public ActionResult Index()
        {
            List<books> MyBooks = db.Books.Where(i => i.Id > 0).OrderByDescending(i=>i.Id).ToList();

            ViewBag.books = MyBooks;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(books book)
        {

            book.date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);

        }

        public ActionResult IndexModel()
        {
            /*
                We send to the view the model, so in the view we define the model to 
                make use of the intellisense and the use of dataannotations
             
             */

            List<books> MyBooks = db.Books.Where(i => i.Id > 0).OrderByDescending(i => i.Id).ToList();

            ViewBag.description = "View by Strongly Typed Model";

            return View(MyBooks);
        }


        public ActionResult CommentSummary()
        {

            var comm = from i in db.Usercomments
                       group i by i.UserName into groupedByName
                       orderby groupedByName.Count() descending
                       select new CommentSummary
                       {
                           NumberOfComments = groupedByName.Count(),
                           UserName = groupedByName.Key

                       };
            
            return View(comm);
        }
    }
}
