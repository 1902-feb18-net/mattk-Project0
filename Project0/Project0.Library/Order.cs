using System;

namespace Project0.Library
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderLocation { get; set; }
        public int OrderCustomer { get; set; }
        public int OrderCupcake { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime OrderTime { get; set; }

        public static bool CheckCupcakeQuantity(int qnty)
        {
            return qnty <= 500 && qnty >= 0;
        }
    }
}
