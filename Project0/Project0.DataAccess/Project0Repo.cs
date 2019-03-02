using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.DataAccess
{
    public class Project0Repo : IProject0Repo
    {
        public static Project0Context Context { get; set; }

        public Project0Repo(Project0Context dbContext)
        {
            Context = dbContext;
        }

        public void AddStoreLocation()
        {
            var newLocation = new Location();
            Context.Location.Add(newLocation);
            Context.SaveChanges();
        }

        public void AddCustomer(string fName, string lName, int storeLocationId)
        {
            var newCustomer = new Customer
            {
                FirstName = fName,
                LastName = lName,
                DefaultStore = storeLocationId
            };
            Context.Customer.Add(newCustomer);
            Context.SaveChanges();
        }

        public int GetLastLocationAdded()
        {
            var newLocation = Context.Location
                .OrderByDescending(x => x.LocationId)
                .First();
            return newLocation.LocationId;
        }

        public int GetLastCustomerAdded()
        {
            var newCustomer = Context.Customer
                .OrderByDescending(x => x.CustomerId)
                .First();
            return newCustomer.CustomerId;
        }

        public IEnumerable<Library.Location> GetAllStoreLocations()
        {
            IEnumerable<DataAccess.Location> locations = Context.Location.ToList();
            return Mapper.Map(locations);
        }

        public IEnumerable<Library.Customer> GetAllCustomers()
        {
            IEnumerable<DataAccess.Customer> customers = Context.Customer.ToList();
            return Mapper.Map(customers);
        }

        public bool CheckLocationExists(int storeLocationId)
        {
            if (Context.Location.Any(l => l.LocationId == storeLocationId))
            {
                return true;
            }
            return false;            
        }

        public bool CheckCustomerExists(int customerId)
        {
            if (Context.Customer.Any(l => l.CustomerId == customerId))
            {
                return true;
            }
            return false;
        }
    }
}
