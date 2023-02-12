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
    public class AccountEntityController : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: AccountEntity
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: AccountEntity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: AccountEntity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountEntity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,Username,Password,HoTen,DiaChi,Email,SoDT,Role")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: AccountEntity/Edit/5
        public ActionResult Edit(int? id)
        {
            var listRole = new List<string>() { "User", "Admin" };
            ViewBag.listRole = listRole;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: AccountEntity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountID,Username,Password,HoTen,DiaChi,Email,SoDT,Role")] Account account)
        {
            var listRole = new List<string>() { "User", "Admin" };
            ViewBag.listRole = listRole;
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(account);
        }

        // GET: AccountEntity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: AccountEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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

        public PartialViewResult SearchAccount(string searchtxt)
        {
            List<Account> accounts = db.Accounts.ToList();
            var result = accounts
            .Where(a => a.AccountID.ToString().Contains(searchtxt) ||
            a.HoTen.ToLower().Contains(searchtxt.ToLower()) ||
            a.Username.ToLower().Contains(searchtxt.ToLower()) ||
            a.Password.ToLower().Contains(searchtxt.ToLower()) ||
            a.DiaChi.ToLower().Contains(searchtxt.ToLower()) ||
            a.Email.ToLower().Contains(searchtxt.ToLower()) ||
            a.SoDT.ToString().Contains(searchtxt) ||
            a.Role.ToLower().Contains(searchtxt.ToLower())).ToList();
            return PartialView("SearchViewAccount", result);
        }

    }
}

