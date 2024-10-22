﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBooking.Models;

namespace WebBooking.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        private DBconect db = new DBconect();
        // GET: Admin/Manager
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(NhanVien nhanvien)
        { 
            var ma_hoa_du_lieu = GetMD5(nhanvien.passwordNV);
            var kiem_tra_tai_khoan = db.NhanViens.Where(s => s.emailNV.Equals(nhanvien.emailNV) && s.passwordNV.Equals(ma_hoa_du_lieu)).ToList();
            if (kiem_tra_tai_khoan.Count() > 0)
            {
                //add session
                Session["IDNhanVien"] = kiem_tra_tai_khoan.FirstOrDefault().IDNhanVien;
                Session["TenNhanVien"] = kiem_tra_tai_khoan.FirstOrDefault().TenNhanVien;
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ViewBag.Message = "Login failed";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["IDNhanVien"] = "";
            Session["TenNhanVien"] = "";
            return RedirectToAction("Login", "Manager");
        }


        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(str);
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