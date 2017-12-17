namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Models.Cars;

    public class CarsController : Controller
    {
        private readonly ICarService Cars;

        public CarsController(ICarService cars)
        {
            this.Cars = cars;
        }
        [Route("cars/{make}")]
        public IActionResult ByMakeCars(string make)
        {
            var result = Cars.ByMakeCars(make);
            return View(new ByMakeCarsModel {
                Cars = result,
                Make = make
            });
        }
    }
}