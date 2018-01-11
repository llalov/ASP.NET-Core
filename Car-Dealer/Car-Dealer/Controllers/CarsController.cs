namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Models.Cars;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService Cars;

        public CarsController(ICarService cars)
        {
            this.Cars = cars;
        }

        [Route("")]
        public IActionResult AllCars()
            => View(this.Cars.AllCars());
        

        [Route("{make}", Order = 2)]
        public IActionResult ByMakeCars(string make)
        {
            var result = Cars.ByMakeCars(make);
            return View(new ByMakeCarsModel {
                Cars = result,
                Make = make
            });
        }

        [Route("{id}/parts", Order = 1)]
        public IActionResult Parts(int id)
            => View(this.Cars.CarParts(id));

        [Route(nameof(Add))]
        public IActionResult Add()
            => View();

        [HttpPost]
        [Route(nameof(Add))]
        public IActionResult Add(CarFormModel carModel)
        {
            if (!ModelState.IsValid)    
                return View(carModel);

            this.Cars.Add(carModel.Make, carModel.Model, carModel.TravelledDistance);

            return RedirectToAction(nameof(AllCars));
        }
    }
}