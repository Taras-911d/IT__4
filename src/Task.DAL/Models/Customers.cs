using System;
using System.Collections.Generic;

namespace Task_3_Core
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime? DateInSystem { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
