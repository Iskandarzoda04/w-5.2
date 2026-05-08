using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastucture.Interfase;

public class OrderItemService : IOrderItem
{
    public readonly DateContext context = new DateContext();

    public async Task AddOrderItem(OrderItem orderItem)
    {
        using var conn = context.GetConnection();

        var sql = @"insert into order_items(order_id,menu_item_id,quantity,price)
                    values (@OrderId,@MenuItemId,@Quantity,@Price)";

        await conn.ExecuteAsync(sql, orderItem);
    }

    public async Task UpdateOrderItem(OrderItem orderItem)
    {
        using var conn = context.GetConnection();

        var sql = @"update order_items 
                    set order_id=@OrderId,
                        menu_item_id=@MenuItemId,
                        quantity=@Quantity,
                        price=@Price
                    where id=@Id";

        await conn.ExecuteAsync(sql, orderItem);
    }

    public async Task DeleteOrderItem(int id)
    {
        using var conn = context.GetConnection();

        var sql ="delete from order_items where id=@id";

        await conn.ExecuteAsync(sql, new { id });
    }

    public async Task<OrderItem?> GetOrderItemById(int id)
    {
        using var conn = context.GetConnection();

        var sql = "select * from order_items where id=@id";

        return await conn.QueryFirstOrDefaultAsync<OrderItem>(sql, new { id });
    }

    public async Task<List<OrderItem>> GetAllOrderItems()
    {
        using var conn = context.GetConnection();

        var sql = "select * from order_items";

        var or =(await conn.QueryAsync<OrderItem>(sql)).ToList();

        return or;
    }
}