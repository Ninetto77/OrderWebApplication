//using MessagePack.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestOrderWebApplication.Data.Models;
using TestOrderWebApplication.ViewModels;

namespace TestOrderWebApplication.Data
{
    public class DBObjects
    {
        public static void Init(AppDBContent content)
        {
            if (!content.AllOrders.Any())
            {
                content.AllOrders.AddRange(Orders.Select(content=> content.Value));
                content.AllOrders.AsNoTracking();
            }

            
            content.SaveChanges();
        }

        private static Dictionary<string, Order>? orders; //оставить static?
        public static Dictionary<string, Order> Orders { 
            get
            {
                if (orders == null)
                {
                    List<Order> ordersList = new List<Order>();

                    for (int i = 0; i < 8; i++)
                    {
                        Order or = new Order()
                        {
                            CargoWeight = $"{i + 10}",
                            DateCargoPickup = $"{i + 10}.07.2024",
                            RecipientAddres = $"Адрес_получателя_{i + 10}",
                            SenderAddres = $"Адрес_отправителя_{i + 10}",
                            RecipientCity = $"Город_получателя_{i + 10}",
                            SenderCity = $"Город_отправителя_{i + 10}",
                        };
                        ordersList.Add(or);
                    }

                    orders = new Dictionary<string, Order>();
                    foreach (Order el in ordersList)
                        orders.Add(el.SenderAddres, el);
                }

                return orders;
            }
        }

    }
}
