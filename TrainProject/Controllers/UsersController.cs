using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainProject.Models;

namespace TrainProject.Controllers
{
    public class UsersController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.TaiKhoans.Include(u => u.Quyen);
            return View(users.ToList());
        }

        [HttpGet]
        public ActionResult ThemTaiKhoan()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemTaiKhoan(string TenTK, string EmailTK, string SoDienThoai, string MatKhau, string XacNhanMatKhau)
        {
            var data = db.sp_register(TenTK, EmailTK, SoDienThoai, MatKhau, XacNhanMatKhau);
            return View();

        }





        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan user = db.TaiKhoans.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeID = new SelectList(db.TaiKhoans, "MaQuyen", "MoTaQuyen");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,Email,Password,Phone,ConfirmPassword,Address,UserTypeID")] TaiKhoan user)
        {
            
                if (ModelState.IsValid)
                {

                    var listCustomerID = db.TaiKhoans;
                    int tmp = 0;
                    for (int i = 1; i <= listCustomerID.ToList().Count; i++)
                    {
                        TaiKhoan user1 = db.TaiKhoans.Find(i);
                        if (user1 == null) tmp = i;
                    }
                    user.MaTK = tmp;
                    Session["UserID"] = user.MaTK.ToString();
                    db.TaiKhoans.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            ViewBag.UserTypeID = new SelectList(db.Quyens, "UserTypeID", "Description", user.MaQuyen);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan user = db.TaiKhoans.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeID = new SelectList(db.Quyens, "UserTypeID", "Description", user.MaQuyen);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Email,Password,Phone,ConfirmPassword,Address,UserTypeID")] TaiKhoan user)
        {
            
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            

            ViewBag.UserTypeID = new SelectList(db.Quyens, "UserTypeID", "Description", user.MaQuyen);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan user = db.TaiKhoans.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan user = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(user);
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

        public ActionResult SearchFunctionUser(string optionU, string searchU)

        {
            if (optionU == "Name")
            {
                return View(db.TaiKhoans.Where(x => x.TenTK.StartsWith(searchU) || searchU == null).ToList());
            }
            else
            {
                int i = int.Parse(searchU);
                return View(db.TaiKhoans.Where(x => x.MaQuyen == i || searchU == null).ToList());
            }
        }
    }
}
