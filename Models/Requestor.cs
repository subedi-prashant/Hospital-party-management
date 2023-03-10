using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareLab.Models
{
    public class Requestor
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set;}
        public string Contactperson { get; set; }
        public string Mobileno { get; set; }
        public string Code { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Entrydate { get; set; }
        [Required(ErrorMessage = "Requestorname is required.")]
        public string Requestorname { get; set; }
        public string Address { get; set; }
    }
}