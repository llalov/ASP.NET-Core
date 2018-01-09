namespace Car_Dealer.Services.Interfaces
{
    using Models.Suppliers;
    using System.Collections.Generic;
   
    public interface ISupplierService
    {
        IEnumerable<SupplierListModel> AllDetailed(bool isImporter);

        IEnumerable<SupplierModel> All();
    }
}