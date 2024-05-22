using Entities;
using Repository.order;
using Repository.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Service.order;

public class OrderService : IOrderService
{
    IOrderRepository orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }
    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await orderRepository.Get();
    }

    public async Task<Order> AddOrder(Order order)
    {
        return await orderRepository.AddOrder(order);

    }

}
