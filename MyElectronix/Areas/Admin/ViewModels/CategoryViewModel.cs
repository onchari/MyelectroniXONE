using MyElectronix.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin
{
    public class CategoryViewModel
    {
       

        [MaxLength(45, ErrorMessage = "The category length must be maximum 45 characters.")]
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name ="Is Category Active?")]
        public bool IsActive { get; set; } = true;

        [Display(Name ="Description")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}