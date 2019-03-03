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
                locationInv.Amount = 120;
                Context.LocationInventory.Add(locationInv);
            }
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

        public void AddCupcakeOrder(int storeLocationId, int customerId, int cupcakeId, int qnty)
        {
            var newOrder = new CupcakeOrder
            {
                LocationId = storeLocationId,
                CustomerId = customerId,
                CupcakeId = cupcakeId,
                Quantity = qnty,
                OrderTime = DateTime.Now
            };
            Context.CupcakeOrder.Add(newOrder);
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

        public int GetLastCupcakeOrderAdded()
        {
            var newCupcakeOrder = Context.CupcakeOrder
                .OrderByDescending(x => x.OrderId)
                .First();
            return newCupcakeOrder.OrderId;
        }

        public Dictionary<int, decimal> GetRecipe(int cupcakeId)
        {
            var recipeLookup = Context.RecipeItem.Where(r => r.CupcakeId == cupcakeId).ToList();
            Dictionary<int, decimal> recipe = new Dictionary<int, decimal>();
            foreach (var item in recipeLookup)
            {
                recipe[item.IngredientId] = item.Amount;
            }
            return recipe;
        }

        public Dictionary<int, decimal> GetLocationInv(int storeLocationId)
        {
            var locationInvLookup = Context.LocationInventory.Where(li => li.LocationId == storeLocationId);
            Dictionary<int, decimal> locationInv = new Dictionary<int, decimal>();
            foreach (var item in locationInvLookup)
            {
                locationInv[item.IngredientId] = item.Amount;
            }
            return locationInv;
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

        public IEnumerable<Library.Order> GetAllOrders()
        {
            IEnumerable<DataAccess.CupcakeOrder> orders = Context.CupcakeOrder.ToList();
            return Mapper.Map(orders);
        }

        public IEnumerable<Library.Order> GetLocationOrderHistory(int storeLocationId)
        {
            IEnumerable<DataAccess.CupcakeOrder> locationOrderHistory = 
                    Context.CupcakeOrder.Where(co => co.LocationId == storeLocationId).ToList();
            return Mapper.Map(locationOrderHistory);
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

        public void UpdateLocationInv(int storeLocationId, Dictionary<int, decimal> recipe, int qnty)
        {
            foreach (var locationInv in Context.LocationInventory.Where(li => li.LocationId == storeLocationId))
            {
                locationInv.Amount -= recipe[locationInv.IngredientId] * qnty;
            }
            Context.SaveChanges();
        }

    }
}
