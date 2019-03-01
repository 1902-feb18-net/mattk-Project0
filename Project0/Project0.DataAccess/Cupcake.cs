using System;
using System.Collections.Generic;

namespace Project0.DataAccess
{
    public partial class Cupcake
    {
        public Cupcake()
        {
            CupcakeOrder = new HashSet<CupcakeOrder>();
            RecipeItem = new HashSet<RecipeItem>();
        }

        public int CupcakeId { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<CupcakeOrder> CupcakeOrder { get; set; }
        public virtual ICollection<RecipeItem> RecipeItem { get; set; }

        //public static bool CheckCupcakeQuantity(int qnty)
        //{
        //    if (qnty <= 500) // no more than 500 cupcakes per order
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckCupcake(int storeLocationId, CupcakeNum cupcakeType, List<Order> orders)
        //{
        //    var ordersAtStore = orders.Where(o => o.OrderLocation == storeLocationId);
        //    var ordersAtStoreRecently =
        //        ordersAtStore.Where(o =>
        //        Math.Abs(o.OrderTime.Subtract(DateTime.Now).TotalMinutes) < 1440);
        //    var ordersAtStoreRecentlyWithCupcake =
        //        ordersAtStoreRecently.Where(o => o.OrderItem.Item3 == cupcakeType);
        //    int sum = ordersAtStoreRecentlyWithCupcake.Sum(o => o.OrderItem.Item2);

        //    if (sum < 1000)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}

    
