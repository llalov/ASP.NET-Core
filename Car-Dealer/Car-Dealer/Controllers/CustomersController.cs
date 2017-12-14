namespace Car_Dealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}