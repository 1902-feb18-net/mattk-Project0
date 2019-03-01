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
    }
}
