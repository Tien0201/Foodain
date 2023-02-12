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
    public class CommentController : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: Comment
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Account).Include(c => c.MatHang);
            return View(comments.ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username");
            ViewBag.MaMH = new SelectList(db.MatHangs, "MaMH", "TenMH");
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CmtID,MaMH,AccountID,CmtMsg,CmtDate,ParentID,DanhGia")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", comment.AccountID);
            ViewBag.MaMH = new SelectList(db.MatHangs, "MaMH", "TenMH", comment.MaMH);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCmt(string cmtmsg, int star)
        {
            var product_id = (int)Session["DetailsID"];
            var user_id = (int)Session["User_ID"];
            var user_get_name = db.Accounts.Where(x => x.AccountID == user_id).FirstOrDefault();

            var user_name = user_get_name.HoTen;

            ViewBag.message = "Bình luận đã được đăng";
            Comment _comment = new Comment();
            _comment.MaMH = product_id;
            _comment.AccountID = user_id;
            _comment.CmtMsg = cmtmsg;
            _comment.CmtDate = DateTime.Now;
            _comment.DanhGia = star;
            _comment.HoTen = user_name;

            db.Comments.Add(_comment);
            db.SaveChanges();

            return RedirectToAction("Details", "Product", new { id = product_id });
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", comment.AccountID);
            ViewBag.MaMH = new SelectList(db.MatHangs, "MaMH", "TenMH", comment.MaMH);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CmtID,MaMH,AccountID,CmtMsg,CmtDate,ParentID,DanhGia")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", comment.AccountID);
            ViewBag.MaMH = new SelectList(db.MatHangs, "MaMH", "TenMH", comment.MaMH);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
        [HttpPost]
        public ActionResult CommentInput(Comment comment, FormCollection fc)
        {
            string cmtmsg = fc["CommentMessage"];
            string DanhGia = fc["Rate"];

            return RedirectToAction("Details", "Product", new { id = Session["DetailsID"] });
        }
    }
}
