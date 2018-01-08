namespace Car_Dealer.Services.Models.Parts
{
    public class PartListModel : PartModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Supplier { get; set; }
    }
}
