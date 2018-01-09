namespace Car_Dealer.Services.Models.Suppliers
{
    public class SupplierListModel : SupplierModel
    {
        public int TotalParts { get; set; }

        public bool IsImporter { get; set; }
    }
}
