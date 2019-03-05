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
                DefaultLocation = locationId
            };
            Context.Customer.Add(newCustomer);
            Context.SaveChanges();
        }

        public void AddCupcakeOrder(int locationId, int customerId)
        {
            var newOrder = new CupcakeOrder
            {
                LocationId = locationId,
                CustomerId = customerId,
                OrderTime = DateTime.Now
            };
            Context.CupcakeOrder.Add(newOrder);
            Context.SaveChanges();
        }

        public void AddCupcakeOrderItems(int orderId, Dictionary<int, int> cupcakeInputs)
        {
            foreach (var cupcake in cupcakeInputs)
            {
                var newOrderItem = new CupcakeOrderItem
                {
                    OrderId = orderId,
                    CupcakeId = cupcake.Key,
                    Quantity = cupcake.Value
                };
                Context.CupcakeOrderItem.Add(newOrderItem);
            }
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

        public int GetDefaultLocation(int customerId)
        {
            return Context.Customer.Single(c => c.CustomerId == customerId).DefaultLocation;
        }

        public Library.Order GetCupcakeOrder(int orderId)
        {
            return Mapper.Map(Context.CupcakeOrder.Single(co => co.OrderId == orderId));
        }

        public Library.Cupcake GetCupcake(int cupcakeId)
        {
            return Mapper.Map(Context.Cupcake.Single(c => c.CupcakeId == cupcakeId));
        }

        public Dictionary<int, Dictionary<int, decimal>> GetRecipes(Dictionary<int, int> cupcakeInputs)
        {
            Dictionary<int, Dictionary<int, decimal>> recipes = new Dictionary<int, Dictionary<int, decimal>>();

            foreach (var item in cupcakeInputs)
            {
                Dictionary<int, decimal> recipe = new Dictionary<int, decimal>();
                foreach (var recipeItem in Context.RecipeItem.Where(r => r.CupcakeId == item.Key).ToList())
                {
                    recipe[recipeItem.IngredientId] = recipeItem.Amount;
                }
                recipes[item.Key] = recipe;
            }

            return recipes;
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

        public IEnumerable<Library.OrderItem> GetAllOrderItems()
        {
            return Mapper.Map(Context.CupcakeOrderItem.ToList());
        }

        public IEnumerable<Library.Order> GetLocationOrderHistory(int locationId)
        {
            return Mapper.Map(Context.CupcakeOrder.Where(co => co.LocationId == locationId).ToList());
        }

        public IEnumerable<Library.Order> GetCustomerOrderHistory(int customerId)
        {
            return Mapper.Map(Context.CupcakeOrder.Where(co => co.CustomerId == customerId).ToList());
        }

        public IEnumerable<Library.OrderItem> GetOrderItems(int orderId)
        {
            return Mapper.Map(Context.CupcakeOrderItem.Where(coi => coi.OrderId == orderId));
        }

        public IEnumerable<Library.OrderItem> GetCustomerOrderItems(int customerId)
        {
            var customerOrders = Context.CupcakeOrder.Where(co => co.CustomerId == customerId)
                .Select(co => co.OrderId)
                .ToList();
            return Mapper.Map(Context.CupcakeOrderItem.Where(coi => customerOrders.Contains(coi.OrderId)));
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

        public bool CheckOrderExists(int orderId)
        {
            return Context.CupcakeOrder.Any(l => l.OrderId == orderId);
        }

        public void UpdateLocationInv(int locationId, Dictionary<int, Dictionary<int, decimal>> recipes,
            Dictionary<int, int> cupcakeInputs)
        {
            foreach (var locationInv in Context.LocationInventory.Where(li => li.LocationId == locationId))
            {
                foreach (var cupcake in cupcakeInputs)
                {
                    locationInv.Amount -= recipes[cupcake.Key][locationInv.IngredientId] * cupcake.Value;
                }
            }
            Context.SaveChanges();
        }

    }
}
