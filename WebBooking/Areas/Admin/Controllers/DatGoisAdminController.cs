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
    public class DatGoisAdminController : BaseController
    {
        private DBconect db = new DBconect();

        // GET: Admin/DatGoisAdmin
        public ActionResult Index()
        {
            var datGois = db.DatGois.Include(d => d.Customer);
            return View(datGois.ToList());
        }

        // GET: Admin/DatGoisAdmin/Details/5
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

        // GET: Admin/DatGoisAdmin/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: Admin/DatGoisAdmin/Create
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

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", datGoi.CustomerId);
            return View(datGoi);
        }

        // GET: Admin/DatGoisAdmin/Edit/5
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
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", datGoi.CustomerId);
            return View(datGoi);
        }

        // POST: Admin/DatGoisAdmin/Edit/5
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
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", datGoi.CustomerId);
            return View(datGoi);
        }

        // GET: Admin/DatGoisAdmin/Delete/5
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

        // POST: Admin/DatGoisAdmin/Delete/5
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
