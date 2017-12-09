namespace Car_Dealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int Id { get; set; }

        [Range(0,100)]
        public double Discount { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}
