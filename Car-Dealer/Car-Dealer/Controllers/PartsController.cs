namespace Car_Dealer.Controllers
{
    using Car_Dealer.Models.Parts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Interfaces;
    using System.Linq;

    [Route("parts")]
    public class PartsController : Controller
    {
        private readonly IPartsService Parts;
        private readonly ISupplierService Suppliers;

        public PartsController(IPartsService parts, ISupplierService suppliers)
        {
            this.Parts = parts;
            this.Suppliers = suppliers;
        }

        [Route("")]
        public IActionResult All()
            => View(this.Parts.AllListParts());

        [Authorize]
        [Route("add")]
        public IActionResult Add()
            => View(new PartFormModel
            {
                Suppliers = Suppliers.All().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });

        [Authorize]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new PartFormModel
                {
                    Suppliers = Suppliers.All().Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString()
                    })
                });
            }
            this.Parts.Add(model.Name, model.Price, model.SupplierId, model.Quantity);
            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            if (!this.Parts.Exists(id))
                return NotFound();
            var part = this.Parts.ById(id);
            ViewBag.PartId = id;
  
            return View(new PartFormModel
            {
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity
            });
        }

        [Authorize]
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, PartFormModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool partExists = this.Parts.Exists(id);
            if (!partExists)
                return NotFound();

            this.Parts.Edit(id, model.Price, model.Quantity);
            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            this.Parts.Delete(id);
            return RedirectToAction(nameof(All));
        }
    }
}
