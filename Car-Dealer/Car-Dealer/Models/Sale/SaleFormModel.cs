namespace Car_Dealer.Models.Sale
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class SaleFormModel
    {
        IEnumerable<SelectListItem> Cars { get; set; }

        [Display(Name = "Car")]
        IEnumerable<int> CarIds { get; set; }

        IEnumerable<SelectListItem> Customers { get; set; }

        [Display(Name = "Customer")]
        IEnumerable<int> CustomerIds { get; set; }

        [Range(0, 100)]
        public double Discount { get; set; }
    }
}