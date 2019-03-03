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
            return qnty <= 500;
        }

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
