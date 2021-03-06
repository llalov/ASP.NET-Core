﻿namespace Car_Dealer.Services.Implementations
{
    using System.Collections.Generic;
    using Data;
    using Data.Models;
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

        public IEnumerable<CarModel> AllListCars()
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

        public void Add(string make, string model, long travelledDistance, IEnumerable<int> partIds)
        {
            var existingParts = this.Db
                .Parts
                .Where(p => partIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToList();

            var car = new Car
            {
                Make = make,
                Model = model,
                TravelledDistance = travelledDistance
            };

            foreach (var partId in existingParts)
            {
                car.Parts.Add(new PartCar { PartId = partId });
            }

            this.Db.Add(car);
            this.Db.SaveChanges();
        }

        public IEnumerable<CarBasicModel> AllCars()
            => this.Db
                .Cars
                .OrderBy(c => c.Make)
                .Select(c => new CarBasicModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model
                })
                .ToList();
    }
}
