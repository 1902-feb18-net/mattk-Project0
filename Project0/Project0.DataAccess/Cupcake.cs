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
    }
}
