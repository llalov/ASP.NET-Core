namespace Car_Dealer.Services.Implementations
{
    using System.Collections.Generic;
    using Models;
    using Models.Customers;
    using Data;
    using System.Linq;
    using System;
    using Interfaces;
    using Car_Dealer.Services.Models.Sales;

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext Db;

        public CustomerService(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public CustomerTotalSalesModel TotalSalesById(int id)
            => this.Db.Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerTotalSalesModel
            {
                Id = c.Id,
                Name = c.Name,
                IsYoungDriver = c.IsYoungDriver,
                BoughtCars = c.Sales.Select(s => new SaleModel
                {
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Discount = s.Discount
                })
            }).FirstOrDefault();

        public IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order)
        {
            var customersQuery = this.Db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    customersQuery = customersQuery.OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver);
                    break;
                case OrderDirection.Descending:
                    customersQuery = customersQuery.OrderByDescending(c => c.BirthDate).ThenBy(c => c.IsYoungDriver);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid order direction: {order}");
            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDay = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }
    }
}
