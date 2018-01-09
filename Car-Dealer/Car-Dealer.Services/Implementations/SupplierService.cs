namespace Car_Dealer.Services.Implementations
{
    using System.Linq;
    using Car_Dealer.Data;
    using System.Collections.Generic;
    using Car_Dealer.Services.Models.Suppliers;
    using Interfaces;

    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext Db;

        public SupplierService(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public IEnumerable<SupplierListModel> AllDetailed(bool isImporter)
            => this.Db
                .Suppliers
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierListModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count(),
                    IsImporter = s.IsImporter
                })
                .ToList();

        public IEnumerable<SupplierModel> All()
            => this.Db
                .Suppliers
                .OrderBy(s => s.Name)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();
    }
}
