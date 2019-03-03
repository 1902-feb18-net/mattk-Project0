using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{
     public class Location
    {
        public int Id { get; set; }

        public static bool CheckCanOrderCupcake(int locationId, int cupcakeId, List<Order> orders)
        {
            var ordersAtStore = orders.Where(o => o.OrderLocation == locationId);
            var ordersAtStoreRecently =
                ordersAtStore.Where(o =>
                Math.Abs(o.OrderTime.Subtract(DateTime.Now).TotalMinutes) < 1440);
            var ordersAtStoreRecentlyWithCupcake =
                ordersAtStoreRecently.Where(o => o.OrderCupcake == cupcakeId);
            int sum = ordersAtStoreRecentlyWithCupcake.Sum(o => o.OrderQuantity);

            return sum < 1000;
        }

        public static bool CheckOrderFeasible(Dictionary<int, decimal> recipe, 
            Dictionary<int, decimal> locationInv, int qnty)
        {
            foreach (var item in locationInv)
            {
                if (locationInv[item.Key] < recipe[item.Key] * qnty)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
