namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService Sales;
        private readonly ICarService Cars;
        private readonly ICustomerService Customers;

        public SalesController(ISaleService sales, ICarService cars, ICustomerService customers)
        {
            this.Sales = sales;
            this.Cars = cars;
            this.Customers = customers;
        }

        [Route("")]
        public IActionResult All()
            => View(this.Sales.All());

        [Route("{id}")]
        public IActionResult Details(int id)
            => View(this.Sales.Details(id));

        [Route("discounted")]
        public IActionResult Discounted()
            => View(this.Sales.Discounted());

        [Route("add")]
        public IActionResult Add()
            => View();
    }
}
