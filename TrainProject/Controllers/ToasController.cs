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
    public class ToasController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: Toas
        public ActionResult Index()
        {
            var toas = db.Toas.Include(t => t.Tau);
            return View(toas.ToList());
        }


        [HttpGet]
        public ActionResult ThemToa()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemToa(int MaTau, int SoGhe, string LoaiGhe)
        {
            string s = "Exec sp_ThemToa '" + MaTau + "'" + "," + SoGhe + "," + LoaiGhe;
            var data = db.sp_ThemToa(MaTau, SoGhe, LoaiGhe);
            return View();
        }





        // GET: Toas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toa toa = db.Toas.Find(id);
            if (toa == null)
            {
                return HttpNotFound();
            }
            return View(toa);
        }

        // GET: Toas/Create
        public ActionResult Create()
        {
            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau");
            return View();
        }

        // POST: Toas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaToa,MaTau,SoGhe,LoaiGhe")] Toa toa)
        {
            if (ModelState.IsValid)
            {
                db.Toas.Add(toa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau", toa.MaTau);
            return View(toa);
        }

        // GET: Toas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toa toa = db.Toas.Find(id);
            if (toa == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau", toa.MaTau);
            return View(toa);
        }

        // POST: Toas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaToa,MaTau,SoGhe,LoaiGhe")] Toa toa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau", toa.MaTau);
            return View(toa);
        }

        // GET: Toas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toa toa = db.Toas.Find(id);
            if (toa == null)
            {
                return HttpNotFound();
            }
            return View(toa);
        }

        // POST: Toas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toa toa = db.Toas.Find(id);
            db.Toas.Remove(toa);
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
