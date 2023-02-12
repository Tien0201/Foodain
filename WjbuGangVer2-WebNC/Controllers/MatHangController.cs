using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;
using System.IO;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Validation;
using System.Runtime.CompilerServices;
using System.EnterpriseServices;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class MatHangController : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: MatHang
        public ActionResult Index()
        {
            var matHangs = db.MatHangs.Include(m => m.LoaiMH);
            return View(matHangs.ToList());
        }

        // GET: MatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // GET: MatHang/Create
        public ActionResult Create()
        {
            MatHang matHang = new MatHang();
            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai");
            return View(matHang);
        }

        // POST: MatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatHang matHang)
        {
            //string fileName = Path.GetFileNameWithoutExtension(matHang.ImageFile.FileName);
            //string fileName1 = Path.GetFileNameWithoutExtension(matHang.ImageFile1.FileName);
            //string fileName2 = Path.GetFileNameWithoutExtension(matHang.ImageFile2.FileName);
            //string fileName3 = Path.GetFileNameWithoutExtension(matHang.ImageFile3.FileName);
            //string fileName4 = Path.GetFileNameWithoutExtension(matHang.ImageFile4.FileName);

            //string extension = Path.GetExtension(matHang.ImageFile.FileName);
            //string extension1 = Path.GetExtension(matHang.ImageFile1.FileName);
            //string extension2 = Path.GetExtension(matHang.ImageFile2.FileName);
            //string extension3 = Path.GetExtension(matHang.ImageFile3.FileName);
            //string extension4 = Path.GetExtension(matHang.ImageFile4.FileName);

            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
            //fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
            //fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
            //fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension4;



            //matHang.HinhChinh = "/Content/Images/" + fileName;
            //matHang.Hinh1 = "/Content/Images/"  + fileName1;
            //matHang.Hinh2 = "/Content/Images/"  + fileName2;
            //matHang.Hinh3 = "/Content/Images/"  + fileName3;
            //matHang.Hinh4 = "/Content/Images/"  + fileName4;

            //fileName = Path.Combine(Server.MapPath("/Content/Images/"), fileName);
            //fileName1 = Path.Combine(Server.MapPath("/Content/Images/"), fileName1);
            //fileName2 = Path.Combine(Server.MapPath("/Content/Images/"), fileName2);
            //fileName3 = Path.Combine(Server.MapPath("/Content/Images/"), fileName3);
            //fileName4 = Path.Combine(Server.MapPath("/Content/Images/"), fileName4);

            //matHang.ImageFile.SaveAs(fileName);
            //matHang.ImageFile1.SaveAs(fileName1);
            //matHang.ImageFile2.SaveAs(fileName2);
            //matHang.ImageFile3.SaveAs(fileName3);
            //matHang.ImageFile4.SaveAs(fileName4);


            //System.Diagnostics.Debug.WriteLine("Hinh chinh: " + matHang.HinhChinh);
            //System.Diagnostics.Debug.WriteLine("MaMH: " + matHang.MaMH);

            if (matHang.ImageFile != null)
            {
                string fileName = matHang.ImageFile.FileName;
                matHang.HinhChinh = "/Content/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Content/Images/"), fileName);
                matHang.ImageFile.SaveAs(fileName);
            }
            if (matHang.ImageFile1 != null)
            {
                string fileName1 = matHang.ImageFile1.FileName;
                matHang.Hinh1 = "/Content/Images/" + fileName1;
                fileName1 = Path.Combine(Server.MapPath("/Content/Images/"), fileName1);
                matHang.ImageFile1.SaveAs(fileName1);
            }

            if (matHang.ImageFile2 != null)
            {
                string fileName2 = matHang.ImageFile2.FileName;
                matHang.Hinh2 = "/Content/Images/" + fileName2;
                fileName2 = Path.Combine(Server.MapPath("/Content/Images/"), fileName2);
                matHang.ImageFile2.SaveAs(fileName2);
            }

            if (matHang.ImageFile3 != null)
            {
                string fileName3 = matHang.ImageFile3.FileName;
                matHang.Hinh3 = "/Content/Images/" + fileName3;
                fileName3 = Path.Combine(Server.MapPath("/Content/Images/"), fileName3);
                matHang.ImageFile3.SaveAs(fileName3);
            }

            if (matHang.ImageFile4 != null)
            {
                string fileName4 = matHang.ImageFile4.FileName;
                matHang.Hinh4 = "/Content/Images/" + fileName4;
                fileName4 = Path.Combine(Server.MapPath("/Content/Images/"), fileName4);
                matHang.ImageFile4.SaveAs(fileName4);
            }




            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai", matHang.MaLoai);


            //fileName = Path.GetFullPath(fileName);
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            return View(matHang);
        }

        // GET: MatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai", matHang.MaLoai);
            return View(matHang);
        }

        // POST: MatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MatHang matHang)
        {
            if (matHang.ImageFile != null)
            {
                string fileName = matHang.ImageFile.FileName;
                matHang.HinhChinh = "/Content/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Content/Images/"), fileName);
                matHang.ImageFile.SaveAs(fileName);
            }
            else
            {
                string fileName = db.MatHangs.Find(matHang.MaMH).HinhChinh;
                matHang.HinhChinh = fileName;
            }
            if (matHang.ImageFile1 != null)
            {
                string fileName1 = matHang.ImageFile1.FileName;
                matHang.Hinh1 = "/Content/Images/" + fileName1;
                fileName1 = Path.Combine(Server.MapPath("/Content/Images/"), fileName1);
                matHang.ImageFile1.SaveAs(fileName1);
            }
            else
            {
                string fileName1 = db.MatHangs.Find(matHang.MaMH).Hinh1;
                matHang.Hinh1 = fileName1;
            }
            if (matHang.ImageFile2 != null)
            {
                string fileName2 = matHang.ImageFile2.FileName;
                matHang.Hinh2 = "/Content/Images/" + fileName2;
                fileName2 = Path.Combine(Server.MapPath("/Content/Images/"), fileName2);
                matHang.ImageFile2.SaveAs(fileName2);
            }
            else
            {
                string fileName2 = db.MatHangs.Find(matHang.MaMH).Hinh2;
                matHang.Hinh2 = fileName2;
            }
            if (matHang.ImageFile3 != null)
            {
                string fileName3 = matHang.ImageFile3.FileName;
                matHang.Hinh3 = "/Content/Images/" + fileName3;
                fileName3 = Path.Combine(Server.MapPath("/Content/Images/"), fileName3);
                matHang.ImageFile3.SaveAs(fileName3);
            }
            else
            {
                string fileName3 = db.MatHangs.Find(matHang.MaMH).Hinh3;
                matHang.Hinh3 = fileName3;
            }
            if (matHang.ImageFile4 != null)
            {
                string fileName4 = matHang.ImageFile4.FileName;
                matHang.Hinh4 = "/Content/Images/" + fileName4;
                fileName4 = Path.Combine(Server.MapPath("/Content/Images/"), fileName4);
                matHang.ImageFile4.SaveAs(fileName4);
            }
            else
            {
                string fileName4 = db.MatHangs.Find(matHang.MaMH).Hinh4;
                matHang.Hinh3 = fileName4;
            }

            if (ModelState.IsValid)
            {
                db.Entry(db.MatHangs.Find(matHang.MaMH)).CurrentValues.SetValues(matHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai", matHang.MaLoai);
            return View(matHang);
        }
        // GET: MatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: MatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            db.MatHangs.Remove(matHang);
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

        public ActionResult getDataMatHang()
        {
            int chickens = db.MatHangs.Where(x => x.MaLoai == 1).Count();
            int drinks = db.MatHangs.Where(x => x.MaLoai == 2).Count();
            int hamburger = db.MatHangs.Where(x => x.MaLoai == 3).Count();
            int fries = db.MatHangs.Where(x => x.MaLoai == 4).Count();
            int other = db.MatHangs.Where(x => x.MaLoai == 5).Count();

            Ratio obj = new Ratio();
            obj.Chickens = chickens;
            obj.Drinks = drinks;
            obj.Hamburgers = hamburger;
            obj.Fries = fries;
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

        public PartialViewResult SearchMatHang(string searchtxt)
        {
            List<MatHang> matHangs = db.MatHangs.ToList();
            var result = matHangs
            .Where(a => a.MaMH.ToString().Contains(searchtxt) ||
            a.TenMH.ToLower().Contains(searchtxt.ToLower()) ||
            a.MoTa.ToLower().Contains(searchtxt.ToLower()) ||
            a.Size.ToString().Contains(searchtxt) ||
            a.SoLuong.ToString().Contains(searchtxt)).ToList();
            return PartialView("SearchViewMatHang", result);
        }
    }
}
