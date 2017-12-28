namespace Car_Dealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Models.Customers;
    using Models;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order);

        CustomerTotalSalesModel TotalSalesById(int id);
    }
}
