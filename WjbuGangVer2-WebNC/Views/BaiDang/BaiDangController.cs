using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WjbuGangVer2_WebNC.Views.BanTin
{
    public class BaiDangController : Controller
    {
        // GET: BaiDang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BaiDang1() { return View(); }
        public ActionResult BaiDang2() { return View(); }
        public ActionResult BaiDang3() { return View(); }

    }
}