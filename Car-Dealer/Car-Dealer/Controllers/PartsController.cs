namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("parts")]
    public class PartsController : Controller
    {
        private readonly IPartsService Parts;

        public PartsController(IPartsService parts)
        {
            this.Parts = parts;
        }

        [Route("")]
        public IActionResult All()
            => View(this.Parts.AllParts());

        [Route("add")]
        public IActionResult Add()
            => View();

    }
}
