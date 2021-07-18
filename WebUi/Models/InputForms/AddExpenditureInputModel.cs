using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUi.Models.InputForms
{
    public class AddExpenditureInputModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ItemTypeId { get; set; }
        
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ItemSubTypeId { get; set; }
        
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Minimum amount should be 1")]
        public decimal Amount { get; set; }
        
        [Required]
        public string DataDate { get; set; }
        public string Remarks { get; set; }
    }
}