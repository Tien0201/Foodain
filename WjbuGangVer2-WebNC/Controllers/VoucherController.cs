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
    public class VoucherController : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: Voucher
        public ActionResult Index()
        { 
            List<Voucher> vouchersList = new List<Voucher>();
            vouchersList = db.Vouchers.Where(m => m.TinhTrang != "Z").ToList();
            return View(vouchersList);
        }

        // GET: Voucher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // GET: Voucher/Create
        public ActionResult Create()
        {
            var loaigiamgia = new List<string>() { "Trực tiếp", "Phần trăm" };
            ViewBag.loaigiamgia = loaigiamgia;

            Voucher voucher = new Voucher();
            voucher.TinhTrang = "X";
            return View(voucher);
        }

        // POST: Voucher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoucherID,MaVoucher,TenDot,SoTienGiam,LoaiGiamGia,TinhTrang")] Voucher voucher)
        {
            var loaigiamgia = new List<string>() { "Trực tiếp", "Phần trăm" };
            ViewBag.loaigiamgia = loaigiamgia;
            voucher.TinhTrang = "X";

            if (ModelState.IsValid)
            {
                db.Vouchers.Add(voucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voucher);
        }

        // GET: Voucher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: Voucher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoucherID,MaVoucher,TenDot,SoTienGiam,LoaiGiamGia,TinhTrang")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voucher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voucher);
        }

        // GET: Voucher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: Voucher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            db.Vouchers.Remove(voucher);
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
        //public PartialViewResult SearchVoucher(string searchtxt)
        //{
        //    List<Voucher> vouchers = db.Vouchers.ToList();
        //    var result = vouchers
        //    .Where(a => a.VoucherID.ToString().Contains(searchtxt) ||
        //    a.MaVoucher.ToLower().Contains(searchtxt.ToLower()) ||
        //    a.TenDot.ToLower().Contains(searchtxt.ToLower()) ||
        //    a.SoTienGiam.ToString().Contains(searchtxt) ||
        //    a.LoaiGiamGia.ToLower().Contains(searchtxt.ToLower()) ||
        //    a.TinhTrang.ToLower().Contains(searchtxt.ToLower())).ToList();
        //    return PartialView("SearchViewVoucher", result);
        //}
        public ActionResult Status(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            voucher.TinhTrang = (voucher.TinhTrang == "Y") ? "X" : "Y";
            db.Entry(voucher).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //trash
        public ActionResult trash()
        {
            var list = db.Vouchers.Where(m => m.TinhTrang == "Z").ToList();
            return View("Trash", list);
        }
        public ActionResult Deltrash(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            voucher.TinhTrang = "Z";
            db.Entry(voucher).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            voucher.TinhTrang = "X";
            db.Entry(voucher).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("trash");
        }
        public ActionResult deleteTrash(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            db.Vouchers.Remove(voucher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
