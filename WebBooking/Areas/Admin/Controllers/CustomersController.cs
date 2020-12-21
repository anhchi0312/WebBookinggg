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
    public class CustomersController : BaseController
    {
        private DBconect db = new DBconect();

        // GET: Admin/Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.password != customer.confirm_password)
                {
                    ViewBag.Message = "Confirm password phải trùng với Pasword";
                    return View(customer);
                }
                customer.password = GetMD5(customer.password);
                db.Configuration.ValidateOnSaveEnabled = false;

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            //customer.password = EncodePassword(customer.password);
            customer.confirm_password = customer.password;
            return View(customer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer, int id)
        {
            if (ModelState.IsValid)
            {
                if (customer.password != customer.confirm_password)
                {
                    ViewBag.Message = "Confirm password phải trùng với Pasword";
                    return View(customer);
                }
                Customer NewCus = db.Customers.Find(id);
                NewCus.CustomerId = customer.CustomerId;
                NewCus.CustomerName = customer.CustomerName;
                NewCus.Address = customer.Address;
                NewCus.Tel = customer.Tel;
                NewCus.email = customer.email;
                //nếu password không thay đổi
                if (NewCus.password == customer.password)
                {
                    NewCus.password = customer.password;
                }
                else
                {
                    //Nếu thay đổi password cần phải xóa hết rồi nhập lại. Nếu không sẽ lưu pass sai
                    NewCus.password = GetMD5(customer.password);
                }            

                //customer.password = GetMD5(customer.password);
                //db.Entry(customer).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Admin/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
