namespace Car_Dealer.Services.Implementations
{
    using Data;
    using System.Linq;
    using Interfaces;
    using Car_Dealer.Services.Models.Sales;
    using System.Collections.Generic;

    public class SaleService : ISaleService 
    {
        private readonly ApplicationDbContext Db;

        public SaleService(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public IEnumerable<SaleListModel> All()
            => this.Db
                .Sales
                .Select(s => new SaleListModel
                {
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    
                })
                .ToList();
    }
}
