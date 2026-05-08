using Domain;

namespace Infrastucture.Interfase;

public interface ISubscription
{
      Task AddSubscriptionAsync(Subscription subscription);
    Task<List<Subscription>> GetAllSubscriptionsAsync();
    Task UpdateSubscriptionAsync(Subscription subscription);
    Task DeleteSubscriptionAsync(int id);

}