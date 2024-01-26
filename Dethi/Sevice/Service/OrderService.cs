using Dethi.Data;
using Dethi.Dto;
using Dethi.Model;
using Dethi.Repo;
using Dethi.Sevice.Iservice;

namespace Dethi.Sevice.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductRepo _productRepo;
        private readonly MyDb _myDb;
        public OrderService(IOrderRepo orderRepo, MyDb myDb, IProductRepo productRepo)
        {
            _orderRepo = orderRepo;
            _myDb = myDb;
            _productRepo=productRepo;
        }
        public Order CreateOrder(int Id, OrderDto orderDto)
        {
            try
            {
                var product = _productRepo.findbyId(Id);
                if(product == null)
                {
                    throw new Exception("Not found product");
                }

                Order newOrder = new Order
                {
                    IdProduct = product.Id,
                    ProductName = product.ProductName,
                    QuantityOrder = orderDto.QuantityOrder,
                    TotalPrice = product.Price * orderDto.QuantityOrder,
                    Adress = orderDto.Adress,
                    PhoneNuber = orderDto.PhoneNuber,
                    TimeShip = orderDto.TimeShip,
                };
                _myDb.Add(newOrder);
                _myDb.SaveChanges();
                return newOrder;

            }
            catch(Exception ex)
            {
                throw new Exception($"An error {ex}");
            }
          
        }

        public string DeleteOrder(int orderId)
        {
            try
            {
                var orderToDelete = _orderRepo.findorderbyId(orderId);
                if (orderToDelete == null)
                {
                    throw new Exception($"Order with ID {orderId} not found.");
                }

                _myDb.Orders.Remove(orderToDelete);
                _myDb.SaveChanges();
                return $"Order with ID {orderId} deleted successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public Order UpdateOrder(int orderId, Update updatedOrderDto)
        {
            try
            {
                var existingOrder = _orderRepo.findorderbyId(orderId);
                if (existingOrder == null)
                {
                    throw new Exception($"Order with ID {orderId} not found.");
                }
                 
                existingOrder.Adress = updatedOrderDto.Adress;
                existingOrder.PhoneNuber = updatedOrderDto.PhoneNuber;
                existingOrder.TimeShip = updatedOrderDto.TimeShip;

                _myDb.SaveChanges();
                return existingOrder;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
        public List<Order> Getall()
        {
            return _myDb.Orders.ToList();
        }
    }
}
