namespace Car_Dealer.Services.Interfaces
{
    using Car_Dealer.Services.Models.Parts;
    using System.Collections.Generic;

    public interface IPartsService
    {
        IEnumerable<PartListModel> AllParts();

        void Add(string name, decimal price, int supplierId);

        void Edit(decimal price, int quantity);
    }
}
