using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareLab.Models;
using CareLab.Repo;

namespace CareLab.Controllers
{
    public class TablesViewController : Controller
    {
        DAL db = new DAL();   
        // GET: TablesView
        public ActionResult Index()
        {
            TablesViewModel tablesViewModel = new TablesViewModel();
            tablesViewModel.CreditPartyData = db.GetDataList().ToList();
            tablesViewModel.ReferredData = db.GetRefDataList().ToList();
            tablesViewModel.RequestorData = db.GetReqDataList().ToList();
            return View(tablesViewModel);
        }
        //[HttpPost]
        //public ActionResult Search(TablesViewModel model)
        //{
        //    var searchText = model.SearchText;
        //    var CreditParties = db.GetDataList().Where(t => t.Name.Contains(searchText)).ToList();
        //    var Referreds = db.GetRefDataList().Where(t => t.Doctorname.Contains(searchText)).ToList();
        //    var Requestors = db.GetReqDataList().Where(t => t.Requestorname.Contains(searchText)).ToList();

        //    model.CreditPartyData = CreditParties;
        //    model.ReferredData = Referreds;
        //    model.RequestorData = Requestors;

        //    return View(model);
        //}

        public ActionResult SelectBar()
        {
            //var dataCP = db.GetDataList();
            //var dataRef = db.GetRefDataList();
            //var dataReq = db.GetReqDataList();
            //// ...populate the lists...
            //List<object> combinedList = dataCP.Cast<object>()
            //    .Concat(dataRef.Cast<object>())
            //    .Concat(dataReq.Cast<object>())
            //    .ToList();
            //return View(combinedList);


            var dataCP = db.GetDataList();
            var dataRef = db.GetRefDataList();
            var dataReq = db.GetReqDataList();
            var viewModel = new TablesViewModel
            {
                CreditPartyData = dataCP,
                ReferredData = dataRef,
                RequestorData = dataReq,
                SelectedCP = new List<CreditParty>()
                //Selected = new List<TablesViewModel>()
            };
            return View(viewModel);
        }
        public ActionResult DropDown()
        {
            var CombinedData = db.ListData();
            var MergedData = new CombinedData()
            {
                MergedData = CombinedData,
                //SelectedData = new List<CombinedData>()
            };
            return View(MergedData);
        }
    }
}