using System;
using System.ComponentModel.DataAnnotations;

namespace Car_Dealer.Models.Customers
{
    public class CustomerFormModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
