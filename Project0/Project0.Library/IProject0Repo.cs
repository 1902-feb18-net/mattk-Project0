using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.DataAccess
{
    public interface IProject0Repo
    {
        void AddStoreLocation();
        void FillLocationInventory(int storeLocationId);
        void AddCustomer(string fName, string lName, int storeLocationId);
        int GetLastLocationAdded();
        int GetLastCustomerAdded();
        IEnumerable<Library.Location> GetAllStoreLocations();
        IEnumerable<Library.Customer> GetAllCustomers();
        IEnumerable<Library.Cupcake> GetAllCupcakes();
        bool CheckLocationExists(int storeLocationId);
        bool CheckCustomerExists(int customerId);
        bool CheckCupcakeExists(int cupcakeId);
        
        //IEnumerable<Movie> GetAllMovies();
        //IEnumerable<Movie> GetAllGenres();
        //Movie GetMovieById(int id);
        //IEnumerable<Movie> GetMoviesByGenre(Genre genre);
        //void AddMovie(Movie movie);
        //void UpdateMovie(Movie movie);
        //void DeleteMovie(Movie movie);
    }
}
