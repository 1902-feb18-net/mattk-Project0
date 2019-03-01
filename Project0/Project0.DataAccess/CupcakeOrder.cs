using System;
using System.Collections.Generic;

namespace Project0.DataAccess
{
    public partial class CupcakeOrder
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int CupcakeId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Cupcake Cupcake { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
    }
}
