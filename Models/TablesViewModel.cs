using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareLab.Models
{
    public class TablesViewModel
    {
        public List<CreditParty> CreditPartyData { get; set; }
        public List<Referred> ReferredData { get; set; }
        public List<Requestor> RequestorData { get; set; }
        public string SearchText { get; set; }
        public int? SelectedCPId { get; set; }
        public List<CreditParty> SelectedCP { get; set; }
        public List<TablesViewModel> Selected { get; set; }

    }
}