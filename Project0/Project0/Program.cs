using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog;
using System;
using Project0.DataAccess;
using System.Linq;

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
                var p0Repo = new Project0Repo(dbContext);

                Console.WriteLine("Welcome to Luigi's Cupcakes Manager");
                Console.WriteLine();
                Console.WriteLine("Please select from the following options (not case-sensitive):");

                while (true)
                {
                    ConsoleDisplay.DisplayMenu();
                    ConsoleRead.GetMenuInput(out var input);
                    if (input == "S")
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
                    else if (input == "SL")
                    {
                        //ConsoleDisplay.StoreList(storeLocations);
                    }
                    else if (input == "SO")
                    {
                        //ConsoleRead.StoreOrders(storeLocations);
                    }
                    else if (input == "CL")
                    {
                        //ConsoleDisplay.CustomerList(customers);
                    }
                    else if (input == "CS")
                    {
                        //ConsoleRead.CustomerSearch(customers);
                    }
                    else if (input == "CO")
                    {
                        //ConsoleRead.CustomerOrders(customers);
                    }
                    else if (input == "OL")
                    {
                        //ConsoleDisplay.OrderList(orders, storeLocations);
                    }
                    else if (input == "OR")
                    {
                        //ConsoleRead.OrderRecommended(customers, orders);
                    }
                    else if (input == "Q")
                    {
                        break;
                    }
                }
            }
        }

        public static void GetDataAndAddLocation(Project0Repo p0Repo)
        {
            p0Repo.AddStoreLocation();
            int newLocationId = p0Repo.GetLastLocationAdded();
            Console.WriteLine($"Location with id of {newLocationId} successfully created!");
        }

        public static void GetDataAndAddCustomer(Project0Repo p0Repo)
        {
            string fName = ConsoleRead.GetCustomerFirstName();
            if (fName is null) { return; }
            string lName = ConsoleRead.GetCustomerLastName();
            if (lName is null) { return; }
            var locations = p0Repo.GetAllStoreLocations().ToList();
            if (locations.Count() <= 0)
            {
                Console.WriteLine("You must add at least one store before you can add a customer.");
                return;
            }
           
            int storeLocationId = ConsoleRead.GetStoreLocation(p0Repo,
                "Please enter a valid Id for default store location:");
            if (storeLocationId == -1) { return; }
            if (!p0Repo.CheckLocationExists(storeLocationId)) { return; }

            p0Repo.AddCustomer(fName, lName, storeLocationId);
            int newCustomerId = p0Repo.GetLastCustomerAdded();
            Console.WriteLine($"Location with id of {newCustomerId} successfully created!");
        }

        public static void GetDataAndAddOrder(Project0Repo p0Repo)
        {
            NLog.ILogger logger = LogManager.GetCurrentClassLogger();

            int storeLocationId = ConsoleRead.GetStoreLocation(p0Repo,
                "Please enter a valid store Id for the order:");
            if (storeLocationId == -1)
            {
                return;
            }
            if (!p0Repo.CheckLocationExists(storeLocationId))
            {
                logger.Error($"{storeLocationId} is not in the list of stores.");
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
           // Cupcake cupcakeTuple = ConsoleRead.GetCupcake(p0Repo);

            //ConsoleRead.GetCupcake();
            //if (cupcakeTuple.Item2 is null)
            //{
            //    return;
            //}
            //int orderQnty = ConsoleRead.GetCupcakeQuantity();
            //if (orderQnty == -1)
            //{
            //    return;
            //}
            //bool qntyAllowed = Cupcake.CheckCupcakeQuantity(orderQnty);
            //if (!qntyAllowed)
            //{
            //    Console.WriteLine("Maximum order quantity is 500.");
            //    return;
            //}
            //bool cupcakeAllowed = Cupcake.CheckCupcake(storeLocationId, cupcakeTuple.Item1, orders);
            //if (!cupcakeAllowed)
            //{
            //    Console.WriteLine("This store has exhausted supply of that cupcake. Try back in 24 hours.");
            //    return;
            //}
            //bool orderFeasible = Order.CheckOrderFeasible(storeLocationId, storeLocations,
            //    cupcakeTuple.Item2, orderQnty);
            //if (!orderFeasible)
            //{
            //    Console.WriteLine("This store does not have enough ingredients to place the requested order.");
            //    return;
            //}
            //bool customerCanOrder = Order.CheckCustomerCanOrder(customerId,
            //    storeLocationId, customers);
            //if (!customerCanOrder)
            //{
            //    Console.WriteLine("Customer can't place an order at this store because it hasn't been 2 hours yet.");
            //    return;
            //}

            //int newOrderId = Order.AddOrder(storeLocationId, customerId, cupcakeTuple.Item1, cupcakeTuple.Item2, orderQnty,
            //    jsonLocations, jsonCustomers, jsonOrders, customers, storeLocations, orders);
            //Console.WriteLine($"Order with id of {newOrderId} successfully created!");
        }
    }
}
    

