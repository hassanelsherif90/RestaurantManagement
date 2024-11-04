
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models.ViewModels;
using RestaurantManagement.Services;
using RestaurantManagement.ViewModels;
using RestaurantManagement.ViewModels.OrderView;

namespace RestaurantManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService; // يجب عليك تعريف الخدمة المناسبة

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public IActionResult Create()
        {
            IEnumerable<TableViewModel> tableOptions = _orderService.GetTableOptions();


            var model = new OrderCreateViewModel
            {
                TableOptions = tableOptions.Select(tableViewModel => new OrderItemViewModel
                {
                    MenuItemId = tableViewModel.Id,
                    Quantity = tableViewModel.Seats
                }).ToList()


            };
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(model);
                return RedirectToAction("Index");
            }

            model.TableOptions = _orderService.GetTableOptions().Select(t => new OrderItemViewModel
            {

                MenuItemId = t.Id,
                Quantity = t.Seats
            }).ToList();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            OrderViewModel? order = _orderService.GetOrderById(id);




            var model = new OrderEditViewModel
            {
                OrderId = order.OrderId,
                //TableId = order.TableNumber,
                TotalAmount = order.TotalAmount,
                TableOptions = _orderService.GetTableOptions().Select(t => new OrderItemViewModel
                {
                    MenuItemId = t.Id,
                    Quantity = t.Seats


                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(OrderEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _orderService.UpdateOrder(model);
                return RedirectToAction("Index");
            }

            model.TableOptions = _orderService.GetTableOptions().Select(t => new OrderItemViewModel
            {
                MenuItemId = t.Id,
                Quantity = t.Seats

            }).ToList();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var order = _orderService.GetOrderById(id);
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var order = _orderService.GetOrderById(id);
            return View(order);
        }
    }

}
