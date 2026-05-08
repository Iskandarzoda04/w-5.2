using Domain;
namespace Infrastucture.Interfase;

public interface IOrderService
{
   
  Task AddOrder(Order order);
Task UpdateOrder(Order order);
Task DeleteOrder(int id);
Task<Order?> GetOrderById(int id);
Task<List<Order>> GetAllOrders();

   
}


