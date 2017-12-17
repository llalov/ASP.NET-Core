namespace Car_Dealer.Models.Suppliers
{
    using System.Collections.Generic;
    using Services.Models;

    public class SuppliersModel
    {
        public IEnumerable<SupplierModel> Suppliers { get; set; }

        public string Type { get; set; }
    }
}
