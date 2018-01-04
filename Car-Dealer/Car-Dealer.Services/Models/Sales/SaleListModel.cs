namespace Car_Dealer.Services.Models.Sales
{
    public class SaleListModel : SaleModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public bool IsYoungDriver { get; set; }

        public decimal DiscountedPrice => 
            this.Price - (IsYoungDriver == true ? (this.Price * (decimal)this.Discount) : 0);
    }
}
