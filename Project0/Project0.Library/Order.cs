using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.Library
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderLocation { get; set; }
        public int OrderCustomer { get; set; }
        public DateTime OrderTime { get; set; }

        public static bool CheckCupcakeQuantity(int qnty)
        {
            return qnty <= 500 && qnty > 0;
        }

        public decimal GetTotalCost(List<Library.OrderItem> orderItems, List<Library.Cupcake> cupcakes)
        {
            decimal sum = 0;
            foreach (var orderItem in orderItems)
            {
                sum += orderItem.Quantity * cupcakes.Single(c => c.Id == orderItem.CupcakeId).Cost;
            }
            return sum;
        }
    }
}
