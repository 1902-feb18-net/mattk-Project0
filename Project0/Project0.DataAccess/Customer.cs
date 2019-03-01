using System;
using System.Collections.Generic;

namespace Project0.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            CupcakeOrder = new HashSet<CupcakeOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultStore { get; set; }

        public virtual Location DefaultStoreNavigation { get; set; }
        public virtual ICollection<CupcakeOrder> CupcakeOrder { get; set; }
    }
}
