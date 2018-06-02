using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models
{
    public class MainCategory
    {
        public int MainCategoryId { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string MainCategoryName { get; set; }

        public string MainCategoryDescription { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}