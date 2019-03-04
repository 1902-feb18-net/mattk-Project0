using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.DataAccess
{
    public interface IProject0Repo
    {
        void AddLocation();
        void FillLocationInventory(int locationId);
        void AddCustomer(string fName, string lName, int locationId);
        void AddCupcakeOrder(int locationId, int customerId, int cupcakeId, int qnty);
        int GetLastLocationAdded();
        int GetLastCustomerAdded();
        int GetLastCupcakeOrderAdded();
        Library.Order GetCupcakeOrder(int orderId);
        int GetDefaultLocation(int customerId);
        Dictionary<int, decimal> GetRecipe(int cupcakeId);
        Dictionary<int, decimal> GetLocationInv(int locationId);
        IEnumerable<Library.Location> GetAllLocations();
        IEnumerable<Library.Customer> GetAllCustomers();
        IEnumerable<Library.Cupcake> GetAllCupcakes();
        IEnumerable<Library.Order> GetAllOrders();
        IEnumerable<Library.Order> GetLocationOrderHistory(int locationId);
        IEnumerable<Library.Order> GetCustomerOrderHistory(int customerId);
        bool CheckLocationExists(int locationId);
        bool CheckCustomerExists(int customerId);
        bool CheckCupcakeExists(int cupcakeId);
        bool CheckOrderExists(int orderId);
        void UpdateLocationInv(int locationId, Dictionary<int, decimal> recipe, int qnty);
    }
}
