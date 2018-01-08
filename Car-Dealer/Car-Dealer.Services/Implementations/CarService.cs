namespace Car_Dealer.Services.Implementations
{
    using System.Collections.Generic;
    using Data;
    using Car_Dealer.Services.Models.Cars;
    using Models.Parts;
    using System.Linq;
    using Interfaces;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext Db;

        public CarService(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public IEnumerable<CarModel> AllCars()
            => this.Db.Cars
            .OrderBy(c => c.Make)
            .Select(c => new CarModel
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance
            })
            .ToList();

        public IEnumerable<CarModel> ByMakeCars(string make)
            => this.Db.Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

        public CarWithPartsModel CarParts(int carId)
            => this.Db.Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                })
                .FirstOrDefault();
    }
}
