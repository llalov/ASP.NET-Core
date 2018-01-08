namespace Car_Dealer.Models.Parts
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;


    public class PartFormModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

      

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
    }
}
