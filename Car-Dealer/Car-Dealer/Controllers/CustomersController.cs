namespace Car_Dealer.Controllers
{
    using Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models;
    using Models.Customers;
    using Services.Models.Customers;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            
            var orderDirection = order == "descending"
                ? OrderDirection.Descending
                : OrderDirection.Ascending;

            var result = this.customers.OrderedCustomers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = result,
                OrderDirection  = orderDirection
            });
        }

        [Route("{id}")]
        public IActionResult TotalSales(int id)
        {
            var result = this.customers.TotalSalesById(id);

            return View(new CustomerTotalSalesModel
            {
                Id = result.Id,
                Name = result.Name,
                IsYoungDriver = result.IsYoungDriver,
                BoughtCars = result.BoughtCars
            });
        }
    }
}