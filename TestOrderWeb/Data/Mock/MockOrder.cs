using TestOrderWebApplication.Data.Interfaces;
using TestOrderWebApplication.Data.Models;

namespace TestOrderWebApplication.Data.Mock
{
    public class MockOrder : IAllOrder
    {
        public IEnumerable<Order> AllOrders
        {
            get
            {
                List<Order> orders = new List<Order>();
                for (int i = 0; i < 7; i++)
                {
                    Order or = new Order()
                    {
                        Id = i,
                        CargoWeight = $"{i + 10}",
                        DateCargoPickup = $"{i + 10}",
                        RecipientAddres = $"{i + 10}",
                        SenderAddres = $"{i + 10}",
                        RecipientCity = $"{i + 10}",
                        SenderCity = $"{i + 10}",
                    };
                    orders.Add(or);
                }
                return orders;
            }
            set => AllOrders = value;
        }

        public void AddOrder(Order order)
        {
            List<Order> orders;
            if (AllOrders.Count() == 0)
            {
                orders = new List<Order>();
            }
            else orders = AllOrders.ToList();

            orders.Add(order);
            AllOrders = orders;
        }

        public Order? GetCurrentOrder(int orderId) => AllOrders.FirstOrDefault(o => o.Id == orderId);
    }
}
