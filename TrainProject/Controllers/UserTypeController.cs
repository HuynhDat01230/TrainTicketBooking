using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainProject.Models;

namespace TrainProject.Controllers
{
    public class UserTypesController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: UserTypes
        public ActionResult Index()
        {
            return View(db.Quyens.ToList());
        }


        [HttpGet]
        public ActionResult ThemQuyen()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemQuyen(string MoTaQuyen)
        {
            string s = "Exec sp_ThemQuyen '" + MoTaQuyen + "'";
            var data = db.sp_ThemQuyen(MoTaQuyen);
            return View();
        }



        [HttpGet]
        public ActionResult XoaQuyen()
        {
            return View();
        }

        // POST: UserTypes/Delete/5
        [HttpPost]
        public ActionResult XoaQuyen(int MaQuyen)
        {
            {
                var data = db.sp_XoaQuyen(MaQuyen);
            }
            return View();
        }





        // GET: UserTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quyen quyen = db.Quyens.Find(id);
            if (quyen == null)
            {
                return HttpNotFound();
            }
            return View(quyen);
        }

        // GET: UserTypes/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        // POST: UserTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: UserTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quyen userType = db.Quyens.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTypeID,Description")] Quyen quyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quyen);
        }

        // GET: UserTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quyen quyen = db.Quyens.Find(id);
            if (quyen == null)
            {
                return HttpNotFound();
            }
            return View(quyen);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quyen quyen = db.Quyens.Find(id);
            db.Quyens.Remove(quyen);
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
