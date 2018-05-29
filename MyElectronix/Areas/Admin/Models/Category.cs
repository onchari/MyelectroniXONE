using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public virtual ICollection<Products> Products{ get; set; }

        public bool IsActive { get; set; } = true;
    }
}