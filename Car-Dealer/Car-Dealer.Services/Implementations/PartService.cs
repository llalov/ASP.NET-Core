namespace Car_Dealer.Services.Implementations
{
    using System.Collections.Generic;
    using Car_Dealer.Services.Models.Parts;
    using Interfaces;
    using Data;
    using System.Linq;

    public class PartService : IPartsService
    {
        private readonly ApplicationDbContext Db;

        public PartService(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public IEnumerable<PartListModel> AllParts()
            => this.Db
                .Parts
                .Select(p => new PartListModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Supplier = p.Supplier.Name
                })
                .ToList();

        public void Add(string name, decimal price, int supplierId)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(decimal price, int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}
