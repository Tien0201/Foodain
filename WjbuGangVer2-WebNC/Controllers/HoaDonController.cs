using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class HoaDonController : Controller
    {
        QLBHEntities _db = new QLBHEntities();
        // GET: 
        public HoaDon GetHoaDon()
        {
            HoaDon hoadon = Session["HoaDon"] as HoaDon;

            if (hoadon == null)
            {
                hoadon = new HoaDon();
                Session["HoaDon"] = hoadon;
            }
            return hoadon;
        }

        //Phương thức add item
        public ActionResult AddToCart(int id)
        {
            Session["GiaApDungVoucher"] = null;
            var pro = _db.MatHangs.SingleOrDefault(s => s.MaMH == id);
            if (pro != null)
            {
                GetHoaDon().Add(pro);
            }
            Session["GiaKhongApDungVoucher"] = GetHoaDon().Total_Money();

            return RedirectToAction("Details", "Product", new { id = id });
        }

        public ActionResult CreateOrder(int id)
        {
            Session["GiaApDungVoucher"] = null;
            var pro = _db.MatHangs.SingleOrDefault(s => s.MaMH == id);
            if (pro != null)
            {
                GetHoaDon().Add(pro);
            }

            Session["GiaKhongApDungVoucher"] = GetHoaDon().Total_Money();

            //return RedirectToAction("Details", "Product", new { id = id});
            return RedirectToAction("ShowToCart");
        }

        //Trang giỏ hàng
        public ActionResult ShowToCart()
        {
            if (Session["HoaDon"] == null)
                return RedirectToAction("Index", "Product");
            return View(Session["HoaDon"]);
        }

        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Session["GiaApDungVoucher"] = null;
            HoaDon hoadon = Session["HoaDon"] as HoaDon;
            int id_pro = int.Parse(form["Ma_MH"]);
            int quantity = int.Parse(form["Quantity"]);
            hoadon.Update_Quantity_Shopping(id_pro, quantity);

            return RedirectToAction("ShowToCart", "HoaDon");
        }

        public ActionResult RemoveCart(int id)
        {
            HoaDon hoadon = Session["HoaDon"] as HoaDon;
            Session["GiaApDungVoucher"] = null;
            hoadon.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "HoaDon");
        }

        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            HoaDon hoadon = Session["HoaDon"] as HoaDon;
            if (hoadon != null)
            {
                _t_item = hoadon.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }



        [HttpPost]
        public ActionResult ThanhToan(FormCollection frc)
        {
            QLBHEntities db = new QLBHEntities();
            HoaDon _hoadon = new HoaDon();

            _hoadon.Ngay = DateTime.Now;
            _hoadon.SoLuong = 0;
            _hoadon.TongTien = 0;
            double giagiambangvoucher = Convert.ToDouble(Session["GiaApDungVoucher"]);
            if (Session["GiaApDungVoucher"] == null)
            {
                foreach (HoaDonItem item in GetHoaDon().items)
                {
                    _hoadon.TongTien += item._shopping_price * item._shopping_quantity;
                    _hoadon.SoLuong += item._shopping_quantity;
                }
                //Session["GiaKhongApDungVoucher"] = _hoadon.TongTien;
            }
            else
            {
                foreach (HoaDonItem item in GetHoaDon().items)
                {
                    _hoadon.TongTien += item._shopping_price * item._shopping_quantity;
                    _hoadon.SoLuong += item._shopping_quantity;

                }
                _hoadon.TongTien = giagiambangvoucher;
            }
            
            int maPT = 0;
            bool parse = Int32.TryParse(frc["pttt"], out maPT);
            if(parse)
            {
                _hoadon.MaPT = maPT;
            }
            else
            {
                return View(Session["HoaDon"]);
            }

            string chiTiet = "";
            int i = 0;
            foreach (HoaDonItem item in GetHoaDon().items)
            {
                var slr = item._shopping_quantity;

                chiTiet += item._shopping_product.MaMH + ":" + item._shopping_quantity;
                if (i < GetHoaDon().items.Count - 1)
                {
                    chiTiet += "-";
                }
                i++;
                db.MatHangs.Where(a => a.MaMH == item._shopping_product.MaMH).FirstOrDefault().SoLuong -= slr;
            }

            var ma_voucher = Session["MaVoucher"];
            int voucher_id = db.Vouchers.Where(x => x.MaVoucher == ma_voucher).Select(x => x.VoucherID).FirstOrDefault();
            if (ma_voucher != null)
            {
                _hoadon.VoucherID = voucher_id;
                //update tinh trang voucher
                var ma_voucher_check = ma_voucher.ToString().Substring(0, 3);
                Voucher _voucher = new Voucher();
                _voucher = db.Vouchers.Find(voucher_id);

                if (ma_voucher_check == "FDA")
                {
                    _voucher.TinhTrang = "Y";
                }
                else
                {
                    _voucher.TinhTrang = "X";
                }
                db.Entry(_voucher).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            } 
            else
            {
                _hoadon.VoucherID = null;
            }

            _hoadon.AccountID = (int)Session["User_ID"];
            _hoadon.TinhTrang = 2;
            _hoadon.ChiTiet = chiTiet;
            db.HoaDons.Add(_hoadon);
            db.SaveChanges();

            Session["MaVoucher"] = null;
            Session["HoaDon"] = null;
            Session["GiaApDungVoucher"] = null;
            Session["GiaKhongApDungVoucher"] = null;
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult ThanhToan()
        {
            return View(Session["HoaDon"]);
        }



        [HttpPost]
        public ActionResult XacNhanDatHang(FormCollection frc)
        {
            QLBHEntities db = new QLBHEntities();
            HoaDon _hoadon = new HoaDon();

            _hoadon.Ngay = DateTime.Now;
            _hoadon.SoLuong = 0;
            _hoadon.TongTien = 0;
            double giagiambangvoucher = Convert.ToDouble(Session["GiaApDungVoucher"]);
            if (Session["GiaApDungVoucher"] == null)
            {
                foreach (HoaDonItem item in GetHoaDon().items)
                {
                    _hoadon.TongTien += item._shopping_price * item._shopping_quantity;
                    _hoadon.SoLuong += item._shopping_quantity;
                }
            }
            else
            {
                foreach (HoaDonItem item in GetHoaDon().items)
                {
                    _hoadon.TongTien += item._shopping_price * item._shopping_quantity;
                    _hoadon.SoLuong += item._shopping_quantity;

                }
                _hoadon.TongTien = giagiambangvoucher;
            }


            string chiTiet = "";
            int i = 0;
            foreach (HoaDonItem item in GetHoaDon().items)
            {
                var slr = item._shopping_quantity;

                chiTiet += item._shopping_product.MaMH + ":" + item._shopping_quantity;
                if (i < GetHoaDon().items.Count - 1)
                {
                    chiTiet += "-";
                }
                i++;
                db.MatHangs.Where(a => a.MaMH == item._shopping_product.MaMH).FirstOrDefault().SoLuong -= slr;
            }

            var ma_voucher = Session["MaVoucher"];
            int voucher_id = db.Vouchers.Where(x => x.MaVoucher == ma_voucher).Select(x => x.VoucherID).FirstOrDefault();
            if (ma_voucher != null)
            {
                _hoadon.VoucherID = voucher_id;
                //update tinh trang voucher
                var ma_voucher_check = ma_voucher.ToString().Substring(0, 3);
                Voucher _voucher = new Voucher();
                _voucher = db.Vouchers.Find(voucher_id);

                if (ma_voucher_check == "FDA")
                {
                    _voucher.TinhTrang = "Y";
                }
                else
                {
                    _voucher.TinhTrang = "X";
                }
                db.Entry(_voucher).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                _hoadon.VoucherID = null;
            }
            _hoadon.MaPT = 1;
            _hoadon.AccountID = (int)Session["User_ID"];
            _hoadon.TinhTrang = 2;
            _hoadon.ChiTiet = chiTiet;
            db.HoaDons.Add(_hoadon);
            db.SaveChanges();

            Session["MaVoucher"] = null;
            Session["HoaDon"] = null;
            Session["GiaApDungVoucher"] = null;
            Session["GiaKhongApDungVoucher"] = null;
            return RedirectToAction("Index", "Product");
        }



        [HttpGet]
        public ActionResult XacNhanDatHang()
        {
            return View(Session["HoaDon"]);
        }



        //NhapVoucher
        [HttpPost]
        public ActionResult NhapVoucher(string voucher_input)
        {
            QLBHEntities db = new QLBHEntities();
            HoaDon hoadon = new HoaDon();

            int user_id = (int)Session["User_ID"];

            var maVoucher_check = db.Vouchers.Where(x => x.MaVoucher == voucher_input).FirstOrDefault();

            var maVoucherdadungUserID_check = db.HoaDons.Where(x => x.AccountID == user_id).ToList();
            var maVoucherdadung_check = maVoucherdadungUserID_check.Where(x => x.VoucherID == maVoucher_check.VoucherID).FirstOrDefault();

            if (maVoucher_check != null && maVoucher_check.TinhTrang == "Y" && maVoucherdadung_check == null)
            {
                Session["MaVoucher"] = maVoucher_check.MaVoucher;
                var loaiGiamgia_check = maVoucher_check.LoaiGiamGia.FirstOrDefault();
                double voucher_price_decrease = maVoucher_check.SoTienGiam;
                Session["GiaApDungVoucher"] = GetHoaDon().New_Total_Money(voucher_price_decrease).ToString("#,##0");
            }
            else if (maVoucher_check != null && maVoucher_check.TinhTrang == "Y" && maVoucherdadung_check != null)
            {
                Session["Voucher_error"] = "Bạn đã sử dụng Voucher này";
            }
            else if(maVoucher_check != null && maVoucher_check.TinhTrang == "X" && maVoucherdadung_check == null)
            {
                Session["Voucher_error"] = "Voucher đã hết hạn";
            }
            else
            {
                Session["Voucher_error"] = "Voucher không hợp lệ";
            }
            return RedirectToAction("ShowToCart", "HoaDon");
        }


        //phương thức thanh toán
        //public ActionResult CheckOut(FormCollection form)
        //{
        //try
        //{
        //HoaDon hoadon = Session["HoaDon"] as HoaDon;
        //HoaDonDetail _other =new HoaDon();
        //_other.Ngay = DateTime.Now;
        //foreach(var item in hoadon.Items)
        //{
        //HoaDon 
        //}    
        //}
        //}
    }
}