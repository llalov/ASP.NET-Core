namespace Car_Dealer.Services.Models.Customers
{
    using Models.Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerTotalSalesModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }

        public decimal TotalMoneySpent
            => this.BoughtCars
                .Sum(c => c.Price * (1 - (decimal)c.Discount))
                * (this.IsYoungDriver ? 0.95m : 1);
    }
}
