using Domain;
namespace Infrastucture.Interfase;

public interface IOrderItem
{
   Task AddOrderItem(OrderItem orderItem);
Task UpdateOrderItem(OrderItem orderItem);
Task DeleteOrderItem(int id);
Task<OrderItem?> GetOrderItemById(int id);
Task<List<OrderItem>> GetAllOrderItems();
}