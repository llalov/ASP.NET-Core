namespace Car_Dealer.Services.Models.Cars
{
    using System.Collections.Generic;
    using Models.Parts;

    public class CarWithPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set;}
    }
}
