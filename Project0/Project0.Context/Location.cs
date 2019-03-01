using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Location
    {
        public int Id { get; set; }
        public double[] StoreInv { get; set; } = new double[18];
        public List<Order> OrderHistory { get; set; } = new List<Order>();

        //public Location()
        //{
        //    SetInv();
        //}

        //public static int AddStoreLocation(string jsonLocations, List<Location> storeLocations)
        //{
        //    int newLocationId = 1;
        //    if (storeLocations.Count > 0) { newLocationId = storeLocations.Max(sL => sL.Id) + 1; }

        //    storeLocations.Add(new Location { Id = newLocationId });
        //    string newData = JsonConvert.SerializeObject(storeLocations, Formatting.Indented);
        //    File.WriteAllTextAsync(jsonLocations, newData).Wait();
        //    return newLocationId;
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

        //public static bool CheckForStores(List<Location> storeLocations)
        //{
        //    if (storeLocations.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckStoreExists(int storeLocationId, List<Location> storeLocations)
        //{
        //    if (storeLocations.Any(sL => sL.Id == storeLocationId))
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
