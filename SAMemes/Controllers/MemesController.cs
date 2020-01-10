using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAMemes.Models;

namespace SAMemes.Controllers
{
    public class MemesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Memes
        public ActionResult Index()
        {
            return View(db.Memes.ToList());
        }

        // GET: Memes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return HttpNotFound();
            }
            return View(meme);
        }

        // GET: Memes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Memes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imgPath")] Meme meme)
        {
            if (ModelState.IsValid)
            {
                db.Memes.Add(meme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meme);
        }

        // GET: Memes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return HttpNotFound();
            }
            return View(meme);
        }

        // POST: Memes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imgPath")] Meme meme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meme);
        }

        // GET: Memes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return HttpNotFound();
            }
            return View(meme);
        }

        // POST: Memes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meme meme = db.Memes.Find(id);
            db.Memes.Remove(meme);
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
