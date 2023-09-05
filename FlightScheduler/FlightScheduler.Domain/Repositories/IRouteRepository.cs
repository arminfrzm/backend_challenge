namespace FlightScheduler.Domain.Repositories;

public interface IRouteRepository
{
    public Task InsertRoutesDataFromCsv();
}