using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySQLCompulsory.CompanySQLCompulsory.Core.Entity
{
    public class EMPLOYEE
    {
        public int Ssn { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public DateTime Bdate { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; } //huehuehue
        public int Salary { get; set; }
        public int Super_ssn { get; set; }
        public int Dno { get; set; }
    }
}
