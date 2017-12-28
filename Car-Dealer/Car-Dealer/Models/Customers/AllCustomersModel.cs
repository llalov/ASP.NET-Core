namespace Car_Dealer.Models.Customers
{
    using System.Collections.Generic;
    using Car_Dealer.Services.Models;
    using Car_Dealer.Services.Models.Customers;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderDirection OrderDirection { get; set; }
    }
}
