namespace Car_Dealer.Services.Interfaces
{
    using Models.Cars;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarModel> ByMakeCars(string make);

        CarWithPartsModel CarParts(int carId);

        IEnumerable<CarModel> AllCars();
    }
}
