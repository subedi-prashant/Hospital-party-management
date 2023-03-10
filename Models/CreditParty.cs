using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareLab.Models
{
    public class CreditParty
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Display(Name = "Codeno", Description = "Enter the code no.")]
        [Required(ErrorMessage = "Codeno is required.")]
        [Remote("IsCodenoAvailable", "Validation", ErrorMessage = "{0}")]
        public int Codeno { get; set; }
        public int? PAN { get; set; } = 0000;
        public string Email { get; set; }
        [Required(ErrorMessage = "Credit value is required.")]
        public decimal Credit { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone no is required.")]
        [RegularExpression(@"^\d{10,}$", ErrorMessage = "Phone number must have at least 10 digits.")]
        public string Phoneno { get; set; }
        public string Description { get; set; }
    }
}