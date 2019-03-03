using NLog;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0
{
    public static class ConsoleRead
    {
        public static void GetMenuInput(out string input)
        {
            input = Console.ReadLine().ToUpper();
        }

        public static void LocationOrders(Project0Repo p0Repo)
        {
            int storeLocationId = GetStoreLocation(p0Repo,
                "Please enter the store id to get that store's orders:");
            if (storeLocationId == -1)
            {
                return;
            }

            var cupcakes = p0Repo.GetAllCupcakes().ToList();
            var locationOrderHistory = p0Repo.GetLocationOrderHistory(storeLocationId).ToList();
            Console.WriteLine($"Store Location {storeLocationId}");
            ConsoleDisplay.OrderList(p0Repo, locationOrderHistory, cupcakes, null);
        }

        public static void CustomerSearch(Project0Repo p0Repo)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            string fName = GetCustomerFirstName();
            if (fName is null) { return; }

            List<Library.Customer> customers = p0Repo.GetAllCustomers().ToList();

            var numPossibleMatches = customers.Count(c => c.FirstName == fName);
            if (numPossibleMatches > 0)
            {
                Console.WriteLine($"Found {numPossibleMatches} with that first name.");
                var possibleMatches = customers.Where(c => c.FirstName == fName);
                List<Library.Customer> customerList = new List<Library.Customer>();
                foreach (var item in possibleMatches)
                {
                    customerList.Add(item);
                }

                string lName = GetCustomerLastName();
                if (lName is null) { return; }

                numPossibleMatches = customerList.Count(c => c.LastName == lName);
                if (numPossibleMatches > 0)
                {
                    possibleMatches = customerList.Where(c => c.LastName == lName);
                    Console.WriteLine("List of customer's with that first name and last name:");
                    foreach (var item in possibleMatches)
                    {
                        Console.WriteLine($"Customer Id: {item.Id}, First Name: {item.FirstName}, " +
                        $"Last Name, {item.LastName}, Default Store Id: {item.DefaultStore}");
                    }
                }
                else
                {
                    Console.WriteLine("There is no one in the system with that first name and last name.");
                }
            }
            else
            {
                Console.WriteLine("There is no one in the system with that first name.");
            }
        }

        public static void CustomerOrders(Project0Repo p0Repo)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            var customers = p0Repo.GetAllCustomers().ToList();

            ConsoleDisplay.CustomerList(p0Repo);
            Console.WriteLine("Please enter the customer id to get that customer's orders:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var customerId))
            {
                foreach (var item in customers.Where(c => c.Id == customerId))
                {
                    Console.WriteLine($"Customer {item.FirstName} {item.LastName}");
                    var customerOrderHistory = p0Repo.GetCustomerOrderHistory(customerId).ToList();
                    var cupcakes = p0Repo.GetAllCupcakes().ToList();
                    ConsoleDisplay.OrderList(p0Repo, customerOrderHistory, cupcakes, null);
                }
            }
            else
            {
                logger.Error($"Invalid input {input}");
            }
        }

        //public static void OrderRecommended(List<Customer> customers, List<Order> orders)
        //{
        //    ILogger logger = LogManager.GetCurrentClassLogger();

        //    int customerId = GetCustomer(customers);
        //    bool customerExists = Customer.CheckCustomerExists(customerId, customers);
        //    if (!customerExists) { return; }

        //    var customer = customers.Single(c => c.Id == customerId);
        //    var customerOrders = orders.Where(o => o.OrderCustomer == customerId);
        //    // https://stackoverflow.com/questions/6730974/select-most-frequent-value-using-linq
        //    var mostFrequentOrder = customerOrders.GroupBy(o => o.OrderItem.Item1)
        //                                            .OrderByDescending(gp => gp.Count())
        //                                            .Take(1);
        //    // https://code.i-harness.com/en/q/820541
        //    var intermediate = mostFrequentOrder.First();
        //    string orderRecommended = "not assigned";
        //    foreach (var item in intermediate)
        //    {
        //        orderRecommended = item.OrderItem.Item1.ToString();
        //        break;
        //    }

        //    if (orderRecommended == "not assigned")
        //    {
        //        logger.Error($"Unable to find recommended order for customer {customer.FirstName}" +
        //            $" {customer.LastName}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Order recommended count: {mostFrequentOrder.Count()}");
        //        Console.WriteLine($"Recommended Order for Customer {customer.FirstName}" +
        //            $" {customer.LastName}: {orderRecommended}");
        //    }
        //}

        public static string GetCustomerFirstName()
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            Console.WriteLine("Please enter a first name:");
            var input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                logger.Error("Empty input for first name is invalid.");
                return null;
            }
        }

        public static string GetCustomerLastName()
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            Console.WriteLine("Please enter a last name:");
            var input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                logger.Error("Empty input for last name is invalid.");
                return null;
            }
        }

        public static int GetStoreLocation(Project0Repo p0Repo, string prompt)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            ConsoleDisplay.LocationList(p0Repo);
            Console.WriteLine(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input, out var storeLocationId))
            {
                return storeLocationId;
            }
            else
            {
                logger.Error($"Invalid input {input}");
                return -1;
            }
        }

        public static int GetCustomer(Project0Repo p0Repo)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            ConsoleDisplay.CustomerList(p0Repo);
            Console.WriteLine("Please enter a valid customer Id for the order:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var customerId))
            {
                return customerId;
            }
            else
            {
                logger.Error($"Invalid input {input}");
                return -1;
            }
        }

        public static int GetCupcake(Project0Repo p0Repo)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            ConsoleDisplay.CupcakeList(p0Repo);
            Console.WriteLine("Please enter the number of a cupcake as it appears on the list:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var cupcakeId))
            {
                return cupcakeId;
            }
            else
            {
                logger.Error($"Invalid input {input}");
                return -1;
            }
        }

        public static int GetCupcakeQuantity()
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            Console.WriteLine("Please enter the quantity you would like to order:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var qnty))
            {
                return qnty;
            }
            else
            {
                logger.Error($"Invalid input {input}");
                return -1;
            }
        }
    }
}


    

