using NLog;
using System;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            //    string jsonLocations = @"C:\revature\luigi_cupcakes_locations.json";
            //    string jsonCustomers = @"C:\revature\luigi_cupcakes_customers.json";
            //    string jsonOrders = @"C:\revature\luigi_cupcakes_orders.json";
            //    LoadDataFromJSON(jsonLocations,
            //                    jsonCustomers,
            //                    jsonOrders,
            //                    out var storeLocations,
            //                    out var customers,
            //                    out var orders);

            Console.WriteLine("Welcome to Luigi's Cupcakes Manager");
            Console.WriteLine();
            Console.WriteLine("Please select from the following options (not case-sensitive):");

            //    while (true)
            //    {
            //        ConsoleDisplay.DisplayMenu();
            //        ConsoleRead.GetMenuInput(out var input);
            //        if (input == "S")
            //        {
            //            GetDataAndAddLocation(jsonLocations, storeLocations);
            //        }
            //        else if (input == "C")
            //        {
            //            GetDataAndAddCustomer(jsonCustomers, customers, storeLocations);
            //        }
            //        else if (input == "O")
            //        {
            //            GetDataAndAddOrder(jsonLocations, jsonCustomers, jsonOrders,
            //                customers, storeLocations, orders);
            //        }
            //        else if (input == "SL")
            //        {
            //            ConsoleDisplay.StoreList(storeLocations);
            //        }
            //        else if (input == "SO")
            //        {
            //            ConsoleRead.StoreOrders(storeLocations);
            //        }
            //        else if (input == "CL")
            //        {
            //            ConsoleDisplay.CustomerList(customers);
            //        }
            //        else if (input == "CS")
            //        {
            //            ConsoleRead.CustomerSearch(customers);
            //        }
            //        else if (input == "CO")
            //        {
            //            ConsoleRead.CustomerOrders(customers);
            //        }
            //        else if (input == "OL")
            //        {
            //            ConsoleDisplay.OrderList(orders, storeLocations);
            //        }
            //        else if (input == "OR")
            //        {
            //            ConsoleRead.OrderRecommended(customers, orders);
            //        }
            //        else if (input == "Q")
            //        {
            //            break;
            //        }
            //    }
            //}

            //public static void LoadDataFromJSON(string jsonLocations,
            //                                    string jsonCustomers,
            //                                    string jsonOrders,
            //                                    out List<Location> storeLocations,
            //                                    out List<Customer> customers,
            //                                    out List<Order> orders)
            //{
            //    storeLocations = new List<Location>();
            //    if (File.Exists(jsonLocations))
            //    {
            //        string dataLocations = File.ReadAllTextAsync(jsonLocations).Result;
            //        storeLocations = JsonConvert.DeserializeObject<List<Location>>(dataLocations);
            //    }

            //    customers = new List<Customer>();
            //    if (File.Exists(jsonCustomers))
            //    {
            //        string dataCustomers = File.ReadAllTextAsync(jsonCustomers).Result;
            //        customers = JsonConvert.DeserializeObject<List<Customer>>(dataCustomers);
            //    }

            //    orders = new List<Order>();
            //    if (File.Exists(jsonOrders))
            //    {
            //        string dataOrders = File.ReadAllTextAsync(jsonOrders).Result;
            //        orders = JsonConvert.DeserializeObject<List<Order>>(dataOrders);
            //    }
            //}

            //public static void GetDataAndAddLocation(string jsonLocations, List<Location> storeLocations)
            //{
            //    int newLocationId = Location.AddStoreLocation(jsonLocations, storeLocations);
            //    Console.WriteLine($"Location with id of {newLocationId} successfully created!");
            //}

            //public static void GetDataAndAddCustomer(string jsonCustomers, List<Customer> customers,
            //    List<Location> storeLocations)
            //{
            //    string fName = ConsoleRead.GetCustomerFirstName();
            //    if (fName is null) { return; }
            //    string lName = ConsoleRead.GetCustomerLastName();
            //    if (lName is null) { return; }
            //    bool isStores = Location.CheckForStores(storeLocations);
            //    if (!isStores)
            //    {
            //        Console.WriteLine("You must add at least one store before you can add a customer.");
            //        return;
            //    }
            //    int storeLocationId = ConsoleRead.GetStoreLocation(storeLocations,
            //        "Please enter a valid Id for default store location:");
            //    if (storeLocationId == -1) { return; }
            //    bool storeExists = Location.CheckStoreExists(storeLocationId, storeLocations);
            //    if (!storeExists) { return; }

            //    int newCustomerId = Customer.AddCustomer(jsonCustomers, customers, storeLocations,
            //        fName, lName, storeLocationId);
            //    Console.WriteLine($"Location with id of {newCustomerId} successfully created!");
            //}

            //public static void GetDataAndAddOrder(string jsonLocations,
            //                                        string jsonCustomers,
            //                                        string jsonOrders,
            //                                        List<Customer> customers,
            //                                        List<Location> storeLocations,
            //                                        List<Order> orders)
            //{
            //    ILogger logger = LogManager.GetCurrentClassLogger();

            //    int storeLocationId = ConsoleRead.GetStoreLocation(storeLocations,
            //        "Please enter a valid store Id for the order:");
            //    if (storeLocationId == -1)
            //    {
            //        return;
            //    }
            //    bool storeExists = Location.CheckStoreExists(storeLocationId, storeLocations);
            //    if (!storeExists)
            //    {
            //        logger.Error($"{storeLocationId} is not in the list of stores.");
            //        return;
            //    }
            //    int customerId = ConsoleRead.GetCustomer(customers);
            //    if (customerId == -1)
            //    {
            //        return;
            //    }
            //    bool customerExists = Customer.CheckCustomerExists(customerId, customers);
            //    if (!customerExists)
            //    {
            //        logger.Error($"{customerId} is not in the list of customers.");
            //        return;
            //    }
            //    Cupcake cupcakeTuple = ConsoleRead.GetCupcake();
            //    if (cupcakeTuple.Item2 is null)
            //    {
            //        return;
            //    }
            //    int orderQnty = ConsoleRead.GetCupcakeQuantity();
            //    if (orderQnty == -1)
            //    {
            //        return;
            //    }
            //    bool qntyAllowed = Cupcake.CheckCupcakeQuantity(orderQnty);
            //    if (!qntyAllowed)
            //    {
            //        Console.WriteLine("Maximum order quantity is 500.");
            //        return;
            //    }
            //    bool cupcakeAllowed = Cupcake.CheckCupcake(storeLocationId, cupcakeTuple.Item1, orders);
            //    if (!cupcakeAllowed)
            //    {
            //        Console.WriteLine("This store has exhausted supply of that cupcake. Try back in 24 hours.");
            //        return;
            //    }
            //    bool orderFeasible = Order.CheckOrderFeasible(storeLocationId, storeLocations,
            //        cupcakeTuple.Item2, orderQnty);
            //    if (!orderFeasible)
            //    {
            //        Console.WriteLine("This store does not have enough ingredients to place the requested order.");
            //        return;
            //    }
            //    bool customerCanOrder = Order.CheckCustomerCanOrder(customerId,
            //        storeLocationId, customers);
            //    if (!customerCanOrder)
            //    {
            //        Console.WriteLine("Customer can't place an order at this store because it hasn't been 2 hours yet.");
            //        return;
            //    }

            //    int newOrderId = Order.AddOrder(storeLocationId, customerId, cupcakeTuple.Item1, cupcakeTuple.Item2, orderQnty,
            //        jsonLocations, jsonCustomers, jsonOrders, customers, storeLocations, orders);
            //    Console.WriteLine($"Order with id of {newOrderId} successfully created!");
            //}


        }
    }
}
