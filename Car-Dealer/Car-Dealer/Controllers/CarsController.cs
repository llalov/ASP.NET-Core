namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Models.Cars;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Authorization;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService Cars;
        private readonly IPartsService partsService;

        public CarsController(ICarService cars, IPartsService parts)
        {
            this.Cars = cars;
            this.partsService = parts;
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

        [Authorize]
        [Route(nameof(Add))]
        public IActionResult Add()
            => View(new CarFormModel
            {
                Parts = this.partsService
                    .AllParts()
                    .Select(p => new SelectListItem
                    {
                        Text = p.Name,
                        Value = p.Id.ToString()
                    })                 
            });

        [Authorize]
        [HttpPost]
        [Route(nameof(Add))]
        public IActionResult Add(CarFormModel carModel)
        {
            if (!ModelState.IsValid)    
                return View(new CarFormModel
                {
                    Parts = this.partsService
                        .AllParts()
                        .Select(p => new SelectListItem
                        {
                            Text = p.Name,
                            Value = p.Id.ToString()
                        })
                });

            this.Cars.Add(
                carModel.Make, 
                carModel.Model, 
                carModel.TravelledDistance,
                carModel.PartsIds);

            return RedirectToAction(nameof(AllCars));
        }
    }
}