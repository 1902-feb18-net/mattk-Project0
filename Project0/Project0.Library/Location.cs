using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
     public class Location
    {
        public int Id { get; set; }

        //public Location()
        //{
        //    SetInv();
        //}

        //public void SetInv()
        //{
        //    StoreInv[0] = 500; // Flour, lbs
        //    StoreInv[1] = 500; // BakingPowder, lbs
        //    StoreInv[2] = 500; // Salt, lbs
        //    StoreInv[3] = 500; // UnsaltedButter, lbs
        //    StoreInv[4] = 500; // GranulatedSugar, lbs
        //    StoreInv[5] = 500; // LargeEgg, each or individual units
        //    StoreInv[6] = 500; // VanillaExtract, gallons
        //    StoreInv[7] = 500; // SourCream, lbs
        //    StoreInv[8] = 500; // ConfectionerSugar, lbs
        //    StoreInv[9] = 500; // HeavyCream, lbs
        //    StoreInv[10] = 500; // CocoaPowder, lbs
        //    StoreInv[11] = 500; // Raspberry, each or individual units
        //    StoreInv[12] = 500; // PeanutButter, lbs
        //    StoreInv[13] = 500; // Peppermint, each or individual units
        //    StoreInv[14] = 500; // Oreo, lbs
        //    StoreInv[15] = 500; // CoconutMilk, gallons
        //    StoreInv[16] = 500; // Lemon, each or individual units
        //    StoreInv[17] = 500; // Amaretto, lbs
        //}

        //public bool CheckInv(Cupcake lookupCupcake, int qnty)
        //{
        //    double[] cupcakeRequirements = lookupCupcake.GetIngredients();

        //    int i = 0;
        //    foreach (var item in StoreInv)
        //    {
        //        if (StoreInv[i] < (double)(cupcakeRequirements[i] * qnty))
        //        {
        //            return false;
        //        }
        //        i++;
        //    }
        //    return true;
        //}

        //public void UpdateInv(Cupcake lookupCupcake, int qnty)
        //{
        //    double[] cupcakeRequirements = lookupCupcake.GetIngredients();

        //    int i = 0;
        //    foreach (var item in StoreInv)
        //    {
        //        StoreInv[i] -= (double)(cupcakeRequirements[i] * qnty);
        //        i++;
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
