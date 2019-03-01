using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public static class ConsoleDisplay
    {
        //public static void DisplayMenu()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("'S': Add a store location to the database.");
        //    Console.WriteLine("'C': Add a customer to the database.");
        //    Console.WriteLine("'O': Add an order to the database.");
        //    Console.WriteLine("'SL': Get a list of available stores and their id numbers.");
        //    Console.WriteLine("'SO': Get a store's order history.");
        //    Console.WriteLine("'CL': Get a list of available customers and their information.");
        //    Console.WriteLine("'CS': Search for customers by name.");
        //    Console.WriteLine("'CO': Get a customer's order history.");
        //    Console.WriteLine("'OL': Get a list of all orders that have been placed.");
        //    Console.WriteLine("'OR': Get a customer's recommended order.");
        //    Console.WriteLine();
        //    Console.WriteLine("Please type a selection, or type 'q' to quit: ");
        //}

        //public static void StoreList(List<Location> storeLocations)
        //{
        //    Console.WriteLine("List of Available Store Locations:");
        //    Console.WriteLine();
        //    foreach (var item in storeLocations)
        //    {
        //        Console.WriteLine($"Store Id: {item.Id}");
        //    }
        //    Console.WriteLine();
        //}

        //public static void CustomerList(List<Customer> customers)
        //{
        //    Console.WriteLine("List of Customers:");
        //    Console.WriteLine();
        //    foreach (var item in customers)
        //    {
        //        Console.WriteLine($"Customer Id: {item.Id}, First Name: {item.FirstName}, " +
        //            $"Last Name, {item.LastName}, Default Store Id: {item.DefaultStore}");
        //    }
        //    Console.WriteLine();
        //}

        //public static void OrderList(List<Order> orders, List<Location> storeLocations)
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("Please select from the following filters ('n' for no filter)");
        //    Console.WriteLine("'E': Earliest orders first");
        //    Console.WriteLine("'L': Latest orders first");
        //    Console.WriteLine("'C': Cheapest orders first");
        //    Console.WriteLine("'X': Most expensive orders first");
        //    Console.WriteLine();
        //    Console.WriteLine("Please type a selection to see a list of orders: ");
        //    ConsoleRead.GetMenuInput(out var input);
        //    List<Order> modOrders = new List<Order>();

        //    if (input == "E")
        //    {
        //        foreach (var item in orders.OrderBy(o => o.OrderTime))
        //        {
        //            modOrders.Add(item);
        //        }
        //        DisplayOrders(modOrders, storeLocations, "List of Orders (earliest to latest):");
        //    }
        //    else if (input == "L")
        //    {
        //        foreach (var item in orders.OrderByDescending(o => o.OrderTime))
        //        {
        //            modOrders.Add(item);
        //        }
        //        DisplayOrders(modOrders, storeLocations, "List of Orders (latest to earliest):");
        //    }
        //    else if (input == "C")
        //    {
        //        foreach (var item in orders.OrderBy(o => (o.OrderItem.Item2 * o.OrderItem.Item1.Cost)))
        //        {
        //            modOrders.Add(item);
        //        }
        //        DisplayOrders(modOrders, storeLocations, "List of Orders (cheapest to most expensive):");
        //    }
        //    else if (input == "X")
        //    {
        //        foreach (var item in orders.OrderByDescending(o => (o.OrderItem.Item2 * o.OrderItem.Item1.Cost)))
        //        {
        //            modOrders.Add(item);
        //        }
        //        DisplayOrders(modOrders, storeLocations, "List of Orders (most expensive to cheapest):");
        //    }
        //    else
        //    {
        //        DisplayOrders(orders, storeLocations, "List of Orders:");
        //    }
        //}

        //public static void DisplayOrders(List<Order> orders, List<Location> storeLocations, string prompt)
        //{
        //    Console.WriteLine(prompt);
        //    Console.WriteLine();
        //    foreach (var item in orders)
        //    {
        //        Console.WriteLine($"Order Id: {item.Id}, Location Id: {item.OrderLocation}, " +
        //            $"Customer Id, {item.OrderCustomer}, Order Time: {item.OrderTime}, " +
        //            $"Order Item: {item.OrderItem.Item1}, qnty: {item.OrderItem.Item2}");
        //        Console.WriteLine($"Order Id {item.Id} total cost: " +
        //            $"${item.OrderItem.Item2 * item.OrderItem.Item1.Cost}");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Other order statistics...:");
        //    Console.WriteLine($"Average Order Cost: " +
        //        $"{orders.Average(o => o.OrderItem.Item2 * o.OrderItem.Item1.Cost)}");
        //    Console.WriteLine($"Order with the latest date: " +
        //        $"{orders.Max(o => o.OrderTime)}");
        //    if (!(storeLocations is null))
        //    {
        //        var storeWithMostOrders = storeLocations.MaxBy(sL => sL.OrderHistory.Count()).First();
        //        Console.WriteLine($"Store Id with the most orders: {storeWithMostOrders.Id}");
        //    }
        //    Console.WriteLine();
        //}

        //public static void CupcakeList()
        //{
        //    Console.WriteLine("List of Cupcakes:");
        //    Console.WriteLine();
        //    Console.WriteLine("Vanilla");
        //    Console.WriteLine("Chocolate");
        //    Console.WriteLine("ChocPeanutButter");
        //    Console.WriteLine("RaspAmaretto");
        //    Console.WriteLine("ChocPeppermint");
        //    Console.WriteLine("MintOreo");
        //    Console.WriteLine("Coconut");
        //    Console.WriteLine("Lemon");
        //    Console.WriteLine();
        //}


    }
}
