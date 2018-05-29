using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models
{
    public class TestClass
    {
        public int TestClassId { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}