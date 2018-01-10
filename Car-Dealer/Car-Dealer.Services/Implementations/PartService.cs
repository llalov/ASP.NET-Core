namespace Car_Dealer.Services.Implementations
{
    using System.Collections.Generic;
    using Car_Dealer.Services.Models.Parts;
    using Interfaces;
    using Data;
    using Data.Models;
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

        public PartListModel ById(int id)
            => this.Db
                .Parts
                .Where(p => p.Id == id)
                .Select(p => new PartListModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Supplier = p.Supplier.Name
                })
                .FirstOrDefault();

        public void Add(string name, decimal price, int supplierId, int quantity)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                SupplierId = supplierId,
                Quantity = quantity
            };
            this.Db.Add(part);
            this.Db.SaveChanges();
        }

        public void Edit(decimal price, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
            => this.Db
                .Parts
                .Any(p => p.Id == id);
    }
}
