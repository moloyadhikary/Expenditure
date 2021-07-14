using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUi.Models.InputForms
{
    public class AddExpenditureInputModel
    {
        public int ItemTypeId { get; set; }
        public int ItemSubTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }
}