
using RestaurantManagement.Models.Data;
using RestaurantManagement.Repository;
using RestaurantManagement.ViewModels;
using RestaurantManagement.ViewModels.OrderView;

namespace RestaurantManagement.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {

            var orders = _unitOfWork.Orders.GetAllAsync().Result;
            var OrderViewModelList = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var orderview = new OrderViewModel
                {
                    OrderId = order.OrderId,
                    OrderTime = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    TableNumber = order.Table.TableNumber,
                    Status = order.OrderStatus,

                };

                OrderViewModelList.Add(orderview);
            }
            return OrderViewModelList;
        }

        public OrderViewModel GetOrderById(int id)
        {
            var order = _unitOfWork.Orders.GetByIdAsync(id).Result;
            var orderview = new OrderViewModel
            {
                OrderId = order.OrderId,
                OrderTime = order.OrderDate,
                TotalAmount = order.TotalAmount,
                TableNumber = order.Table.TableNumber,
                Status = order.OrderStatus,

            };

            return orderview;
        }

        public async void CreateOrder(OrderCreateViewModel model)
        {

            var order = new Order
            {
                TableId = model.TableId,

                OrderItems = model.TableOptions.Select(t => new OrderItem
                {
                    MenuItemId = t.MenuItemId,
                    Quantity = t.Quantity,
                }).ToList(),


            };


            _unitOfWork.Orders.AddAsync(order).Wait();
            _unitOfWork.CompleteAsync().Wait();
        }

        public void UpdateOrder(OrderEditViewModel model)
        {
            var order = _unitOfWork.Orders.GetByIdAsync(model.OrderId).Result;
            order.TotalAmount = model.TotalAmount;
            _unitOfWork.Orders.UpdateAsync(order);
            _unitOfWork.CompleteAsync().Wait();
        }

        public void DeleteOrder(int id)
        {
            var order = _unitOfWork.Orders.GetByIdAsync(id).Result;
            _unitOfWork.Orders.RemoveAsync(order);
            _unitOfWork.CompleteAsync().Wait();
        }

        public IEnumerable<TableViewModel> GetTableOptions()
        {
            var tables = _unitOfWork.Tables.GetAllAsync().Result;
            List<TableViewModel>? TableViewList = new List<TableViewModel>();

            foreach (var table in tables)
            {
                var TableView = new TableViewModel
                {
                    Id = table.TableId,
                    IsOccupied = table.IsOccupied,
                    Number = table.TableNumber,
                    Seats = table.Capacity
                };

                TableViewList.Add(TableView);
            }

            return TableViewList.ToList();


        }
    }
}
