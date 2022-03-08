using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySQLCompulsory.CompanySQLCompulsory.Core.Entity
{
    public class DEPARTMENT
    {
        public int Dnumber { get; set; }
        public string Dname { get; set; }
        public int Mgr_ssn { get; set; }
        public DateTime Mgr_start_date { get; set; }
        public string Dlocation { get; set; }
    }
}
