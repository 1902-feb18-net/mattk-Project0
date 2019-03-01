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

        public void AddStoreLocation()
        {
            var newLocation = new Location();
            Context.Location.Add(newLocation);
            Context.SaveChanges();
        }

        public int GetLastLocationAdded()
        {
            var newLocation = Context.Location
                .OrderByDescending(x => x.LocationId)
                .First();
            return newLocation.LocationId;
        }
    }
}
