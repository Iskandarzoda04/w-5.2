using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastucture.Interfase;

public class OrderService : IOrderService
{
    public readonly DateContext context = new DateContext();

    public async Task AddOrder(Order order)
    {
        using var conn = context.GetConnection();

        var sql = @"insert into orders(company_id,order_date,status,total_amount)
                    values(@CompanyId,@OrderDate,@Status,@TotalAmount)";

        await conn.ExecuteAsync(sql, order);
    }

    public async Task UpdateOrder(Order order)
    {
        using var conn = context.GetConnection();

        var sql = @"update orders 
                    set company_id=@CompanyId,
                        order_date=@OrderDate,
                        status=@Status,
                        total_amount=@TotalAmount
                    where id=@Id";

        await conn.ExecuteAsync(sql, order);
    }

    public async Task DeleteOrder(int id)
    {
        using var conn = context.GetConnection();

        var sql = "delete from orders where id=@id";

        await conn.ExecuteAsync(sql, new { id });
    }

    public async Task<Order?> GetOrderById(int id)
    {
        using var conn = context.GetConnection();

        var sql = "select * from orders where id=@id";

        return await conn.QueryFirstOrDefaultAsync<Order>(sql, new { id });
    }

    public async Task<List<Order>> GetAllOrders()
    {
        using var conn = context.GetConnection();

        var sql = "select * from orders";

        var or =(await conn.QueryAsync<Order>(sql)).ToList();

        return or;
    }
}