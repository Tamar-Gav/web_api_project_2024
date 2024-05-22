using Entities;

namespace Service.order
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Order>> GetOrders();
    }
}