﻿namespace Car_Dealer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public Supplier Supplier { get; set; }

        public int SupplierId { get; set; }

        public List<PartCar> Cars { get; set; } = new List<PartCar>();
    }
}