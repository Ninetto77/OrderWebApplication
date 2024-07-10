using Microsoft.AspNetCore.Mvc;
using TestOrderWebApplication.Data.Interfaces;
using TestOrderWebApplication.ViewModels;

namespace TestOrderWebApplication.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllOrder _allOrders;
        public HomeController(IAllOrder allOrders)
        {
            _allOrders = allOrders;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Все заказы";
            OrdersListViewModel obj = new OrdersListViewModel();
            obj.AllOrders = _allOrders.AllOrders;
            return View(obj);
        }


    }
}
