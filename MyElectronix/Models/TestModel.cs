using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElectronix.Models
{
    public class TestModel
    {
        public int TestModelId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SubTest> subTests { get; set; }
    }
}