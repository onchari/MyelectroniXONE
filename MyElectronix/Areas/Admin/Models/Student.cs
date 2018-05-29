using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElectronix.Areas.Admin.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int TestClassId { get; set; }

        public TestClass TestClass { get; set; }
    }
}