using System;
using System.Collections.Generic;

namespace Task_3_Core
{
    public partial class Medicaments
    {
        public Medicaments()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
