
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyElectronix.Areas.Admin.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public ICollection<Product> Products{ get; set; }

        public bool IsActive { get; set; } = true;

        public int MainCategoryId { get; set; }

        public MainCategory MainCategory { get; set; }
    }
}