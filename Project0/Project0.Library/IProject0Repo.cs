﻿using System;
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
        Dictionary<int, decimal> GetRecipe(int cupcakeId);
        Dictionary<int, decimal> GetLocationInv(int storeLocationId);
        IEnumerable<Library.Location> GetAllStoreLocations();
        IEnumerable<Library.Customer> GetAllCustomers();
        IEnumerable<Library.Cupcake> GetAllCupcakes();
        IEnumerable<Library.Order> GetAllOrders();
        IEnumerable<Library.Order> GetLocationOrderHistory(int storeLocationId);
        IEnumerable<Library.Order> GetCustomerOrderHistory(int customerId);
        bool CheckLocationExists(int storeLocationId);
        bool CheckCustomerExists(int customerId);
        bool CheckCupcakeExists(int cupcakeId);
        void UpdateLocationInv(int storeLocationId, Dictionary<int, decimal> recipe, int qnty);
    }
}
