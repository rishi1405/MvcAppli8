﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppli8.Models;

namespace MvcAppli8.Controllers
{
    public class HomeController : Controller
    {
        private hdfcDBContext db = new hdfcDBContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("Index", "_Layout", db.Empls.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Empl empl = db.Empls.Find(id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            return View("Details","_Layout",empl);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View("Create","_Layout");
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Empl empl)
        {
            if (ModelState.IsValid)
            {
                db.Empls.Add(empl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create","_Layout",empl);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Empl empl = db.Empls.Find(id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            return View("Edit","_Layout",empl);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Empl empl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit","_Layout",empl);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Empl empl = db.Empls.Find(id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            return View("Delete","_Layout",empl);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empl empl = db.Empls.Find(id);
            db.Empls.Remove(empl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}