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
        void AddCupcakeOrder(int storeLocationId, int customerId, int cupcakeId, int qnty);
        int GetLastLocationAdded();
        int GetLastCustomerAdded();
        int GetLastCupcakeOrderAdded();
        IEnumerable<Library.Location> GetAllStoreLocations();
        IEnumerable<Library.Customer> GetAllCustomers();
        IEnumerable<Library.Cupcake> GetAllCupcakes();
        IEnumerable<Library.Order> GetAllOrders();
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
