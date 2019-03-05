using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{
     public class Location
    {
        public int Id { get; set; }

        public static bool CheckCanOrderCupcake(int locationId, 
            Dictionary<int, int> cupcakeInputs, List<Order> orders, List<OrderItem> orderItems)
        {
            bool result = false;
            int sum = 0;
            foreach (var item in cupcakeInputs)
            {
                var ordersAtStore = orders.Where(o => o.OrderLocation == locationId);
                var ordersAtStoreRecently =
                    ordersAtStore.Where(o =>
                    Math.Abs(o.OrderTime.Subtract(DateTime.Now).TotalMinutes) < 1440);
                foreach (var order in ordersAtStoreRecently)
                {
                    var thisOrderItems = orderItems.Where(oi => oi.OrderId == order.Id);
                    foreach (var orderItem in thisOrderItems)
                    {
                        if (orderItem.CupcakeId == item.Key)
                        {
                            sum += orderItem.Quantity;
                        }
                    }
                }

                result = sum < 1000;
            }
            return result;           
        }

        public static bool CheckOrderFeasible(Dictionary<int, Dictionary<int, decimal>> recipes, 
            Dictionary<int, decimal> locationInv, Dictionary<int, int> cupcakeInputs)
        {
            Dictionary<int, decimal> inventoryCopy = new Dictionary<int, decimal>(locationInv);
            foreach (var cupcake in cupcakeInputs)
            {
                foreach (var ingredient in locationInv)
                {
                    inventoryCopy[cupcake.Key] -= recipes[cupcake.Key][ingredient.Key] * cupcake.Value;
                }
            }

            foreach (var item in inventoryCopy)
            {
                if (locationInv[item.Key] < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
