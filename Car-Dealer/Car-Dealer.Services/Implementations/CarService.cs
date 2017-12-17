namespace Car_Dealer.Services.Implementations
{
    using System.Collections.Generic;
    using Data;
    using Car_Dealer.Services.Models;
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext Db;

        public CarService(ApplicationDbContext db)
        {
            this.Db = db;
        }

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
    }
}
