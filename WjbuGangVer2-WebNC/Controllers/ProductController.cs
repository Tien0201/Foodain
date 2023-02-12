using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class ProductController : Controller
    {
        QLBHEntities db = new QLBHEntities();
        // GET: Product
        public ActionResult Index(int page = 1, int pagesize = 9)
        {
            var list = db.MatHangs.ToList().ToPagedList(page, pagesize);
            return View(list);
        }

        public ActionResult DetailsVM()
        {
            var mathangs = GetMatHangs();
            var comments = GetComments();

            DetailsVM model = new DetailsVM();
            model.MatHangs_items = mathangs;
            model.Comments_items = comments;

            return View(model);
        }

        public MatHang GetMatHangs()
        {
            int id = (int)Session["DetailsID"];
            MatHang listMH = db.MatHangs.Find(id);
            return listMH;
        }

        public List<Comment> GetComments()
        {
            int id = (int)Session["DetailsID"];
            List<Comment> listcmt = db.Comments.Where(x => x.MaMH == id).ToList();
            return listcmt;
        }
        // GET: ProductLoai
        public ActionResult IndexNSX(int mamh)
        {
            Session["mamh"] = mamh;
            var list = db.MatHangs.Where(x => x.MaLoai == mamh).ToList();
            return View(list);
        }

        public ActionResult IndexKhuyenMai()
        {
            var list = db.MatHangs.Where(x => x.MaKH != null).ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SortingProductType(int? chosen)
        {
            int mamh = (int)Session["mamh"];
            if (chosen == 5)
            {
                var list = (from s in db.MatHangs where s.MaLoai == mamh orderby s.DonGia ascending select s);
                return View(list);
            }
            else if (chosen == 4)
            {
                var list = (from s in db.MatHangs where s.MaLoai == mamh orderby s.DonGia descending select s);
                return View(list);
            }
            else if (chosen == 3)
            {
                var list = (from s in db.MatHangs where s.MaMH == mamh orderby s.TenMH ascending select s);
                return View(list);
            }
            else if (chosen == 2)
            {
                var list = (from s in db.MatHangs where s.MaMH == mamh orderby s.TenMH descending select s);
                return View(list);
            }
            else
            {
                var list = db.MatHangs.OrderByDescending(x => x.DonGia).ToList();
                return View(list);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SortingProductKhuyenMai(int? chosen)
        {
            if (chosen == 5)
            {
                var list = (from s in db.MatHangs where s.MaKH != null orderby s.DonGia ascending select s);
                return View(list);
            }
            else if (chosen == 4)
            {
                var list = (from s in db.MatHangs where s.MaKH != null orderby s.DonGia descending select s);
                return View(list);
            }
            else if (chosen == 3)
            {
                var list = (from s in db.MatHangs where s.MaKH != null orderby s.TenMH ascending select s);
                return View(list);
            }
            else if (chosen == 2)
            {
                var list = (from s in db.MatHangs where s.MaKH != null orderby s.TenMH descending select s);
                return View(list);
            }
            else
            {
                var list = db.MatHangs.OrderByDescending(x => x.DonGia).ToList();
                return View(list);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SortingProduct(int? chosen)
        {
            if (chosen == 5)
            {
                var list = (from s in db.MatHangs orderby s.DonGia ascending select s);
                return View(list);
            }
            else if (chosen == 4)
            {
                var list = (from s in db.MatHangs orderby s.DonGia descending select s);
                return View(list);
            }
            else if (chosen == 3)
            {
                var list = (from s in db.MatHangs orderby s.TenMH ascending select s);
                return View(list);
            }
            else if (chosen == 2)
            {
                var list = (from s in db.MatHangs orderby s.TenMH descending select s);
                return View(list);
            }
            else
            {
                var list = db.MatHangs.OrderByDescending(x => x.DonGia).ToList();
                return View(list);
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            MatHang chitiet = db.MatHangs.Find(id);
            List<Comment> comments = new List<Comment>();
            var comment = db.Comments.Where(x => x.MaMH == id).ToList();
            comments = db.Comments.Where(x => x.MaMH == id).ToList();

            Session["DetailsID"] = id;

            DetailsVM model = new DetailsVM();
            model.MatHangs_items = chitiet;
            model.Comments_items = comments;

            //DonGiaNeuCoKhuyenMai
            if(chitiet.MaKH == null)
            {
                Session["DonGia"] = (chitiet.DonGia).ToString("#,##0");
                Session["DonGiaTruocKM"] = "";
            }
            var checkmakm = (from x in db.MatHangs where x.MaMH == id select x.MaKH).FirstOrDefault();
            var loaikm = (from x in db.KhuyenMais where x.MaKH == checkmakm select x.Loai).FirstOrDefault();
            var giagiam = (from x in db.KhuyenMais where x.MaKH == checkmakm select x.GiaGiam).FirstOrDefault();
            if (chitiet.MaKH != null && loaikm == "phantram")
            {
                Session["DonGiaTruocKM"] = (chitiet.DonGia ).ToString("#,##0") + " VNĐ";
                double giasaukm = (chitiet.DonGia - (chitiet.DonGia * giagiam / 100)) ;
                Session["DonGia"] = giasaukm.ToString("#,##0");
            }
            if (chitiet.MaKH != null && loaikm == "nghin")
            {
                Session["DonGiaTruocKM"] = (chitiet.DonGia ).ToString("#,##0");
                double giasaukm = (chitiet.DonGia - giagiam) ;
                Session["DonGia"] = giasaukm.ToString("#,##0");
            }
            Session["TenMH"] = chitiet.TenMH;
            Session["DonGiaGoc"] = (chitiet.DonGia).ToString("#,##0");
            Session["Mota"] = chitiet.MoTa;
            Session["HinhChinh"] = chitiet.HinhChinh;
            Session["Hinh1"] = chitiet.Hinh1;
            Session["Hinh2"] = chitiet.Hinh2;
            Session["Hinh3"] = chitiet.Hinh3;
            Session["Hinh4"] = chitiet.Hinh4;
            Session["MaMH"] = chitiet.MaMH;


            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
