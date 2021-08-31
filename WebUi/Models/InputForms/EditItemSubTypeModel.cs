using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUi.Models.InputForms
{
    public class EditItemSubTypeModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide sub type name")]
        [MinLength(4, ErrorMessage = "Please provide at least 4 characters long name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide description")]
        public string Description { get; set; }

        [Required]
        public int ItemTypeId { get; set; }
    }
}