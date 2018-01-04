namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService Sales;

        public SalesController(ISaleService sales)
        {
            this.Sales = sales;
        }

        [Route("")]
        public IActionResult All()
            => View(this.Sales.All());

        [Route("{id}")]
        public IActionResult Details(int id)
            => View(this.Sales.Details(id));

        [Route("discounted")]
        public IActionResult Discounted()
            => View();
    }
}
