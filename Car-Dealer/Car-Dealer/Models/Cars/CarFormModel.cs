namespace Car_Dealer.Models.Cars
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CarFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Display(Name = "Travelled Distance")]
        [Range(0, long.MaxValue, ErrorMessage = "Travelled Distance must be positive number.")]
        public long TravelledDistance { get; set; }

        [Display(Name = "Parts")]
        public IEnumerable<int> PartsIds { get; set; }

        public IEnumerable<SelectListItem> Parts { get; set; }
    }
}
