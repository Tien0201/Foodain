using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class LoaiMHController : Controller
    {
         QLBHEntities db = new QLBHEntities();

        // GET: LoaiMH
        public ActionResult Index()
        {
            return View(db.LoaiMHs.ToList());
        }

        // GET: LoaiMH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            if (loaiMH == null)
            {
                return HttpNotFound();
            }
            return View(loaiMH);
        }

        // GET: LoaiMH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiMH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiMH loaiMH)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMHs.Add(loaiMH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiMH);
        }

        // GET: LoaiMH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            if (loaiMH == null)
            {
                return HttpNotFound();
            }
            return View(loaiMH);
        }

        // POST: LoaiMH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiMH loaiMH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMH);
        }

        // GET: LoaiMH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            if (loaiMH == null)
            {
                return HttpNotFound();
            }
            return View(loaiMH);
        }

        // POST: LoaiMH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            db.LoaiMHs.Remove(loaiMH);
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
        public ActionResult getDataLoaiMH()
        {
            int chickens = db.LoaiMHs.Where(x => x.TenLoai == "Gà").Count();
            int drinks = db.LoaiMHs.Where(x => x.TenLoai == "Nước").Count();
            int fries = db.LoaiMHs.Where(x => x.TenLoai == "Khoai").Count();
            int hamburger = db.LoaiMHs.Where(x => x.TenLoai == "Hamburger").Count();
            int other = db.LoaiMHs.Where(x => x.TenLoai == "Khác").Count();

            Ratio obj = new Ratio();
            obj.Chickens = chickens;
            obj.Drinks = drinks;
            obj.Fries = fries;
            obj.Hamburgers = hamburger;
            obj.Other = other;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int Chickens { get; set; }
            public int Drinks { get; set; }
            public int Fries { get; set; }
            public int Hamburgers { get; set; }
            public int Other { get; set; }
        }

        public PartialViewResult SearchLoaiMH(string searchtxt)
        {
            List<LoaiMH> loaiMHs = db.LoaiMHs.ToList();
            var result = loaiMHs
            .Where(a => a.MaLoai.ToString().Contains(searchtxt) ||
            a.TenLoai.ToLower().Contains(searchtxt.ToLower())).ToList();
            return PartialView("SearchViewLoaiMH", result);
        }

    }
}

