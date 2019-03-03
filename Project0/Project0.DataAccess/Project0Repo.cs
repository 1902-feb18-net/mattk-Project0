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

        public void FillLocationInventory(int storeLocationId)
        {
            var ingredients = Context.Ingredient.ToList();
            var recipeItems = Context.RecipeItem.ToList();
            foreach (var item in ingredients)
            {
                var locationInv = new LocationInventory();
                locationInv.IngredientId = item.IngredientId;
                locationInv.LocationId = storeLocationId;
                locationInv.Amount = 500;
                //locationInv.Units = 

            }


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

        public IEnumerable<Library.Cupcake> GetAllCupcakes()
        {
            IEnumerable<DataAccess.Cupcake> cupcakes = Context.Cupcake.ToList();
            return Mapper.Map(cupcakes);
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

        public bool CheckCupcakeExists(int cupcakeId)
        {
            if (Context.Cupcake.Any(l => l.CupcakeId == cupcakeId))
            {
                return true;
            }
            return false;
        }
    }
}
