using TestOrderWebApplication.Data.Models;

namespace TestOrderWebApplication.Data.Interfaces
{
    public interface IAllOrder
    {
        IEnumerable<Order> AllOrders { get; }
        Order GetCurrentOrder(int orderId);

        void AddOrder(Order order);
    }
}
