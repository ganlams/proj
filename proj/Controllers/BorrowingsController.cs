using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proj.Data;
using proj.Models;

namespace proj.Controllers
{
    public class BorrowingsController : Controller
    {
        private projContext db = new projContext();

        // GET: Borrowings
        public ActionResult Index()
        {
            var borrowings = db.Borrowings.Include(b => b.Book).Include(b => b.Member);
            return View(borrowings.ToList());
        }

        // GET: Borrowings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrowing borrowing = db.Borrowings.Find(id);
            if (borrowing == null)
            {
                return HttpNotFound();
            }
            return View(borrowing);
        }

        // GET: Borrowings/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title");
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name");
            return View();
        }

        // POST: Borrowings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BorrowingId,BorrowDate,ReturnDate,MemberId,BookId")] Borrowing borrowing)
        {
            if (ModelState.IsValid)
            {
                db.Borrowings.Add(borrowing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowing.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", borrowing.MemberId);
            return View(borrowing);
        }

        // GET: Borrowings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrowing borrowing = db.Borrowings.Find(id);
            if (borrowing == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowing.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", borrowing.MemberId);
            return View(borrowing);
        }

        // POST: Borrowings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BorrowingId,BorrowDate,ReturnDate,MemberId,BookId")] Borrowing borrowing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowing.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", borrowing.MemberId);
            return View(borrowing);
        }

        // GET: Borrowings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrowing borrowing = db.Borrowings.Find(id);
            if (borrowing == null)
            {
                return HttpNotFound();
            }
            return View(borrowing);
        }

        // POST: Borrowings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Borrowing borrowing = db.Borrowings.Find(id);
            db.Borrowings.Remove(borrowing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
