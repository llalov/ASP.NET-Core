namespace Car_Dealer.Models.Sale
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class SaleFormModel
    {
        public IEnumerable<SelectListItem> Cars { get; set; }

        [Display(Name = "Car")]
        [Required]
        public int CarId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }

        [Display(Name = "Customer")]
        [Required]
        public int CustomerId { get; set; }

        [Range(0, 100)]
        [Required]
        public double Discount { get; set; }
    }
}