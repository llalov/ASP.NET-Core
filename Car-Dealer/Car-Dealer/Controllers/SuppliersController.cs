namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Models.Suppliers;

    public class SuppliersController : Controller
    {
        private readonly ISupplierService Suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.Suppliers = suppliers;
        }

        public IActionResult Local()
            => this.View("Suppliers", this.GetSupplierModel(false));
        
        public IActionResult Importers()
            => this.View("Suppliers", this.GetSupplierModel(true));
        
        private SuppliersModel GetSupplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";
            var suppliers = this.Suppliers.AllDetailed(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }
    }
}