namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Models.Cars;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Authorization;

    [Route("cars")]
    [Authorize]
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
        [AllowAnonymous]
        public IActionResult AllCars()
            => View(this.Cars.AllListCars());
        
        [Route("{make}", Order = 2)]
        [AllowAnonymous]
        public IActionResult ByMakeCars(string make)
        {
            var result = Cars.ByMakeCars(make);
            return View(new ByMakeCarsModel {
                Cars = result,
                Make = make
            });
        }

        [Route("{id}/parts", Order = 1)]
        [AllowAnonymous]
        public IActionResult Parts(int id)
            => View(this.Cars.CarParts(id));

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