namespace Car_Dealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Services.Models.Sales;

    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        IEnumerable<SaleListModel> Discounted();

        SaleDetailsModel Details(int id);

        void Add(int carId, int customerId, double discount);
    }
}