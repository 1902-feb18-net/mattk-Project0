using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultStore { get; set; }

        public static bool CheckCustomerCanOrder(int customerId, int storeLocationId, 
            List<Order> orders)
        {
            return orders.Any(o => ((o.OrderCustomer == customerId) && 
                                (o.OrderLocation == storeLocationId) &&
                                (o.OrderTime).Subtract(DateTime.Now).TotalMinutes < 120));
        }
    }
}
