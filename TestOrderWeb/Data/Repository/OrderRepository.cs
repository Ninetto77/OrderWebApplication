using Microsoft.EntityFrameworkCore;
using TestOrderWebApplication.Data.Interfaces;
using TestOrderWebApplication.Data.Models;

namespace TestOrderWebApplication.Data.Repository
{
    public class OrderRepository : IAllOrder
    {
        private AppDBContent appDbContent;

        public OrderRepository(AppDBContent app)
        {
            appDbContent = app;
        }

        public IEnumerable<Order> AllOrders => appDbContent.AllOrders;

        public void AddOrder(Order order)
        {
            appDbContent.Add(new Order
            {
                Id = order.Id,
                SenderCity = order.SenderCity,
                SenderAddres = order.SenderAddres,
                RecipientCity = order.RecipientCity,
                RecipientAddres = order.RecipientAddres,
                CargoWeight = order.CargoWeight,
                DateCargoPickup = order.DateCargoPickup,
            });
            appDbContent.SaveChanges();
        }

        public Order GetCurrentOrder(int orderId) => appDbContent.AllOrders.FirstOrDefault(o => o.Id == orderId);
    }
}
