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
    public class ChuyensController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: Chuyens
        public ActionResult Index(string option, string search, int MaChuyen = 0)
        {
            var chuyens = db.Chuyens.Include(c => c.Tau);
            List<Chuyen> Ch = db.Chuyens.ToList();
            var Ves = db.Ves.Include(p => p.Chuyen);
            List<Ve> price = db.Ves.ToList();
            var GiaVe = db.Ves.Include(p => p.GiaVe);


            SelectList ChList = new SelectList(Ch, "MaChuyen", "TenChuyen");
            ViewBag.MaChuyen = ChList;
            if (MaChuyen != 0)
            { 
                Ves = Ves.Where(s => s.MaChuyen == MaChuyen);
            }
            if (option == "TenChuyen" && option == "TGKhoiHanh")

                chuyens = chuyens.Where(s => s.TenChuyen.StartsWith(search));
                //return View(db.Users.Where(x => x.Name.StartsWith(searchU)).ToList());

            else if (option != null)
            {
                //int i = int.Parse(search);
                Ves = Ves.Where(s => s.MaChuyen.ToString().StartsWith(search));

                //return View(db.Users.Where(x => x.UserTypeID == i).ToList());
            }
            return View(chuyens.ToList());
        }

        [HttpGet]
        public ActionResult ThemChuyen()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemChuyen(int Matau, string TenChuyen, string NoiDi, string NoiDen, DateTime TGKhoiHanh)
        {
            string s = "Exec sp_ThemChuyen'" + Matau + "'" + "," + TenChuyen + "," + NoiDi + "," + NoiDen + "," + TGKhoiHanh;
            var data = db.sp_ThemChuyen(Matau, TenChuyen, NoiDi, NoiDen, TGKhoiHanh);
            return View();
        }





        // GET: Chuyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuyen chuyen = db.Chuyens.Find(id);
            if (chuyen == null)
            {
                return HttpNotFound();
            }
            return View(chuyen);
        }

        // GET: Chuyens/Create
        public ActionResult Create()
        {
            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau");
            return View();
        }

        // POST: Chuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuyen,MaTau,SoGhe,TenChuyen,NoiDi,NoiDen,TGKhoiHanh")] Chuyen chuyen)
        {
            if (ModelState.IsValid)
            {
                var listChuyenID = db.Chuyens;
            int tmp = 0;
            for (int i = 1; i <= listChuyenID.ToList().Count; i++)
            {
                Chuyen chuyen1 = db.Chuyens.Find(i);
                if (chuyen1 == null) tmp = i;
            }
            chuyen.MaChuyen = tmp;
            Session["MaChuyen"] = chuyen.MaChuyen.ToString();
            db.Chuyens.Add(chuyen);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau", chuyen.MaTau);
            return View(chuyen);
        }

        // GET: Chuyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuyen chuyen = db.Chuyens.Find(id);
            if (chuyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau", chuyen.MaTau);
            return View(chuyen);
        }

        // POST: Chuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuyen,MaTau,SoGhe,TenChuyen,NoiDi,NoiDen,TGKhoiHanh")] Chuyen chuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTau = new SelectList(db.Taus, "MaTau", "TenTau", chuyen.MaTau);
            return View(chuyen);
        }

        // GET: Chuyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuyen chuyen = db.Chuyens.Find(id);
            if (chuyen == null)
            {
                return HttpNotFound();
            }
            return View(chuyen);
        }

        // POST: Chuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chuyen chuyen = db.Chuyens.Find(id);
            db.Chuyens.Remove(chuyen);
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
