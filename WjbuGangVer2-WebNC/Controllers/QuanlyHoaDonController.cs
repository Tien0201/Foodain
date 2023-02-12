﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class QuanlyHoaDonController : Controller
    {
         QLBHEntities db = new QLBHEntities();

        // GET: QuanlyHoaDon
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.Account).Include(h => h.PhuongThucThanhToan);
            List<HoaDon> hoaDonsList = db.HoaDons.Where(m => m.TinhTrang != 0).ToList();
            return View(hoaDonsList);
        }

        // GET: QuanlyHoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            List<HoaDonItem> items = new List<HoaDonItem>();
            string chiTiet = hoaDon.ChiTiet;
            string[] itemStrings = chiTiet.Split('-');
            foreach(string str in itemStrings)
            {
                int maMH = Convert.ToInt32(str.Split(':')[0]);
                int soLuong = Convert.ToInt32(str.Split(':')[1]);
                HoaDonItem newItem = new HoaDonItem();
                newItem._shopping_product = db.MatHangs.Where(a => a.MaMH == maMH).FirstOrDefault();
                newItem._shopping_quantity = soLuong;
                items.Add(newItem);
            }    
            HoaDonAdmin hoaDonAdmin = new HoaDonAdmin();
            hoaDonAdmin.hoaDon = hoaDon;
            hoaDonAdmin.items = items;
            return View(hoaDonAdmin);
        }

        // GET: QuanlyHoaDon/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username");
            ViewBag.MaPT = new SelectList(db.PhuongThucThanhToans, "MaPT", "TenPT");
            return View();
        }

        // POST: QuanlyHoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,Ngay,SoLuong,TongTien,MaPT,AccountID")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", hoaDon.AccountID);
            ViewBag.MaPT = new SelectList(db.PhuongThucThanhToans, "MaPT", "TenPT", hoaDon.MaPT);
            return View(hoaDon);
        }

        // GET: QuanlyHoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", hoaDon.AccountID);
            ViewBag.MaPT = new SelectList(db.PhuongThucThanhToans, "MaPT", "TenPT", hoaDon.MaPT);
            return View(hoaDon);
        }

        // POST: QuanlyHoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,Ngay,SoLuong,TongTien,MaPT,AccountID")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", hoaDon.AccountID);
            ViewBag.MaPT = new SelectList(db.PhuongThucThanhToans, "MaPT", "TenPT", hoaDon.MaPT);
            return View(hoaDon);
        }

        // GET: QuanlyHoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: QuanlyHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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

        //public PartialViewResult SearchHoaDon(string searchtxt)
        //{
        //    List<HoaDon> hoaDons = db.HoaDons.ToList();
        //    var result = hoaDons
        //    .Where(a => a.MaHD.ToString().Contains(searchtxt) ||
        //    a.Account.Username.ToLower().Contains(searchtxt.ToLower()) ||
        //    a.TongTien.ToString().Contains(searchtxt) ||
        //    a.SoLuong.ToString().Contains(searchtxt)).ToList();
        //    return PartialView("SearchView", result);
        //}

        //status
        public ActionResult Status(int id)
        {
            HoaDon morder = db.HoaDons.Find(id);
            morder.TinhTrang = (morder.TinhTrang == 1) ? 2 : 1;
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //trash
        public ActionResult trash()
        {
            var list = db.HoaDons.Where(m => m.TinhTrang == 0).ToList();
            return View("Trash", list);
        }
        public ActionResult Deltrash(int id)
        {
            HoaDon morder = db.HoaDons.Find(id);
            morder.TinhTrang = 0;
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int id)
        {
            HoaDon morder = db.HoaDons.Find(id);
            morder.TinhTrang = 2;
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("trash");
        }
        public ActionResult deleteTrash(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
