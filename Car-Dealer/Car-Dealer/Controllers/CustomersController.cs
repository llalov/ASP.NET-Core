namespace Car_Dealer.Controllers
{
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower() == "ascending"
                ? OrderDirection.Ascending
                : OrderDirection.Descending;

            var result = this.customers.OrderedCustomers(orderDirection);
            return View(result);
        }
    }
}