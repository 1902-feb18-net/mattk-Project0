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

        public static bool CheckCustomerCannotOrder(int customerId, int storeLocationId, 
            List<Order> orders)
        {
            return orders.Where(o => o.OrderCustomer == customerId)
                        .Where(o => o.OrderLocation == storeLocationId)
                        .Any(o => DateTime.Now.Subtract(o.OrderTime).TotalMinutes < 120);
        }
    }
}
