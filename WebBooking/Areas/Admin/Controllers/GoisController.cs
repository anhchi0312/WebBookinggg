using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBooking.Models;

namespace WebBooking.Areas.Admin.Controllers
{
    public class GoisController : Controller
    {
        private DBconect db = new DBconect();

        // GET: Admin/Gois
        public ActionResult Index()
        {
            return View(db.Gois.ToList());
        }

        // GET: Admin/Gois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goi goi = db.Gois.Find(id);
            if (goi == null)
            {
                return HttpNotFound();
            }
            return View(goi);
        }

        // GET: Admin/Gois/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoiId,GoiName,Note,Img")] Goi goi)
        {
            if (ModelState.IsValid)
            {
                db.Gois.Add(goi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goi);
        }

        // GET: Admin/Gois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goi goi = db.Gois.Find(id);
            if (goi == null)
            {
                return HttpNotFound();
            }
            return View(goi);
        }

        // POST: Admin/Gois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoiId,GoiName,Note,Img")] Goi goi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goi);
        }

        // GET: Admin/Gois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goi goi = db.Gois.Find(id);
            if (goi == null)
            {
                return HttpNotFound();
            }
            return View(goi);
        }

        // POST: Admin/Gois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goi goi = db.Gois.Find(id);
            db.Gois.Remove(goi);
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
