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
            DefaultStore = customer.DefaultStore
        };
        public static DataAccess.Customer Map(Library.Customer customer) => new DataAccess.Customer
        {
            CustomerId = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            DefaultStore = customer.DefaultStore
        };
        public static IEnumerable<Library.Customer> Map(IEnumerable<DataAccess.Customer> customers) =>
            customers.Select(Map);
        public static IEnumerable<DataAccess.Customer> Map(IEnumerable<Library.Customer> customers) =>
            customers.Select(Map);


    }
}
