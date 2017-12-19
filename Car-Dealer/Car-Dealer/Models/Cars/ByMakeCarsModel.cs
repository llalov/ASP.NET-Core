namespace Car_Dealer.Models.Cars
{
    using System.Collections.Generic;
    using Car_Dealer.Services.Models.Cars;

    public class ByMakeCarsModel
    {
        public IEnumerable<CarModel> Cars { get; set; }

        public string Make { get; set; }
    }
}
