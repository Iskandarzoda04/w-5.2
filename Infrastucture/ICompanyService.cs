using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastructure.Interfaces;
using Infrastucture.Interfase;

public class CompanyService : ICompanyService
{
  
   public readonly DateContext context = new DateContext();
    public async Task AddCompany(Company company)
    {
        using var conn = context.GetConnection();

        var sql = @"insert into companies(name,address,phone,email)
                    values (@Name,@Address,@Phone,@Email)";

        await conn.ExecuteAsync(sql, company);
    }

    public async Task UpdateCompany(Company company)
    {
        using var conn = context.GetConnection();

        var sql = @"update companies set name=@Name,address=@Address,phone=@Phone,email=@Email where id=@Id";

        await conn.ExecuteAsync(sql, company);
    }

    public async Task DeleteCompany(int id)
    {
        using var conn = context.GetConnection();

        var sql ="delete from companies where id=@id";

        await conn.ExecuteAsync(sql,new { id });
    }

    public async Task<Company?> GetCompanyById(int id)
    {
        using var conn = context.GetConnection();

        var sql ="select * from companies where id=@id";

        return await conn.QueryFirstOrDefaultAsync<Company>(sql, new { id });
    }

   
}