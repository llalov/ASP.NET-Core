namespace Car_Dealer.Services.Models.Cars
{
    using System.Collections.Generic;

    public class CarWithPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set;}
    }
}
