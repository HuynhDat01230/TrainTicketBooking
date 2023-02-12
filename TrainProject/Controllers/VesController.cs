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
    public class VesController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: Ves
        public ActionResult Index()
        {
            var ves = db.Ves.Include(v => v.Chuyen).Include(v => v.LoaiVe);
            return View(ves.ToList());
        }

        [HttpGet]
        public ActionResult ThemVe()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemVe(int MaChuyen, int MaLoaiVe, string GiaVe)
        {
            string s = "Exec sp_ThemVe'" + MaChuyen + "'" + "," + MaLoaiVe + "," + GiaVe;
            var data = db.sp_ThemVe(MaChuyen, MaLoaiVe, decimal.Parse(GiaVe));
            return View();
        }






        // GET: Ves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // GET: Ves/Create
        public ActionResult Create()
        {
            ViewBag.MaChuyen = new SelectList(db.Chuyens, "MaChuyen", "TenChuyen");
            ViewBag.MaLoaiVe = new SelectList(db.LoaiVes, "MaLoaiVe", "MoTaLoaiVe");
            return View();
        }

        // POST: Ves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVe,MaChuyen,MaLoaiVe,GiaVe")] Ve ve)
        {
            if (ModelState.IsValid)
            {
                var listTicketID = db.Ves;
                int tmp = 0;
                for (int i = 1; i <= listTicketID.ToList().Count; i++)
                {
                    Ve ve1 = db.Ves.Find(i);
                    if (ve1 == null) tmp = i;
                }
                ve.MaVe = tmp;
                Session["MaVe"] = ve.MaVe.ToString();
                db.Ves.Add(ve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuyen = new SelectList(db.Chuyens, "MaChuyen", "TenChuyen", ve.MaChuyen);
            ViewBag.MaLoaiVe = new SelectList(db.LoaiVes, "MaLoaiVe", "MoTaLoaiVe", ve.MaLoaiVe);
            return View(ve);
        }

        // GET: Ves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuyen = new SelectList(db.Chuyens, "MaChuyen", "TenChuyen", ve.MaChuyen);
            ViewBag.MaLoaiVe = new SelectList(db.LoaiVes, "MaLoaiVe", "MoTaLoaiVe", ve.MaLoaiVe);
            return View(ve);
        }

        // POST: Ves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVe,MaChuyen,MaLoaiVe,GiaVe")] Ve ve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChuyen = new SelectList(db.Chuyens, "MaChuyen", "TenChuyen", ve.MaChuyen);
            ViewBag.MaLoaiVe = new SelectList(db.LoaiVes, "MaLoaiVe", "MoTaLoaiVe", ve.MaLoaiVe);
            return View(ve);
        }

        // GET: Ves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // POST: Ves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ve ve = db.Ves.Find(id);
            db.Ves.Remove(ve);
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
