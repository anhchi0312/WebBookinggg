using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBooking.Models;

namespace WebBooking.Controllers
{
    public class DatGoisController : Controller
    {
        private DBconect db = new DBconect();

        // GET: DatGois
        public ActionResult Index()
        {
            if (Session["IDKhachHang"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
             return View(db.DatGois.ToList()); 
        }

        // GET: DatGois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatGoi datGoi = db.DatGois.Find(id);
            if (datGoi == null)
            {
                return HttpNotFound();
            }
            return View(datGoi);
        }

        // GET: DatGois/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatGois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieu,GoiId,GoiName,CustomerId,Date,Note,State")] DatGoi datGoi)
        {
            if (ModelState.IsValid)
            {
                db.DatGois.Add(datGoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datGoi);
        }

        // GET: DatGois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatGoi datGoi = db.DatGois.Find(id);
            if (datGoi == null)
            {
                return HttpNotFound();
            }
            return View(datGoi);
        }

        // POST: DatGois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieu,GoiId,GoiName,CustomerId,Date,Note,State")] DatGoi datGoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datGoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datGoi);
        }

        // GET: DatGois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatGoi datGoi = db.DatGois.Find(id);
            if (datGoi == null)
            {
                return HttpNotFound();
            }
            return View(datGoi);
        }

        // POST: DatGois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatGoi datGoi = db.DatGois.Find(id);
            db.DatGois.Remove(datGoi);
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
