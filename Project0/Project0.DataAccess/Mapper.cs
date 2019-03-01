using Project0.DataAccess;
using System;

namespace Project0.Library
{
    public static class Mapper
    {
        public static Library.Location Map(DataAccess.Location location) => new Library.Location
        {
            Id = location.LocationId
        };
        
    }
}
