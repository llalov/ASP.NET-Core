namespace Car_Dealer.Services.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalParts { get; set; }

        public bool IsImporter { get; set; }
    }
}
