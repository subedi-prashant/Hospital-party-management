using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareLab.Models
{
    public class CombinedData
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string TableName { get; set; }
        public List<CombinedData> MergedData { get; set; }
        //public List<CombinedData> SelectedData { get; set; }
        public string ColorCode
        {
            get
            {
                if (TableName == "CreditParty")
                    return "#FFD6D5";
                else if (TableName == "Referred")
                    return "#ADD8E6";
                else
                    return "#90EE90";
            }
        }
    }
   
}