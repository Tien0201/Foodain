using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;
using System.Web.Helpers;
using System.Xml.Linq;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class AccountController : Controller
    {
        QLBHEntities cs = new QLBHEntities();
        // GET: Account
        public ActionResult AccountLogic()
        {
            if (Session["User_username"] != null)
            {
                return RedirectToAction("Index");
            }
            else if (Session["Admin_username"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AccountLogic(Account account)
        {
            var y = cs.Accounts.Where(a => a.Username == account.Username && a.Password == account.Password && a.Role == "User").FirstOrDefault();
            var x = cs.Accounts.Where(a => a.Username == account.Username && a.Password == account.Password && a.Role == "Admin").FirstOrDefault();
            if (y != null)
            {
                Session["User_ID"] = y.AccountID;
                Session["User_username"] = y.Username;

                Session["User_Name"] = y.HoTen.Substring(0, 4);
                Session["User_Email"] = y.Email;
                Session["User_Diachi"] = y.DiaChi;
                Session["User_SoDT"] = y.SoDT;


                ViewBag.User_Name = Session["User_Name"];
                return RedirectToAction("Index", "Home");

            }
            else if (x != null)
            {
                Session["Admin_ID"] = x.AccountID;
                Session["Admin_username"] = x.Username;
                Session["Admin_Name"] = x.HoTen;
                ViewBag.Admin_name = Session["Admin_Name"];
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Sai tài khoản hoặc mk";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account account, FormCollection fc)
        {
            string uname = fc["uname"];
            string fname = fc["fname"];
            string Pass = fc["psw"];
            string Pass2 = fc["repsw"];
            if (Pass2 != Pass)
            {
                ViewBag.error = "Pass không trùng";
                return View("Register");
            }
            string email = fc["email"];
            string address = fc["address"];
            string phone = fc["phone"];
            string birth = fc["birth"];

            if (ModelState.IsValid)
            {
                var Lusername = cs.Accounts.Where(m => m.Username == uname && m.Role == "User");
                var Lusermail = cs.Accounts.Where(m => m.Email == email && m.Role == "User");
                var Luserphone = cs.Accounts.Where(m => m.SoDT == phone && m.Role == "User");

                if (Lusername.Count() > 0)
                {
                    ViewBag.error = "Username đã tồn tại";
                    return View("Register");
                }
                else if (Lusermail.Count() > 0)
                {
                    ViewBag.error = "Email đã được sử dụng";
                    return View("Register");
                }
                else if (Luserphone.Count() > 0)
                {
                    ViewBag.error = "SĐT đã được sử dụng";
                    return View("Register");
                }
                else
                {
                    account.Password = Pass;
                    account.Username = uname;
                    account.HoTen = fname;
                    account.Email = email;
                    account.DiaChi = address;
                    account.SoDT = phone;
                    account.Role = "User";
                    cs.Accounts.Add(account);

                    Voucher voucher = new Voucher();
                    voucher.MaVoucher = "Welcome" + uname;
                    voucher.TenDot = "Welcome new user";
                    voucher.SoTienGiam = 10000;
                    voucher.LoaiGiamGia = "tructiep";
                    voucher.TinhTrang = "Y";

                    cs.Vouchers.Add(voucher);

                    cs.SaveChanges();
                    ViewBag.error = "Đăng ký thành công";
                    Session["Register_Success"] = "Dang Ky thanh cong, Foodain tang ban voucher Welcome" + uname;

                    return Redirect("AccountLogic");
                }
            }

            Session["Register_Success"] = "Đăng ký thành công, Foodain tặng bạn voucher Welcome" + uname;

            ViewBag.error = "Đăng ký thành công";
            return View("AccountLogic");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult AdminLogout()
        {
            Session["Admin_ID"] = null;
            Session["Admin_username"] = null;
            Session["Admin_Name"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Userlogout()
        {
            Session["User_ID"] = null;
            Session["User_username"] = null;
            Session["User_Name"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}