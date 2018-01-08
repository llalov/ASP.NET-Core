namespace Car_Dealer.Models.Suppliers
{
    using System.Collections.Generic;
    using Services.Models.Suppliers;

    public class SuppliersModel
    {
        public IEnumerable<SupplierListModel> Suppliers { get; set; }

        public string Type { get; set; }
    }
}
