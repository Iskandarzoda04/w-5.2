using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastucture.Interfase;

public class MenuItemService : IMenuItem
{
    public readonly DateContext context = new DateContext();

    public async Task AddMenuItem(MenuItem item)
    {
        using var conn = context.GetConnection();

        var sql = @"insert into menu_items(menu_id,name,description,price,category)
                    values (@MenuId,@Name,@Description,@Price,@Category)";

        await conn.ExecuteAsync(sql, item);
    }

    public async Task UpdateMenuItem(MenuItem item)
    {
        using var conn = context.GetConnection();

        var sql = @"update menu_items 
                    set menu_id=@MenuId,
                        name=@Name,
                        description=@Description,
                        price=@Price,
                        category=@Category
                    where id=@Id";

        await conn.ExecuteAsync(sql, item);
    }

    public async Task DeleteMenuItem(int id)
    {
        using var conn = context.GetConnection();

        var sql = "delete from menu_items where id=@id";

        await conn.ExecuteAsync(sql,new { id });
    }

    public async Task<MenuItem?> GetMenuItemById(int id)
    {
        using var conn = context.GetConnection();
        
        var sql =  "select * from menu_items where id=@id";
        return await conn.QueryFirstOrDefaultAsync<MenuItem>(sql, new { id });
    }

    
    }
