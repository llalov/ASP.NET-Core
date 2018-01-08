namespace Car_Dealer.Services.Models.Suppliers
{
    public class SupplierListModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalParts { get; set; }

        public bool IsImporter { get; set; }
    }
}
