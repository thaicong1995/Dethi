using Dethi.Dto;
using Dethi.Model;

namespace Dethi.Sevice.Iservice
{
    public interface IOrderService
    {
        public Order CreateOrder(int Id, OrderDto orderDto);
        public Order UpdateOrder(int orderId, Update updatedOrderDto);
        public string DeleteOrder(int orderId);
        public List<Order> Getall();
    }
}
