using Microsoft.AspNetCore.Mvc;
using TestOrderWebApplication.Data.Interfaces;

namespace TestOrderWebApplication.Controllers
{
    public class CurrentOrderController: Controller
    {
        private IAllOrder _allOrders;
        public CurrentOrderController(IAllOrder allOrder)
        {
            _allOrders = allOrder;
        }

        public ViewResult Index()
        {

            return View();
        }

        public IActionResult ShowOrder(int? id = 0)
        {
            ViewBag.Title = "Информация о заказе";

            var item = _allOrders.AllOrders.FirstOrDefault(o => o.Id == id);
            if (item != null)
            {
                return View(item);
            }
            return View();
        }

        //public RedirectToActionResult ShowOrder(int? id = 0)
        //{
        //    var item = _allOrders.AllOrders.FirstOrDefault(o => o.Id == id);
        //    //return RedirectToAction("Index");
        //    if (item != null)
        //    {
        //        return View(item);
        //    }

        //}
    }
}
