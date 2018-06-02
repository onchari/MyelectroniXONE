using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyElectronix.Areas.Admin.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product Name is required")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Price is required")]
        [Display(Name ="Unit Price")]
        public decimal ProductUnitPrice { get; set; }

        [Required(ErrorMessage ="Brand is Required")]
        [Display(Name ="Brand")]
        public string ProductBrand { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage ="Description is required")]
        [Display(Name ="Product Description")]
        public string ProductDescription { get; set; }

        
    }
}