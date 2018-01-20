namespace Car_Dealer.Controllers
{
    using Car_Dealer.Models.Sale;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Interfaces;
    using System.Linq;

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

        [Authorize]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.SaleId = id;
            return View(this.Sales.Details(id));
        }
            
        [Route("discounted")]
        public IActionResult Discounted()
            => View(this.Sales.Discounted());

        [Authorize]
        [Route("add")]
        public IActionResult Add()
            => View(new SaleFormModel
            {
                Customers = this.Customers.AllCustomers().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),

                Cars = this.Cars.AllCars().Select(c => new SelectListItem
                {
                    Text = c.Make +" "+ c.Model,
                    Value = c.Id.ToString()
                }) 
            });

        [Authorize]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(SaleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                View(new SaleFormModel
                {
                    Customers = this.Customers.AllCustomers().Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    }),

                    Cars = this.Cars.AllCars().Select(c => new SelectListItem
                    {
                        Text = c.Make + " " + c.Model,
                        Value = c.Id.ToString()
                    })
                });
            }
            this.Sales.Add(model.CarId, model.CustomerId, model.Discount);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!Sales.Exists(id))
                return NotFound();
            Sales.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
