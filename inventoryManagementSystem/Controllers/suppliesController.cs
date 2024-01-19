﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem;

namespace InventoryManagementSystem.Controllers
{
    public class suppliesController : Controller
    {
        private inventoryDBEntities db = new inventoryDBEntities();

        // GET: supplies
        public ActionResult Index()
        {
            return View(db.supplies.ToList());
        }

        // GET: supplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supply supply = db.supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // GET: supplies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sup_id,sup_name,sup_address,sup_phone,sup_openingBalance")] supply supply)
        {
            if (ModelState.IsValid)
            {
                db.supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supply);
        }

        // GET: supplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supply supply = db.supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sup_id,sup_name,sup_address,sup_phone,sup_openingBalance")] supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supply);
        }

        // GET: supplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supply supply = db.supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            supply supply = db.supplies.Find(id);
            db.supplies.Remove(supply);
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
