namespace Car_Dealer.Services.Models.Sales
{
    public class SaleDetailsModel : SaleListModel
    {
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public string CarMake { get; set; }

        public string CarModel { get; set; }
    }
}
