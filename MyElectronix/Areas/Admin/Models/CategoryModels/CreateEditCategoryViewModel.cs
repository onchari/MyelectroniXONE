using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models.CategoryModels
{
    public class CreateEditCategoryViewModel
    {
       

        [Display(Name = "Category Name")]
        [Required]
        [StringLength(30, ErrorMessage = "This Length should not be more than 30 characters.")]
        public string CategoryName { get; set; }

        [Display(Name ="Category Icon")]
        public int CategoryIconId { get; set; }

        [Display(Name ="Creation Date")]
        public DateTime DateCreated { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}