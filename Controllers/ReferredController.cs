using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareLab.Repo;
using CareLab.Models;

namespace CareLab.Controllers
{
    public class ReferredController : Controller
    {
        DAL db = new DAL();
        // GET: Referred
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListData()
        {
            ModelState.Clear();
            return View(db.GetRefDataList());
        }
        // GET: Referred/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Referred/Create
        [HttpPost]
        public ActionResult Create(Referred obj)
        {
            if (ModelState.IsValid)
            {
                db.InsertRefData(obj);
            }
            return RedirectToAction("Index");
        }
        // GET: Referred/Edit/
        public ActionResult Edit(int id)
        {
            return View(db.GetRefDataList().Find(x => x.UserID == id));
        }

        // POST: Referred/Edit/
        [HttpPost]
        public ActionResult Edit(int UserID, Referred obj)
        {
            try
            {
                // TODO: Add update logic here
                if (db.UpdateRefData(obj))
                {
                    ViewBag.Message = "Referred Inserted";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Referred/Delete/
        public ActionResult Delete(int id)
        {
            return View(db.GetRefDataList().Find(x => x.UserID == id));
        }

        // POST: Referred/Delete/
        [HttpPost]
        public ActionResult Delete(int UserID, Referred obj)
        {
            try
            {
                // TODO: Add delete logic here
                if (db.DeleteRefData(obj))
                {
                    ViewBag.Message = "Referred Deleted";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}