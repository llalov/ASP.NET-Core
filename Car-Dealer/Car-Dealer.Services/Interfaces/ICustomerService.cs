namespace Car_Dealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Models.Customers;
    using Models;
    using System;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order);

        IEnumerable<CustomerBasicModel> AllCustomers();

        CustomerDetailsModel TotalSalesById(int id);

        CustomerModel ById(int id);

        void CreateCustomer(string name, DateTime birthDate, bool isYoungDriver);

        void Edit(int id, string name, DateTime birthDay, bool isYoungDriver);

        void Delete(int id);

        bool Exists(int id);
    }
}
