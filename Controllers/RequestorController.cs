using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareLab.Repo;
using CareLab.Models;

namespace CareLab.Controllers
{
    public class RequestorController : Controller
    {
        DAL db = new DAL();
        // GET: Requestor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListData()
        {
            ModelState.Clear();
            return View(db.GetReqDataList());
        }
        // GET: Requestor/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Requestor/Create
        [HttpPost]
        public ActionResult Create(Requestor obj)
        {
            if (ModelState.IsValid)
            {
                db.InsertReqData(obj);
            }
            return RedirectToAction("Index");
        }
        // GET: Requestor/Edit/
        public ActionResult Edit(int id)
        {
            return View(db.GetReqDataList().Find(x => x.UserID == id));
        }

        // POST: Requestor/Edit/
        [HttpPost]
        public ActionResult Edit(int UserID, Requestor obj)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                db.UpdateReqData(obj);
            }
            return RedirectToAction("Index");
        }
        // GET: Requestor/Delete/
        public ActionResult Delete(int id)
        {
            return View(db.GetReqDataList().Find(x => x.UserID == id));
        }

        // POST: Requestor/Delete/
        [HttpPost]
        public ActionResult Delete(int UserID, Requestor obj)
        {
            try
            {
                // TODO: Add delete logic here
                if (db.DeleteReqData(obj))
                {
                    ViewBag.Message = "Requestor Deleted";
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