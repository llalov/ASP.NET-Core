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

        [Route("create")]
        public IActionResult Create() 
            => View();

        [HttpPost]
        [Route (nameof(Create))]
        public IActionResult Create(CustomerFormModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            this.customers.CreateCustomer(
                model.Name,
                model.BirthDay,
                model.IsYoungDriver
                );
            return RedirectToAction(nameof(All), new { order = OrderDirection.Ascending});
        }

        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.ById(id);
            if (customer == null)
                return NotFound();
            ViewBag.CustomerId = id;
            ViewBag.CustomerName = customer.Name;
            return View(new CustomerFormModel
            {
                Name = customer.Name,
                BirthDay = customer.BirthDay,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, CustomerFormModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            bool customerExists = this.customers.Exists(id);
            if (!customerExists)
                return NotFound();
            this.customers.Edit(
                id,
                model.Name,
                model.BirthDay,
                model.IsYoungDriver
                );
            return RedirectToAction(nameof(All), new { order = OrderDirection.Ascending });
        }

        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            this.customers.Delete(id);
            return RedirectToAction(nameof(All), new { order = OrderDirection.Ascending });
        }
    }
}