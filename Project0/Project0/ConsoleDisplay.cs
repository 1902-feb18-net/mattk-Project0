﻿using MoreLinq;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0
{
    public static class ConsoleDisplay
    {
        public static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("'S': Add a store location to the database.");
            Console.WriteLine("'C': Add a customer to the database.");
            Console.WriteLine("'O': Add an order to the database.");
            Console.WriteLine("'LL': Get a list of available store locations and their Id numbers.");
            Console.WriteLine("'LO': Get a store's order history.");
            Console.WriteLine("'CL': Get a list of available customers and their information.");
            Console.WriteLine("'CS': Search for customers by name.");
            Console.WriteLine("'CO': Get a customer's order history.");
            Console.WriteLine("'OL': Get a list of all orders that have been placed.");
            Console.WriteLine("'OR': Get a customer's recommended order.");
            Console.WriteLine();
            Console.WriteLine("Please type a selection, or type 'q' to quit: ");
        }

        public static void LocationList(IProject0Repo p0Repo)
        {
            Console.WriteLine("List of Available Store Locations:");
            Console.WriteLine();
            var locations = p0Repo.GetAllLocations().ToList();
            foreach (var item in locations)
            {
                Console.WriteLine($"Location Id: {item.Id}");
            }
            Console.WriteLine();
        }

        public static void CustomerList(IProject0Repo p0Repo)
        {
            Console.WriteLine("List of Customers:");
            Console.WriteLine();
            var customers = p0Repo.GetAllCustomers().ToList();
            foreach (var item in customers)
            {
                Console.WriteLine($"Customer Id: {item.Id}, First Name: {item.FirstName}, " +
                    $"Last Name, {item.LastName}, Default Location Id: {item.DefaultStore}");
            }
            Console.WriteLine();
        }

        public static void OrderList(IProject0Repo p0Repo, List<Library.Order> orders, 
            List<Library.Cupcake> cupcakes, List<Library.Location> locations)
        {
            Console.WriteLine();
            Console.WriteLine("Please select from the following filters ('n' for no filter)");
            Console.WriteLine("'E': Earliest orders first");
            Console.WriteLine("'L': Latest orders first");
            Console.WriteLine("'C': Cheapest orders first");
            Console.WriteLine("'X': Most expensive orders first");
            Console.WriteLine();
            Console.WriteLine("Please type a selection to see a list of orders: ");
            ConsoleRead.GetMenuInput(out var input);
            List<Library.Order> modOrders = new List<Library.Order>();

            if (input == "E")
            {
                foreach (var item in orders.OrderBy(o => o.OrderTime))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(p0Repo, modOrders, cupcakes, locations, "List of Orders (earliest to latest):");
            }
            else if (input == "L")
            {
                foreach (var item in orders.OrderByDescending(o => o.OrderTime))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(p0Repo, modOrders, cupcakes, locations, "List of Orders (latest to earliest):");
            }
            else if (input == "C")
            {
                foreach (var item in orders.OrderBy(o => 
                        (o.OrderQuantity * cupcakes.Single(c => c.Id == o.OrderCupcake).Cost)))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(p0Repo, modOrders, cupcakes, locations, "List of Orders (cheapest to most expensive):");
            }
            else if (input == "X")
            {
                foreach (var item in orders.OrderByDescending(o =>
                        (o.OrderQuantity * cupcakes.Single(c => c.Id == o.OrderCupcake).Cost)))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(p0Repo, modOrders, cupcakes, locations, "List of Orders (most expensive to cheapest):");
            }
            else
            {
                DisplayOrders(p0Repo, orders, cupcakes, locations, "List of Orders:");
            }
        }

        public static void DisplayOrders(IProject0Repo p0Repo, List<Library.Order> orders,
            List<Library.Cupcake> cupcakes, List<Library.Location> locations, string prompt)
        {
            Console.WriteLine(prompt);
            Console.WriteLine();
            foreach (var item in orders)
            {
                Console.WriteLine($"Order Id: {item.Id}, Location Id: {item.OrderLocation}, " +
                    $"Customer Id, {item.OrderCustomer}, Order Time: {item.OrderTime}, " +
                    $"Order Item: {cupcakes.Single(c => c.Id == item.OrderCupcake).Type}, " +
                    $"qnty: {item.OrderQuantity}");
                Console.WriteLine($"Order Id {item.Id} total cost: " +
                    $"${item.OrderQuantity * cupcakes.Single(c => c.Id == item.OrderCupcake).Cost}");
            }
            Console.WriteLine();
            Console.WriteLine("Other order statistics...:");
            Console.WriteLine($"Average Order Cost: " +
                $"{orders.Average(o => o.OrderQuantity * cupcakes.Single(c => c.Id == o.OrderCupcake).Cost)}");
            Console.WriteLine($"Order with the latest date: " +
                $"{orders.Max(o => o.OrderTime)}");
            if (!(locations is null))
            {
                var storeWithMostOrders = locations.MaxBy(sL => 
                p0Repo.GetLocationOrderHistory(sL.Id).Count()).First();
                Console.WriteLine($"Store Id with the most orders: {storeWithMostOrders.Id}");
            }
            Console.WriteLine();
        }

        public static void CupcakeList(IProject0Repo p0Repo)
        {
            Console.WriteLine("List of Cupcakes:");
            Console.WriteLine();
            var cupcakes = p0Repo.GetAllCupcakes();
            foreach (var item in cupcakes)
            {
                Console.WriteLine($"{item.Id}: {item.Type}");
            }
           
            Console.WriteLine();
        }

    }
}
