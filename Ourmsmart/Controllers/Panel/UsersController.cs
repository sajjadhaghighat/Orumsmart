using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ourmsmart.Filter;
using Ourmsmart.Models;

namespace Ourmsmart.Controllers.Panel
{
    [AdFilter]
    public class UsersController : Controller
    {
        private VIRADB db = new VIRADB();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.FAUsers.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAUser fAUser = db.FAUsers.Find(id);
            if (fAUser == null)
            {
                return HttpNotFound();
            }
            return View(fAUser);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,Fullname,Username,Password,Email,Bio,Team,Type,Imagepath")] FAUser fAUser)
        {
            if (ModelState.IsValid)
            {
                db.FAUsers.Add(fAUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fAUser);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAUser fAUser = db.FAUsers.Find(id);
            if (fAUser == null)
            {
                return HttpNotFound();
            }
            return View(fAUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,Fullname,Username,Password,Email,Bio,Team,Type,Imagepath")] FAUser fAUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAUser);
        }


        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAUser fAUser = db.FAUsers.Find(id);
            if (fAUser == null)
            {
                return HttpNotFound();
            }
            return View(fAUser);
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAUser fAUser = db.FAUsers.Find(id);
            db.FAUsers.Remove(fAUser);
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
    }
}
