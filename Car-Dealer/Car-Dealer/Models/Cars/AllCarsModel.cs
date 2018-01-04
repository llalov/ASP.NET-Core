

namespace Car_Dealer.Models.Cars
{
    using System.Collections.Generic;
    using Services.Models.Cars;
    public class AllCarsModel
    {
        public IEnumerable<CarModel> AllCars { get; set;}

    }
}
