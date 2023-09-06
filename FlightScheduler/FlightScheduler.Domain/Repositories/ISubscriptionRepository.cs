using FlightScheduler.Domain.Entities.Subscription;

namespace FlightScheduler.Domain.Repositories;

public interface ISubscriptionRepository
{
    public Task<List<Subscription>> GetSubscriptionByAgencyId(short agencyId);
}