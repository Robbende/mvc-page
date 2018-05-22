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

            db.Books.Add(book);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
