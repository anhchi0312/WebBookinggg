using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBooking.Models;

namespace WebBooking.Areas.Admin.Controllers
{
    public class NhanViensController : BaseController
    {
        private DBconect db = new DBconect();

        // GET: Admin/NhanViens
        public ActionResult Index()
        {
            return View(db.NhanViens.ToList());
        }

        // GET: Admin/NhanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                if (nhanVien.passwordNV != nhanVien.confirm_password)
                {
                    ViewBag.Message = "Confirm password phải trùng với Pasword";
                    return View(nhanVien);
                }
                nhanVien.passwordNV = GetMD5(nhanVien.passwordNV);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            nhanVien.confirm_password = nhanVien.passwordNV;
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVien nhanVien, int id)
        {
            if (ModelState.IsValid)
            {
                if (nhanVien.passwordNV != nhanVien.confirm_password)
                {
                    ViewBag.Message = "Confirm password phải trùng với Pasword";
                    return View(nhanVien);
                }
                NhanVien NewNhanVien = db.NhanViens.Find(id);
                NewNhanVien.IDNhanVien = nhanVien.IDNhanVien;
                NewNhanVien.TenNhanVien = nhanVien.TenNhanVien;
                NewNhanVien.SDT = nhanVien.SDT;
                NewNhanVien.emailNV = nhanVien.emailNV;
                NewNhanVien.passwordNV = GetMD5(nhanVien.passwordNV);
                //nếu password không thay đổi
                if (NewNhanVien.passwordNV == nhanVien.passwordNV)
                {
                    NewNhanVien.passwordNV = nhanVien.passwordNV;
                }
                else
                {
                    //Nếu thay đổi password cần phải xóa hết rồi nhập lại. Nếu không sẽ lưu pass sai (không biết mk là gì)
                    NewNhanVien.passwordNV = GetMD5(nhanVien.passwordNV);
                }
                //customer.password = GetMD5(customer.password);
                //db.Entry(customer).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string mk_da_ma_hoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mk_da_ma_hoa += targetData[i].ToString("x2");

            }
            return mk_da_ma_hoa;
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
