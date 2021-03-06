﻿namespace Car_Dealer.Services.Interfaces
{
    using Models.Cars;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarModel> ByMakeCars(string make);

        CarWithPartsModel CarParts(int carId);

        IEnumerable<CarModel> AllListCars();

        IEnumerable<CarBasicModel> AllCars();

        void Add(string make, string model, long travelledDistance, IEnumerable<int> partIds);
    }
}
