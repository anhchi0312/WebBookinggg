using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBooking.Models;


namespace WebBooking.Controllers
{
    public class HomeController : Controller
    {
        DBconect db = new DBconect();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Login()
         {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if(ModelState.IsValid)
            {
                var ma_hoa_du_lieu = GetMD5(password);
                var kiem_tra_tai_khoan = db.Customers.Where(s => s.email.Equals(email) && s.password.Equals(ma_hoa_du_lieu)).ToList();
                if (kiem_tra_tai_khoan.Count() > 0)
                {
                    //add session
                    Session["IDKhachHang"] = kiem_tra_tai_khoan.FirstOrDefault().CustomerId;
                    Session["TenKhachHang"] = kiem_tra_tai_khoan.FirstOrDefault().CustomerName;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer kh)
        {
            if (ModelState.IsValid)
            {
                var checkemail = db.Customers.FirstOrDefault(m => m.email == kh.email);
                if(checkemail == null)
                {
                    kh.password = GetMD5(kh.password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Customers.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                } 
                else
                {
                    ViewBag.emailErro = "Email đã tồn tại";
                    return View();
                }    
            }
            return View();
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

    }
}