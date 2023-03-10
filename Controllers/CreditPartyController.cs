using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareLab.Models;
using CareLab.Repo;

namespace CareLab.Controllers
{
    public class CreditPartyController : Controller
    {
        DAL db = new DAL();
        // GET: CreditParty
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListData()
        {
            ModelState.Clear();
            return View(db.GetDataList());
        }
        // GET: CreditParty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditParty/Create
        [HttpPost]
        public ActionResult Create(CreditParty obj)
        {
                if (ModelState.IsValid)
                {
                    db.InsertData(obj);
                }
                return RedirectToAction("Index");
        }
        // GET: CreditParty/Edit/
        public ActionResult Edit(int id)
        {
            return PartialView(db.GetDataList().Find(x => x.Codeno == id));
        }

        // POST: CreditParty/Edit/
        [HttpPost]
        public ActionResult Edit(int Codeno, CreditParty obj)
        {
            if (ModelState.IsValid)
            {
                db.UpdateData(obj);
            }
            return RedirectToAction("Index");
        }
        // GET: CreditParty/Delete/
        public ActionResult Delete(int id)
        {
            return View(db.GetDataList().Find(x => x.Codeno == id));
        }

        // POST: CreditParty/Delete/
        [HttpPost]
        public ActionResult Delete(int Codeno, CreditParty obj)
        {
            try
            {
                // TODO: Add delete logic here
                if (db.DeleteData(obj))
                {
                    ViewBag.Message = "CreditParty Deleted";
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