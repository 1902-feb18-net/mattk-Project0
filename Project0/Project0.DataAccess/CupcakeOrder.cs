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

        //public static int AddOrder(int storeLocationId,
        //                            int customerId,
        //                            CupcakeNum cupcakeType,
        //                            Cupcake lookupCupcake,
        //                            int qnty,
        //                            string jsonLocations,
        //                            string jsonCustomers,
        //                            string jsonOrders,
        //                            List<Customer> customers,
        //                            List<Location> storeLocations,
        //                            List<Order> orders)
        //{
        //    foreach (var item in storeLocations.Where(sL => sL.Id == storeLocationId))
        //    {
        //        item.UpdateInv(lookupCupcake, qnty);
        //    }

        //    int newOrderId = 1;
        //    if (orders.Count > 0) { newOrderId = orders.Max(o => o.Id) + 1; }

        //    Order newOrder = new Order
        //    {
        //        Id = newOrderId,
        //        OrderLocation = storeLocationId,
        //        OrderCustomer = customerId,
        //        OrderTime = DateTime.Now,
        //        OrderItem = (lookupCupcake, qnty, cupcakeType)
        //    };

        //    orders.Add(newOrder);
        //    string newData = JsonConvert.SerializeObject(orders, Formatting.Indented);
        //    File.WriteAllTextAsync(jsonOrders, newData).Wait();

        //    // https://stackoverflow.com/questions/19930450/conditional-updating-a-list-using-linq
        //    foreach (var item in storeLocations.Where(sL => sL.Id == storeLocationId))
        //    {
        //        item.OrderHistory.Add(newOrder);
        //    }
        //    string newData2 = JsonConvert.SerializeObject(storeLocations, Formatting.Indented);
        //    File.WriteAllTextAsync(jsonLocations, newData2).Wait();

        //    foreach (var item in customers.Where(c => c.Id == customerId))
        //    {
        //        item.OrderHistory.Add(newOrder);
        //        item.LastOrder = DateTime.Now;
        //        item.LastStoreOrder = storeLocationId;
        //    }
        //    string newData3 = JsonConvert.SerializeObject(customers, Formatting.Indented);
        //    File.WriteAllTextAsync(jsonCustomers, newData3).Wait();
        //    return newOrderId;
        //}

        //public static bool CheckOrderFeasible(int storeLocationId, List<Location> storeLocations,
        //    Cupcake lookupCupcake, int qnty)
        //{
        //    bool orderFeasible = false;
        //    // Check store inventory to make sure there are enough ingredients
        //    foreach (var item in storeLocations.Where(sL => sL.Id == storeLocationId))
        //    {
        //        orderFeasible = item.CheckInv(lookupCupcake, qnty);
        //    }
        //    return orderFeasible;
        //}

        //public static bool CheckCustomerCanOrder(int customerId, int storeLocationId, List<Customer> customers)
        //{
        //    bool customerCanOrder = true;
        //    foreach (var item in customers.Where(c => c.Id == customerId))
        //    {
        //        DateTime currentTime = DateTime.Now;
        //        if ((Math.Abs((item.LastOrder).Subtract(currentTime).TotalMinutes) < 120) &&
        //                item.LastStoreOrder == storeLocationId)
        //        {
        //            customerCanOrder = false;
        //        }
        //    }
        //    return customerCanOrder;
        //}
    }
}

   
