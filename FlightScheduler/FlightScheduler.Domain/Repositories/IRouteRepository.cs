using FlightScheduler.Domain.Entities.Route;
using FlightScheduler.DTO.DTOs;

namespace FlightScheduler.Domain.Repositories;

public interface IRouteRepository
{
    public Task InsertRoutesDataFromCsv();

    public Task<List<int>> GetRoutesIdsForCitiesInTimeInterval(List<RouteCitiesDto> routeCities,DateTime startDate,DateTime endDate);
}
