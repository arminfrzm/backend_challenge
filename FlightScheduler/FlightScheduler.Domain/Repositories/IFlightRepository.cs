namespace FlightScheduler.Domain.Repositories;

public interface IFlightRepository
{
    public Task InsertFlightsDataFromCsv();
}