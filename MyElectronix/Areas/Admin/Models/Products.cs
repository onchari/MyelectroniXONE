using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models
{
    public class Products
    {
        [Key]
        public int ProductsId { get; set; }

        public string ProductsName { get; set; }

        public string ProductsDescription { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}