using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastructure.Interfaces;
using Infrastucture.Interfase;

public class MenuService : IMenu
{
    public readonly DateContext context = new DateContext();

    public async Task AddMenu(Menu menu)
    {
        using var conn = context.GetConnection();

        var sql = @"insert into menus(menu_date,is_active)
                    values (@MenuDate,@IsActive)";

        await conn.ExecuteAsync(sql, menu);
    }

    public async Task UpdateMenu(Menu menu)
    {
        using var conn = context.GetConnection();

        var sql = @"update menus 
                    set menu_date=@MenuDate,is_active=@IsActive 
                    where id=@Id";

        await conn.ExecuteAsync(sql, menu);
    }

    public async Task DeleteMenu(int id)
    {
        using var conn = context.GetConnection();
        
        var sql ="delete from menus where id=@id";

        await conn.ExecuteAsync(sql, new { id });
    }

    public async Task<Menu?> GetMenuById(int id)
    {
        using var conn = context.GetConnection();

        var sql = "select * from menus where id=@id";

        return await conn.QueryFirstOrDefaultAsync<Menu>(sql, new { id });
    }

 


 
}

