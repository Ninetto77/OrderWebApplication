using TestOrderWebApplication.Data.Models;

namespace TestOrderWebApplication.ViewModels
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> AllOrders { get; set; }
    }
}
