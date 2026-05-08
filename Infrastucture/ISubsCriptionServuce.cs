using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastucture.Interfase;

public class SubscriptionService : ISubscription
{
    public readonly DateContext context = new DateContext();

    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        using var conn = context.GetConnection();

        var sql = @"insert into subscriptions
                    (company_id, plan_type, meals_per_day, price, start_date, end_date, is_active, created_at, updated_at)
                    values
                    (@CompanyId, @PlanType, @MealsPerDay, @Price, @StartDate, @EndDate, @IsActive, @CreatedAt, @UpdatedAt)";

        await conn.ExecuteAsync(sql, subscription);
    }

    public async Task<List<Subscription>> GetAllSubscriptionsAsync()
    {
        using var conn = context.GetConnection();

        var sql = "select * from subscriptions";

        var sb = (await conn.QueryAsync<Subscription>(sql)).ToList();

        return sb;
    }

    public async Task UpdateSubscriptionAsync(Subscription subscription)
    {
        using var conn = context.GetConnection();

        var sql = @"update subscriptions set
                        company_id=@CompanyId,
                        plan_type=@PlanType,
                        meals_per_day=@MealsPerDay,
                        price=@Price,
                        start_date=@StartDate,
                        end_date=@EndDate,
                        is_active=@IsActive,
                        updated_at=@UpdatedAt
                    where id=@Id";

        await conn.ExecuteAsync(sql, subscription);
    }

    public async Task DeleteSubscriptionAsync(int id)
    {
        using var conn = context.GetConnection();

        var sql = "delete from subscriptions where id=@id";

        await conn.ExecuteAsync(sql, new { id });
    }
}