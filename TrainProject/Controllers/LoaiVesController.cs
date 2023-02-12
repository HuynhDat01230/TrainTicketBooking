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
    public class LoaiVesController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: LoaiVes
        public ActionResult Index()
        {
            return View(db.LoaiVes.ToList());
        }

        [HttpGet]
        public ActionResult ThemLoaiVe()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemLoaiVe(string MoTaLoaiVe)
        {
            var data = db.sp_ThemLoaiVe(MoTaLoaiVe);
            return View();
        }




        // GET: LoaiVes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            if (loaiVe == null)
            {
                return HttpNotFound();
            }
            return View(loaiVe);
        }

        // GET: LoaiVes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiVes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiVe,MoTaLoaiVe")] LoaiVe loaiVe)
        {
            if (ModelState.IsValid)
            {
                db.LoaiVes.Add(loaiVe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiVe);
        }

        // GET: LoaiVes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            if (loaiVe == null)
            {
                return HttpNotFound();
            }
            return View(loaiVe);
        }

        // POST: LoaiVes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiVe,MoTaLoaiVe")] LoaiVe loaiVe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiVe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiVe);
        }

        // GET: LoaiVes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            if (loaiVe == null)
            {
                return HttpNotFound();
            }
            return View(loaiVe);
        }

        // POST: LoaiVes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            db.LoaiVes.Remove(loaiVe);
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
