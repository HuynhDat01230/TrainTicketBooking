using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainProject.Models;
using System.Security.Cryptography;


namespace TrainProject.Controllers
{
    public class LoginController : Controller
    {
        private qltrainEntities db = new qltrainEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                using (qltrainEntities db = new qltrainEntities())
                {
                    var obj = db.TaiKhoans.Where(a => a.TenTK.Equals(username) && (a.MatKhau.Equals(f_password) || a.MatKhau.Equals(password))).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["username"] = obj.TenTK.ToString();
                        Session["userID"] = obj.MaTK.ToString();
                        Session["userType"] = obj.MaQuyen.ToString();
                        return RedirectToAction("Index", "Home");   
                    }
                    else
                    {
                        ViewBag.error = "Invalid Account";
                        return View("Index");
                    }
                }
            }

            if (username.Equals("acc1") && password.Equals("123"))
            {
                Session["username"] = "username";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var checkName = db.TaiKhoans.FirstOrDefault(s => s.TenTK == user.TenTK);
                var checkEmail = db.TaiKhoans.FirstOrDefault(e => e.EmailTK == user.EmailTK);
                var checkPhoneNumber = db.TaiKhoans.FirstOrDefault(n => n.SoDienThoai == user.SoDienThoai);
                if (checkName == null && checkEmail == null && checkPhoneNumber == null)
                {
                    var listCustomerID = db.TaiKhoans;
                    int tmp = 0;
                    for (int i = 1; i <= listCustomerID.ToList().Count; i++)
                    {
                        TaiKhoan user1 = db.TaiKhoans.Find(i);
                        if (user1 == null) tmp = i;
                    }
                    user.MaTK = tmp;
                    user.MatKhau = GetMD5(user.MatKhau);
                    user.XacNhanMatKhau = GetMD5(user.XacNhanMatKhau);
                    user.MaQuyen = 3;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TaiKhoans.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Tài khoản, mật khẩu hoặc số điện thoại này đã được sử dụng";

                    return View();
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("username");
            Session.Remove("userID");
            return RedirectToAction("Index", "Home");
        }

        //create a string MD5

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


    }
}