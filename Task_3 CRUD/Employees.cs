using System;
using System.Collections.Generic;

namespace Task_3_Core
{
    public partial class Employees
    {
        public Employees()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Post { get; set; }
        public decimal Salary { get; set; }
        public decimal? PriorSalary { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
