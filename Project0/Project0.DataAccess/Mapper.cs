using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class Mapper
    {
        // Location
        public static Library.Location Map(DataAccess.Location location) => new Library.Location
        {
            Id = location.LocationId
        };
        public static DataAccess.Location Map(Library.Location location) => new DataAccess.Location
        {
            LocationId = location.Id
        };
        public static IEnumerable<Library.Location> Map(IEnumerable<DataAccess.Location> locations) => 
            locations.Select(Map);
        public static IEnumerable<DataAccess.Location> Map(IEnumerable<Library.Location> locations) => 
            locations.Select(Map);

        // Customer
        public static Library.Customer Map(DataAccess.Customer customer) => new Library.Customer
        {
            Id = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            DefaultLocation = customer.DefaultLocation
        };
        public static DataAccess.Customer Map(Library.Customer customer) => new DataAccess.Customer
        {
            CustomerId = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            DefaultLocation = customer.DefaultLocation
        };
        public static IEnumerable<Library.Customer> Map(IEnumerable<DataAccess.Customer> customers) =>
            customers.Select(Map);
        public static IEnumerable<DataAccess.Customer> Map(IEnumerable<Library.Customer> customers) =>
            customers.Select(Map);

        // Cupcake
        public static Library.Cupcake Map(DataAccess.Cupcake cupcake) => new Library.Cupcake
        {
            Id = cupcake.CupcakeId,
            Type = cupcake.Type,
            Cost = cupcake.Cost
        };
        public static DataAccess.Cupcake Map(Library.Cupcake cupcake) => new DataAccess.Cupcake
        {
            CupcakeId = cupcake.Id,
            Type = cupcake.Type,
            Cost = cupcake.Cost
        };
        public static IEnumerable<Library.Cupcake> Map(IEnumerable<DataAccess.Cupcake> cupcakes) =>
            cupcakes.Select(Map);
        public static IEnumerable<DataAccess.Cupcake> Map(IEnumerable<Library.Cupcake> cupcakes) =>
            cupcakes.Select(Map);

        // CupcakeOrder
        public static Library.Order Map(DataAccess.CupcakeOrder order) => new Library.Order
        {
            Id = order.OrderId,
            OrderLocation = order.LocationId,
            OrderCustomer = order.CustomerId,
            OrderTime = order.OrderTime
        };
        public static DataAccess.CupcakeOrder Map(Library.Order order) => new DataAccess.CupcakeOrder
        {
            OrderId = order.Id,
            LocationId = order.OrderLocation,
            CustomerId = order.OrderCustomer,
            OrderTime = order.OrderTime
        };
        public static IEnumerable<Library.Order> Map(IEnumerable<DataAccess.CupcakeOrder> orders) =>
            orders.Select(Map);
        public static IEnumerable<DataAccess.CupcakeOrder> Map(IEnumerable<Library.Order> orders) =>
            orders.Select(Map);

        // CupcakeOrderItem
        public static Library.OrderItem Map(DataAccess.CupcakeOrderItem orderItem) => new Library.OrderItem
        {
            Id = orderItem.CupcakeOrderItemId,
            OrderId = orderItem.OrderId,
            CupcakeId = orderItem.CupcakeId,
            Quantity = orderItem.Quantity
        };
        public static DataAccess.CupcakeOrderItem Map(Library.OrderItem orderItem) => new DataAccess.CupcakeOrderItem
        {
            CupcakeOrderItemId = orderItem.Id,
            OrderId = orderItem.OrderId,
            CupcakeId = orderItem.CupcakeId,
            Quantity = orderItem.Quantity
        };
        public static IEnumerable<Library.OrderItem> Map(IEnumerable<DataAccess.CupcakeOrderItem> orderItems) =>
            orderItems.Select(Map);
        public static IEnumerable<DataAccess.CupcakeOrderItem> Map(IEnumerable<Library.OrderItem> orderItems) =>
            orderItems.Select(Map);
    }
}
