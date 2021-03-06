﻿using System;
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
    public class ContentsController : Controller
    {
        private VIRADB db = new VIRADB();

        // GET: Contents
        public ActionResult Index()
        {
            return View(db.FAContents.ToList().OrderByDescending(x => x.CID));
        }

        // GET: Contents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAContent fAContent = db.FAContents.Find(id);
            if (fAContent == null)
            {
                return HttpNotFound();
            }
            return View(fAContent);
        }

        // GET: Contents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CID,title,content")] FAContent fAContent)
        {
            if (ModelState.IsValid)
            {
                db.FAContents.Add(fAContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fAContent);
        }

        // GET: Contents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAContent fAContent = db.FAContents.Find(id);
            if (fAContent == null)
            {
                return HttpNotFound();
            }
            return View(fAContent);
        }

        // POST: Contents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CID,title,content")] FAContent fAContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAContent);
        }

        // GET: Contents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAContent fAContent = db.FAContents.Find(id);
            if (fAContent == null)
            {
                return HttpNotFound();
            }
            return View(fAContent);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAContent fAContent = db.FAContents.Find(id);
            db.FAContents.Remove(fAContent);
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
