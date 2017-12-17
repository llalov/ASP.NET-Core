namespace Car_Dealer.Services
{
    using Models;
    using System.Collections.Generic;
   
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> All(bool isImporter);
    }
}