using System;
using System.Collections.Generic;

namespace Task_3_Core
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int LineItem { get; set; }
        public int MedicamentId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Medicaments Medicament { get; set; }
        public virtual Orders Order { get; set; }
    }
}
