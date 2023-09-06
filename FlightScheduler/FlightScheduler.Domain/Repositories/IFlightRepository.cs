using FlightScheduler.Domain.Entities.Flight;

namespace FlightScheduler.Domain.Repositories;

public interface IFlightRepository
{
    public Task InsertFlightsDataFromCsv();
    public Task<List<Flight>> GetFlightsByRouteIds(List<int> routeIds);
}