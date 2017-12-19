namespace Car_Dealer.Services.Implementations
{
    using System.Linq;
    using Car_Dealer.Data;
    using System.Collections.Generic;
    using Car_Dealer.Services.Models;
    using Interfaces;

    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext Db;

        public SupplierService(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public IEnumerable<SupplierModel> All(bool isImporter)
            =>this.Db.Suppliers
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count(),
                    IsImporter = s.IsImporter
                })
                .ToList();
    }
}
