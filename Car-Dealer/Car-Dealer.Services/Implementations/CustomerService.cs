namespace Car_Dealer.Services.Implementations
{
    using System.Collections.Generic;
    using Models;
    using Data.Models;
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

        public CustomerDetailsModel TotalSalesById(int id)
            => this.Db.Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerDetailsModel
            {
                Id = c.Id,
                Name = c.Name,
                IsYoungDriver = c.IsYoungDriver,
                BirthDay = c.BirthDate,
                BoughtCars = c.Sales.Select(s => new SaleModel
                {
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Discount = s.Discount
                })
            })
            .FirstOrDefault();

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

        public void CreateCustomer(string name, DateTime birthDate, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = birthDate,
                IsYoungDriver = isYoungDriver
            };
            this.Db.Add(customer);
            this.Db.SaveChanges();
        }

        public CustomerModel ById(int id)
            => this.Db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Name = c.Name,
                    BirthDay = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();

        public bool Exists(int id)
            => this.Db
                .Customers
                .Any(c => c.Id == id);

        public void Edit(int id, string name, DateTime birthDay, bool isYoungDriver)
        {
            var customer = this.Db.Customers.Find(id);
            customer.Name = name;
            customer.BirthDate = birthDay;
            customer.IsYoungDriver = isYoungDriver;
            this.Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = this.Db.Customers.Find(id);
            if (customer == null)
                return;
            this.Db.Remove(customer);
            this.Db.SaveChanges();
        }
    }
}
