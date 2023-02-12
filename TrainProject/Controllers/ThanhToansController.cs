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
    public class ThanhToansController : Controller
    {
        private qltrainEntities db = new qltrainEntities();

        // GET: ThanhToans
        public ActionResult Index()
        {
            var thanhToans = db.ThanhToans.Include(t => t.TaiKhoan).Include(t => t.Ve);
            return View(thanhToans.ToList());
        }


        [HttpGet]
        public ActionResult BookingTicket()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BookingTicket(int SoGheDat, int MaVe, string MoTaThanhToan)
        {
            int MaTK = int.Parse(Session["userID"].ToString());
            var data = db.sp_BookingTicket(SoGheDat, MaVe, MaTK, MoTaThanhToan);
            return View();
            
        }




        // GET: ThanhToans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }

        // GET: ThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK");
            ViewBag.MaVe = new SelectList(db.Ves, "MaVe", "MaVe");
            return View();
        }

        // POST: ThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThanhToan,MaVe,MaTK,ThoiGianThanhToan,MoTaThanhToan,TongTien")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.ThanhToans.Add(thanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", thanhToan.MaTK);
            ViewBag.MaVe = new SelectList(db.Ves, "MaVe", "MaVe", thanhToan.MaVe);
            return View(thanhToan);
        }

        // GET: ThanhToans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", thanhToan.MaTK);
            ViewBag.MaVe = new SelectList(db.Ves, "MaVe", "MaVe", thanhToan.MaVe);
            return View(thanhToan);
        }

        // POST: ThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThanhToan,MaVe,MaTK,ThoiGianThanhToan,MoTaThanhToan,TongTien")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", thanhToan.MaTK);
            ViewBag.MaVe = new SelectList(db.Ves, "MaVe", "MaVe", thanhToan.MaVe);
            return View(thanhToan);
        }

        // GET: ThanhToans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }

        // POST: ThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            db.ThanhToans.Remove(thanhToan);
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
