using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace WebUi.Models.InputForms
{
    public class AddSubTypeInputModel
    {
        [Required(ErrorMessage = "Please provide sub type name")]
        [MinLength(4, ErrorMessage = "Please provide at least 4 characters long name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please provide description")]
        public string Description { get; set; }
        
        public int ItemTypeId { get; set; }
    }
}