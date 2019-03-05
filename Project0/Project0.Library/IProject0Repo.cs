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
        void AddCupcakeOrder(int locationId, int customerId);
        void AddCupcakeOrderItems(int orderId, Dictionary<int, int> cupcakeInputs);
        int GetLastLocationAdded();
        int GetLastCustomerAdded();
        int GetLastCupcakeOrderAdded();
        Library.Order GetCupcakeOrder(int orderId);
        int GetDefaultLocation(int customerId);
        Dictionary<int, Dictionary<int, decimal>> GetRecipes(Dictionary<int, int> cupcakeInputs);
        Dictionary<int, decimal> GetLocationInv(int locationId);
        IEnumerable<Library.Location> GetAllLocations();
        IEnumerable<Library.Customer> GetAllCustomers();
        IEnumerable<Library.Cupcake> GetAllCupcakes();
        IEnumerable<Library.Order> GetAllOrders();
        IEnumerable<Library.OrderItem> GetAllOrderItems();
        IEnumerable<Library.Order> GetLocationOrderHistory(int locationId);
        IEnumerable<Library.Order> GetCustomerOrderHistory(int customerId);
        IEnumerable<Library.OrderItem> GetOrderItems(int orderId);
        IEnumerable<Library.OrderItem> GetCustomerOrderItems(int customerId);
        bool CheckLocationExists(int locationId);
        bool CheckCustomerExists(int customerId);
        bool CheckCupcakeExists(int cupcakeId);
        bool CheckOrderExists(int orderId);
        void UpdateLocationInv(int locationId, Dictionary<int, Dictionary<int, decimal>> recipes,
            Dictionary<int, int> cupcakeInputs);
    }
}
