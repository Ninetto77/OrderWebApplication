using Microsoft.AspNetCore.Mvc;
using TestOrderWebApplication.Data.Interfaces;
using TestOrderWebApplication.Data.Models;

namespace TestOrderWebApplication.Controllers
{
    public class AddOrderController: Controller
    {
        private readonly IAllOrder _allOrders;
        public AddOrderController(IAllOrder allOrder)
        {
            _allOrders = allOrder;
        }

        public IActionResult Index(Order order)
        {
            ViewBag.Title = "Оформление заказа";
            return View(order);
        }

        [HttpPost] // передача данных из формочки
        public IActionResult Checkout(Order order)
        {
            ViewBag.Title = "Оформление заказа";

            if (ModelState.IsValid)
            {
                _allOrders.AddOrder(order);
                return RedirectToAction("Complete");
            }
            return View("Index");
        }

		public IActionResult Complete()
        {
            ViewBag.Title = "Товар успешно добавлен!";
            return View();
        }

    }
}
