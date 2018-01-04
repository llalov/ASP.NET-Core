﻿namespace Car_Dealer.Services.Implementations
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
                    Id = s.Id,
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                })
                .ToList();

        public SaleDetailsModel Details(int id)
            => this.Db.Sales
                .Where(s => s.Id == id)
                .Select(s => new SaleDetailsModel
                {
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Discount = s.Discount,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    CarMake = s.Car.Make,
                    CarModel = s.Car.Model
                })
                .FirstOrDefault();

        public IEnumerable<SaleListModel> Discounted()
        {
            throw new System.NotImplementedException();
        }
    }
}