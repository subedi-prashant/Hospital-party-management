using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareLab.Models
{
    public class Referred
    {
        public int UserID { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Office { get; set;}
        public string NMCno { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Entrydate { get; set; }
        [Required(ErrorMessage = "Doctorname is required.")]
        public string Doctorname { get; set; }
        public string Hospitalname { get; set; }
        public string Specilist { get; set; }

    }
}