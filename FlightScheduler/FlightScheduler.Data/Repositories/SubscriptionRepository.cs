using FlightScheduler.Data.Context;
using FlightScheduler.Domain.Entities.Subscription;
using FlightScheduler.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightScheduler.Data.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly FlightSchedulerContext _context;

    public SubscriptionRepository(FlightSchedulerContext context)
    {
        _context = context;
    }

    public async Task<List<Subscription>> GetSubscriptionByAgencyId(short agencyId)
    {
        return await _context.Subscriptions!.Where(s => s.AgencyId == agencyId).ToListAsync();
    }
}
