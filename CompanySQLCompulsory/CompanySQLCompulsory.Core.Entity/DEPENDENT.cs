using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySQLCompulsory.CompanySQLCompulsory.Core.Entity
{
    public class DEPENDENT
    {
        public int Essn { get; set; }
        public string Dependent_name { get; set; }
        public bool Sex { get; set; }
        public DateTime Bdate { get; set; }
        public string Relationship { get; set; }
    }
}
