using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        [Display(Name ="Category Name")]
        [Required]
        [StringLength(30, ErrorMessage ="This Length should not be more than 30 characters.")]
        public string CategoryName { get; set; }

        public int CategoryIconId { get; set; }

        public byte[] CategoryIconData { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }

        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }
    }
}
