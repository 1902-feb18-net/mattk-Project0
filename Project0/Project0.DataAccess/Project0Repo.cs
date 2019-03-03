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

        public void AddLocation()
        {
            Context.Location.Add(new Location());
            Context.SaveChanges();
        }

        public void FillLocationInventory(int locationId)
        {
            foreach (var item in Context.Ingredient.ToList())
            {
                var locationInv = new LocationInventory();
                locationInv.IngredientId = item.IngredientId;
                locationInv.LocationId = locationId;
                locationInv.Amount = 120;
                Context.LocationInventory.Add(locationInv);
            }
            Context.SaveChanges();
        }

        public void AddCustomer(string fName, string lName, int locationId)
        {
            var newCustomer = new Customer
            {
                FirstName = fName,
                LastName = lName,
                DefaultStore = locationId
            };
            Context.Customer.Add(newCustomer);
            Context.SaveChanges();
        }

        public void AddCupcakeOrder(int locationId, int customerId, int cupcakeId, int qnty)
        {
            var newOrder = new CupcakeOrder
            {
                LocationId = locationId,
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
            return Context.Location
                .OrderByDescending(x => x.LocationId)
                .First().LocationId;
        }

        public int GetLastCustomerAdded()
        {
            return Context.Customer
                .OrderByDescending(x => x.CustomerId)
                .First().CustomerId;
        }

        public int GetLastCupcakeOrderAdded()
        {
            return Context.CupcakeOrder
                .OrderByDescending(x => x.OrderId)
                .First().OrderId;
        }

        public Dictionary<int, decimal> GetRecipe(int cupcakeId)
        {
            Dictionary<int, decimal> recipe = new Dictionary<int, decimal>();
            foreach (var item in Context.RecipeItem.Where(r => r.CupcakeId == cupcakeId).ToList())
            {
                recipe[item.IngredientId] = item.Amount;
            }
            return recipe;
        }

        public Dictionary<int, decimal> GetLocationInv(int locationId)
        {
            Dictionary<int, decimal> locationInv = new Dictionary<int, decimal>();
            foreach (var item in Context.LocationInventory.Where(li => li.LocationId == locationId))
            {
                locationInv[item.IngredientId] = item.Amount;
            }
            return locationInv;
        }


        public IEnumerable<Library.Location> GetAllLocations()
        {
            return Mapper.Map(Context.Location.ToList());
        }

        public IEnumerable<Library.Customer> GetAllCustomers()
        {
            return Mapper.Map(Context.Customer.ToList());
        }

        public IEnumerable<Library.Cupcake> GetAllCupcakes()
        {
            return Mapper.Map(Context.Cupcake.ToList());
        }

        public IEnumerable<Library.Order> GetAllOrders()
        {
            return Mapper.Map(Context.CupcakeOrder.ToList());
        }

        public IEnumerable<Library.Order> GetLocationOrderHistory(int locationId)
        {
            return Mapper.Map(Context.CupcakeOrder.Where(co => co.LocationId == locationId).ToList());
        }

        public IEnumerable<Library.Order> GetCustomerOrderHistory(int customerId)
        {
            return Mapper.Map(Context.CupcakeOrder.Where(co => co.CustomerId == customerId).ToList());
        }

        public bool CheckLocationExists(int locationId)
        {
            return Context.Location.Any(l => l.LocationId == locationId);
        }

        public bool CheckCustomerExists(int customerId)
        {
            return Context.Customer.Any(l => l.CustomerId == customerId);
        }

        public bool CheckCupcakeExists(int cupcakeId)
        {
            return Context.Cupcake.Any(l => l.CupcakeId == cupcakeId);
        }

        public void UpdateLocationInv(int locationId, Dictionary<int, decimal> recipe, int qnty)
        {
            foreach (var locationInv in Context.LocationInventory.Where(li => li.LocationId == locationId))
            {
                locationInv.Amount -= recipe[locationInv.IngredientId] * qnty;
            }
            Context.SaveChanges();
        }

    }
}
