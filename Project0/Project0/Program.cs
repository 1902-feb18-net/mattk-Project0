using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog;
using System;
using Project0.DataAccess;
using System.Linq;
using System.Collections.Generic;

namespace Project0
{
    public class Program
    {

        // Scaffold-DbContext "<your-connection-string>" 
        //      Microsoft.EntityFrameworkCore.SqlServer
        //      -Project <name-of-data-project>

        //public static readonly LoggerFactory AppLoggerFactory
        //    = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        static void Main(string[] args)
        {
            NLog.ILogger logger = LogManager.GetCurrentClassLogger();

            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            //optionsBuilder.UseLoggerFactory(AppLoggerFactory);
            var options = optionsBuilder.Options;

            using (var dbContext = new Project0Context(options))
            {
                IProject0Repo p0Repo = new Project0Repo(dbContext);

                Console.WriteLine("Welcome to Matt's Cupcakes Manager");
                Console.WriteLine();
                Console.WriteLine("Please select from the following options (not case-sensitive):");

                while (true)
                {
                    ConsoleDisplay.DisplayMenu();
                    ConsoleRead.GetMenuInput(out var input);
                    if (input == "L")
                    {
                        GetDataAndAddLocation(p0Repo);
                    }
                    else if (input == "C")
                    {
                        GetDataAndAddCustomer(p0Repo);
                    }
                    else if (input == "O")
                    {
                        GetDataAndAddOrder(p0Repo);
                    }
                    else if (input == "LL")
                    {
                        ConsoleDisplay.LocationList(p0Repo);
                    }
                    else if (input == "LO")
                    {
                        ConsoleRead.LocationOrders(p0Repo);
                    }
                    else if (input == "CL")
                    {
                        ConsoleDisplay.CustomerList(p0Repo);
                    }
                    else if (input == "CS")
                    {
                        ConsoleRead.CustomerSearch(p0Repo);
                    }
                    else if (input == "CO")
                    {
                        ConsoleRead.CustomerOrders(p0Repo);
                    }
                    else if (input == "OD")
                    {
                        ConsoleRead.OrderDetails(p0Repo);
                    }
                    else if (input == "OL")
                    {
                        ConsoleDisplay.OrderList(p0Repo, p0Repo.GetAllOrders().ToList(),
                            p0Repo.GetAllOrderItems().ToList(),
                            p0Repo.GetAllCupcakes().ToList(), p0Repo.GetAllLocations().ToList());
                    }
                    else if (input == "OR")
                    {
                        ConsoleRead.OrderRecommended(p0Repo);
                    }
                    else if (input == "Q")
                    {
                        break;
                    }
                }
            }
        }

        public static void GetDataAndAddLocation(IProject0Repo p0Repo)
        {
            p0Repo.AddLocation();
            int newLocationId = p0Repo.GetLastLocationAdded();
            p0Repo.FillLocationInventory(newLocationId);
            Console.WriteLine($"Location with Id of {newLocationId} successfully created!");
        }

        public static void GetDataAndAddCustomer(IProject0Repo p0Repo)
        {
            var locations = p0Repo.GetAllLocations().ToList();
            if (locations.Count <= 0)
            {
                Console.WriteLine("You must add at least one store location before you can add a customer.");
                return;
            }

            string fName = ConsoleRead.GetCustomerFirstName();
            if (fName is null) { return; }
            string lName = ConsoleRead.GetCustomerLastName();
            if (lName is null) { return; }
            Console.WriteLine();
           
            int locationId = ConsoleRead.GetLocation(p0Repo,
                "Please enter a valid Id for default store location:", -1);
            if (locationId == -1) { return; }
            if (!p0Repo.CheckLocationExists(locationId))
            {
                Console.WriteLine("The store location that you entered is not in the system.");
                return;
            }

            p0Repo.AddCustomer(fName, lName, locationId);
            int newCustomerId = p0Repo.GetLastCustomerAdded();
            Console.WriteLine($"Customer with Id of {newCustomerId} successfully created!");
        }

        public static void GetDataAndAddOrder(IProject0Repo p0Repo)
        {
            NLog.ILogger logger = LogManager.GetCurrentClassLogger();

            List<Library.Customer> customers = p0Repo.GetAllCustomers().ToList();
            if (customers.Count == 0)
            {
                Console.WriteLine("You have to add at least one customer before you can add an order.");
                return;
            }
            int customerId = ConsoleRead.GetCustomer(p0Repo);
            if (customerId == -1)
            {
                return;
            }
            if (!p0Repo.CheckCustomerExists(customerId))
            {
                logger.Error($"{customerId} is not in the list of customers.");
                return;
            }
            int locationId = ConsoleRead.GetLocation(p0Repo,
                "Please enter a valid store Id for the order or 'd' for customer default:", customerId);
            if (locationId == -1)
            {
                return;
            }
            if (!p0Repo.CheckLocationExists(locationId))
            {
                logger.Error($"{locationId} is not in the list of stores.");
                return;
            }
            Dictionary<int, int> cupcakeInputs = ConsoleRead.GetCupcakes(p0Repo);
            if (cupcakeInputs.Count == 0)
            {
                return;
            }
            bool cupcakeFound = false;
            foreach (var item in cupcakeInputs)
            {
                if (item.Value > 0)
                {
                    cupcakeFound = true;
                    break;
                }
            }
            if (!cupcakeFound)
            {
                Console.WriteLine("You must enter at least one cupcake to place an order.");
                return;
            }
            var orders = p0Repo.GetAllOrders().ToList();
            var orderItems = p0Repo.GetAllOrderItems().ToList();
            if (!Library.Location.CheckCanOrderCupcake(locationId, cupcakeInputs, orders, orderItems))
            {
                Console.WriteLine("This store has exhausted supply of that cupcake. Try back in 24 hours.");
                return;
            }
            var recipes = p0Repo.GetRecipes(cupcakeInputs);
            var locationInv = p0Repo.GetLocationInv(locationId);
            if (!Library.Location.CheckOrderFeasible(recipes, locationInv, cupcakeInputs))
            {
                Console.WriteLine("This store does not have enough ingredients to place the requested order.");
                return;
            }
            if (Library.Customer.CheckCustomerCannotOrder(customerId, locationId, orders))
            {
                Console.WriteLine("Customer can't place an order at this store because it hasn't been 2 hours \n" +
                    "since there last order yet.");
                return;
            }

            p0Repo.AddCupcakeOrder(locationId, customerId);
            int newOrderId = p0Repo.GetLastCupcakeOrderAdded();
            p0Repo.AddCupcakeOrderItems(newOrderId, cupcakeInputs);
            p0Repo.UpdateLocationInv(locationId, recipes, cupcakeInputs);
            Console.WriteLine($"Order with Id of {newOrderId} successfully created!");
        }
    }
}
    

