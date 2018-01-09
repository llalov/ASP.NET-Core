namespace Car_Dealer.Controllers
{
    using Car_Dealer.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Interfaces;
    using System.Linq;

    [Route("parts")]
    public class PartsController : Controller
    {
        private readonly IPartsService Parts;
        private readonly ISupplierService suppliers;

        public PartsController(IPartsService parts, ISupplierService suppliers)
        {
            this.Parts = parts;
            this.suppliers = suppliers;
        }

        [Route("")]
        public IActionResult All()
            => View(this.Parts.AllParts());

        [Route("add")]
        public IActionResult Add()
            => View(new PartFormModel
            {
                Suppliers = suppliers.All().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });
    }
}
