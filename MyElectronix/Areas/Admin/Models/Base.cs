using MyElectronix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models
{
    public class Base
    {
        public ApplicationDbContext db = new ApplicationDbContext();
    }
}