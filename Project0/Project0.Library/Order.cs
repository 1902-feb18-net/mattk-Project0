using System;

namespace Project0.Library
{
    public class Order
    {

        public int Id { get; set; }
        public int OrderLocation { get; set; }
        public int OrderCustomer { get; set; }
        public DateTime OrderTime { get; set; }
        //public (Cupcake, int, CupcakeNum) OrderItem { get; set; } // tuple is (Cupcake, qnty, type)

    }
}
