namespace Car_Dealer.Services
{
    using System.Collections.Generic;
    using Models;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order);
    }
}
