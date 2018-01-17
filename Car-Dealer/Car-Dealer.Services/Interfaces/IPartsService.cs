namespace Car_Dealer.Services.Interfaces
{
    using Car_Dealer.Services.Models.Parts;
    using System.Collections.Generic;

    public interface IPartsService
    {
        IEnumerable<PartListModel> AllListParts();

        IEnumerable<PartBasicModel> AllParts();

        PartListModel ById(int id);

        void Add(string name, decimal price, int supplierId, int quantity);

        void Edit(int id, decimal price, int quantity);

        void Delete(int id);

        bool Exists(int id);
    }
}
