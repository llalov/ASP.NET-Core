namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    public class SalesController : Controller
    {
        private readonly ISaleService Sales;

        public SalesController(ISaleService sales)
        {
            this.Sales = sales;
        }

        [Route("sales")]
        public IActionResult All()
            => View(this.Sales.All());
    }
}
