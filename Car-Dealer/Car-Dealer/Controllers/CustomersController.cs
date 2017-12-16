namespace Car_Dealer.Controllers
{
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models;
    using Models.Customers;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        public IActionResult All(string order)
        {

            var orderDirection = order.ToLower() == "descending"
                ? OrderDirection.Descending
                : OrderDirection.Ascending;

            var result = this.customers.OrderedCustomers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = result,
                OrderDirection  = orderDirection
            });
        }
    }
}