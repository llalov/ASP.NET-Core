namespace Car_Dealer.Services.Models.Customers
{
    using System;

    public class CustomerModel : CustomerBasicModel
    {
        public DateTime BirthDay { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
