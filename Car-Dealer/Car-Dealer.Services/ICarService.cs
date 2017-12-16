namespace Car_Dealer.Services
{
    using Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarModel> ByMakeCars(string make);   
    }
}
