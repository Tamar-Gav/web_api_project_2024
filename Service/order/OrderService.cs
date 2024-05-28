using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.order;
using Repository.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Service;

public class OrderService : IOrderService
{
    ILogger<OrderService> _logger;
    IOrderRepository orderRepository;
    IProductRepository _prepository;
    public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger, IProductRepository pr)
    {
        _logger = logger;
        this.orderRepository = orderRepository;
        _prepository = pr;
    }
    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await orderRepository.Get();
    }
    public async Task<CustomHttpResponse<Order>> AddOrder(Order order)
    {
        var products = _prepository.Get(0, 1000, "", "", []);
        List<Product> productList = (List<Product>)await products;
        decimal totalSum = (decimal)order.OrderItems
                .Where(oi => productList.Any(p => p.ProdId == oi.ProdId))
                .Sum(oi => productList.First(p => p.ProdId == oi.ProdId).Price * oi.Quantity);

        Console.Write("  totalSum  " + totalSum);
        Console.Write("  order.OrderSum  " + order.OrderSum);

        if (order.OrderSum != totalSum)
        {
            Console.WriteLine("ERR");
            _logger.LogError("🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠!!!התראה🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️\n חדירת גנב לחנות, קרא למשטרה להזכירך 📞 100 ");

            return new CustomHttpResponse<Order>(null, 401); // Return 401 status code with null Order
        }
        else
        {
            Order result = await orderRepository.AddOrder(order);
            return result != null ? new CustomHttpResponse<Order>(result, 200) : new CustomHttpResponse<Order>(null, 401);
        }
    }
}

