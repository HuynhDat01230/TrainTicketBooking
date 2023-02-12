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
    public class TausController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: Taus
        public ActionResult Index()
        {
            return View(db.Taus.ToList());
        }


        [HttpGet]
        public ActionResult ThemTau()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemTau(string TenTau, int SoToa)
        {
            string s = "Exec sp_ThemTau '" + TenTau + "'" + "," + SoToa;

            var data = db.sp_ThemTau(TenTau,SoToa);
            return View();
        }



        // GET: Taus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tau tau = db.Taus.Find(id);
            if (tau == null)
            {
                return HttpNotFound();
            }
            return View(tau);
        }

        // GET: Taus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTau,TenTau,SoToa")] Tau tau)
        {
            if (ModelState.IsValid)
            {
                db.Taus.Add(tau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tau);
        }

        // GET: Taus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tau tau = db.Taus.Find(id);
            if (tau == null)
            {
                return HttpNotFound();
            }
            return View(tau);
        }

        // POST: Taus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTau,TenTau,SoToa")] Tau tau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tau);
        }

        // GET: Taus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tau tau = db.Taus.Find(id);
            if (tau == null)
            {
                return HttpNotFound();
            }
            return View(tau);
        }

        // POST: Taus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tau tau = db.Taus.Find(id);
            db.Taus.Remove(tau);
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
