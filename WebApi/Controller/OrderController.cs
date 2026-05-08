using Domain;
using Infrastructure;
using Infrastucture.Interfase;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController
{
    private readonly IOrderService _orderService = new OrderService();

    [HttpGet]
    public async Task<List<Order>> Get()
    {
        return await _orderService.GetAllOrders();
    }

    [HttpGet("{id:int}")]
    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _orderService.GetOrderById(id);
    }

    [HttpPost]
    public async Task AddAsync(Order order)
    {
        await _orderService.AddOrder(order);
    }

    [HttpPut]
    public async Task UpdateAsync(Order order)
    {
        await _orderService.UpdateOrder(order);
    }

    [HttpDelete("{id:int}")]
    public async Task DeleteAsync(int id)
    {
        await _orderService.DeleteOrder(id);
    }
}